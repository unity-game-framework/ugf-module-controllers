using System;
using UGF.EditorTools.Runtime.IMGUI.Attributes;
using UnityEngine;

namespace UGF.Module.Controllers.Runtime
{
    public abstract class ControllerInstanceComponent : MonoBehaviour
    {
        [AssetGuid(typeof(ControllerAsset))]
        [SerializeField] private string m_controller;
        [SerializeField] private bool m_buildUnique;

        public string Controller { get { return m_controller; } set { m_controller = value; } }
        public bool BuildUnique { get { return m_buildUnique; } set { m_buildUnique = value; } }
        public string InstanceId { get { return !string.IsNullOrEmpty(m_instanceId) ? m_instanceId : throw new ArgumentException("Value not specified."); } }
        public IController Instance { get { return m_instance ?? throw new ArgumentException("Value not specified."); } }
        public bool HasInstance { get { return m_instance != null; } }

        private string m_instanceId;
        private IController m_instance;

        protected abstract IController OnBuild();

        private void Awake()
        {
            m_instanceId = m_buildUnique ? Guid.NewGuid().ToString("N") : m_controller;
            m_instance = OnBuild();
            m_instance.Application.AddController(m_instanceId, m_instance);
        }

        private void Start()
        {
            m_instance?.Initialize();
        }

        private void OnDestroy()
        {
            if (m_instance != null)
            {
                m_instance.Uninitialize();
                m_instance.Application.RemoveController(m_instanceId);
            }
        }
    }
}
