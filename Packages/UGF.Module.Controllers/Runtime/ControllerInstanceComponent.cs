using System;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.IMGUI.Attributes;
using UGF.Module.Controllers.Runtime.Objects;
using UnityEngine;

namespace UGF.Module.Controllers.Runtime
{
    [AddComponentMenu("Unity Game Framework/Controllers/Controller Instance", 2000)]
    public partial class ControllerInstanceComponent : ControllerComponent
    {
        [SerializeField] private bool m_buildOnAwake = true;
        [SerializeField] private bool m_buildAsSingleton;
        [AssetGuid(typeof(ControllerInstanceProviderControllerAsset))]
        [SerializeField] private string m_provider;
        [AssetGuid(typeof(ControllerAsset))]
        [SerializeField] private string m_controller;
        [SerializeField] private bool m_relativeToComponent;
        [AssetGuid(typeof(ObjectRelativesControllerAsset))]
        [SerializeField] private string m_relativesProvider;

        public bool BuildOnAwake { get { return m_buildOnAwake; } set { m_buildOnAwake = value; } }
        public bool BuildAsSingleton { get { return m_buildAsSingleton; } set { m_buildAsSingleton = value; } }
        public string Provider { get { return m_provider; } set { m_provider = value; } }
        public string Controller { get { return m_controller; } set { m_controller = value; } }
        public bool RelativeToComponent { get { return m_relativeToComponent; } set { m_relativeToComponent = value; } }
        public string RelativesProvider { get { return m_relativesProvider; } set { m_relativesProvider = value; } }
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
                m_instanceId = m_buildAsSingleton ? m_controller : Guid.NewGuid().ToString("N");
                m_instance = OnBuild(application);
                m_instance.Application.AddController(m_instanceId, m_instance);

                if (m_relativeToComponent)
                {
                    m_instance.Application.GetController<IObjectRelativesController>(m_relativesProvider).Provider.Connect(m_instance, this);
                }
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

                if (m_relativeToComponent)
                {
                    m_instance.Application.GetController<IObjectRelativesController>(m_relativesProvider).Provider.Disconnect(m_instance, this);
                }

                m_instance.Application.RemoveController(m_instanceId);
            }
        }
    }
}
