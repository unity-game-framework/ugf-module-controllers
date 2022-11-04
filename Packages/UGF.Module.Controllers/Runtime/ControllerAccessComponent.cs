﻿using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Assets;
using UGF.EditorTools.Runtime.Ids;
using UnityEngine;

namespace UGF.Module.Controllers.Runtime
{
    [AddComponentMenu("Unity Game Framework/Controllers/Controller Access", 2000)]
    public class ControllerAccessComponent : MonoBehaviour
    {
        [SerializeField] private ApplicationAccessComponent m_applicationAccess;
        [AssetId(typeof(ControllerAsset))]
        [SerializeField] private GlobalId m_controller;

        public ApplicationAccessComponent ApplicationAccess { get { return m_applicationAccess; } set { m_applicationAccess = value; } }
        public GlobalId ControllerId { get { return m_controller; } set { m_controller = value; } }
        public IController Controller { get { return GetController(); } }

        public T GetController<T>() where T : class, IController
        {
            return m_applicationAccess.GetApplication().GetController<T>(m_controller);
        }

        public IController GetController()
        {
            return m_applicationAccess.GetApplication().GetController(m_controller);
        }
    }
}
