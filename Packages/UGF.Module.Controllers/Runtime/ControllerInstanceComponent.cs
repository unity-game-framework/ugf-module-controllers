using System;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.IMGUI.Attributes;
using UnityEngine;

namespace UGF.Module.Controllers.Runtime
{
    [AddComponentMenu("Unity Game Framework/Controllers/Controller Instance", 2000)]
    public class ControllerInstanceComponent : ControllerComponent
    {
        [SerializeField] private bool m_buildOnAwake = true;
        [SerializeField] private bool m_buildUnique;
        [AssetGuid(typeof(ControllerInstanceProviderControllerAsset))]
        [SerializeField] private string m_provider;
        [AssetGuid(typeof(ControllerAsset))]
        [SerializeField] private string m_controller;

        public bool BuildOnAwake { get { return m_buildOnAwake; } set { m_buildOnAwake = value; } }
        public bool BuildUnique { get { return m_buildUnique; } set { m_buildUnique = value; } }
        public string Provider { get { return m_provider; } set { m_provider = value; } }
        public string Controller { get { return m_controller; } set { m_controller = value; } }
        public string InstanceId { get { return !string.IsNullOrEmpty(m_instanceId) ? m_instanceId : throw new ArgumentException("Value not specified."); } }
        public IController Instance { get { return m_instance ?? throw new ArgumentException("Value not specified."); } }
        public bool HasInstance { get { return m_instance != null; } }

        private string m_instanceId;
        private IController m_instance;

        protected override IController OnBuild(IApplication application)
        {
            var provider = application.GetController<IControllerInstanceProviderController>(m_provider);
            IController controller = provider.Build(m_controller);

            return controller;
        }

        private void Awake()
        {
            if (m_buildOnAwake && gameObject.TryGetApplication(out IApplication application))
            {
                m_instanceId = m_buildUnique ? Guid.NewGuid().ToString("N") : m_controller;
                m_instance = OnBuild(application);
                m_instance.Application.AddController(m_instanceId, m_instance);
            }
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
