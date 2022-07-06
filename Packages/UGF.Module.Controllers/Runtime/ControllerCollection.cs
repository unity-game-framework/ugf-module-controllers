﻿using System;
using UGF.Initialize.Runtime;
using UGF.RuntimeTools.Runtime.Providers;

namespace UGF.Module.Controllers.Runtime
{
    public class ControllerCollection<TController> : Provider<string, TController>, IInitialize where TController : class, IController
    {
        public bool IsInitialized { get { return m_state; } }

        public event InitializeHandler Initialized;
        public event InitializeHandler Uninitialized;

        private readonly InitializeCollection<IController> m_initializeCollection = new InitializeCollection<IController>();
        private InitializeState m_state;

        public void Initialize()
        {
            m_state = m_state.Initialize();
            m_initializeCollection.Initialize();

            Initialized?.Invoke(this);
        }

        public void Uninitialize()
        {
            m_state = m_state.Uninitialize();
            m_initializeCollection.Uninitialize();

            Uninitialized?.Invoke(this);
        }

        protected override void OnAdd(string id, TController entry)
        {
            base.OnAdd(id, entry);

            m_initializeCollection.Add(entry);
        }

        protected override bool OnRemove(string id, TController entry)
        {
            m_initializeCollection.Remove(entry);

            return base.OnRemove(id, entry);
        }

        protected override void OnClear()
        {
            base.OnClear();

            m_initializeCollection.Clear();
        }

        protected override bool OnTryGet(Type type, out TController value)
        {
            foreach ((_, TController controller) in this)
            {
                if (type.IsInstanceOfType(controller))
                {
                    value = controller;
                    return true;
                }

                if (controller is ControllerCollectionController collection && collection.Controllers.TryGet(type, out IController result))
                {
                    value = (TController)result;
                    return true;
                }
            }

            value = default;
            return false;
        }
    }
}