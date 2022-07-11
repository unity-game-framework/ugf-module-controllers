using System;
using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Ids;
using UGF.EditorTools.Runtime.IMGUI.Attributes;
using UGF.Module.Controllers.Runtime.Objects;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UGF.Module.Controllers.Runtime
{
    [AddComponentMenu("Unity Game Framework/Controllers/Controller Instance", 2000)]
    public class ControllerInstanceComponent : ControllerComponent
    {
        [SerializeField] private bool m_buildOnAwake = true;
        [SerializeField] private bool m_buildAsSingleton;
        [AssetGuid(typeof(ControllerInstanceProviderControllerAsset))]
        [SerializeField] private GlobalId m_provider;
        [AssetGuid(typeof(ControllerAsset))]
        [SerializeField] private GlobalId m_controller;
        [SerializeField] private bool m_relativeToComponent;
        [AssetGuid(typeof(ObjectRelativesControllerAsset))]
        [SerializeField] private GlobalId m_relativesProvider;
        [SerializeField] private List<Object> m_relatives = new List<Object>();

        public bool BuildOnAwake { get { return m_buildOnAwake; } set { m_buildOnAwake = value; } }
        public bool BuildAsSingleton { get { return m_buildAsSingleton; } set { m_buildAsSingleton = value; } }
        public GlobalId Provider { get { return m_provider; } set { m_provider = value; } }
        public GlobalId Controller { get { return m_controller; } set { m_controller = value; } }
        public bool RelativeToComponent { get { return m_relativeToComponent; } set { m_relativeToComponent = value; } }
        public GlobalId RelativesProvider { get { return m_relativesProvider; } set { m_relativesProvider = value; } }
        public List<Object> Relatives { get { return m_relatives; } }
        public GlobalId InstanceId { get { return !string.IsNullOrEmpty(m_instanceId) ? m_instanceId : throw new ArgumentException("Value not specified."); } }
        public IController Instance { get { return m_instance ?? throw new ArgumentException("Value not specified."); } }
        public bool HasInstance { get { return m_instance != null; } }

        private GlobalId m_instanceId;
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
                m_instanceId = m_buildAsSingleton ? m_controller : GlobalId.Generate();
                m_instance = OnBuild(application);
                m_instance.Application.AddController(m_instanceId, m_instance);

                if (m_relativeToComponent)
                {
                    m_instance.Application.GetController<IObjectRelativesController>(m_relativesProvider).Provider.Connect(m_instance, this);
                }

                if (m_relatives.Count > 0)
                {
                    var objectRelativesController = m_instance.Application.GetController<IObjectRelativesController>(m_relativesProvider);

                    for (int i = 0; i < m_relatives.Count; i++)
                    {
                        objectRelativesController.Provider.Connect(m_instance, m_relatives[i]);
                    }
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

                if (m_relatives.Count > 0)
                {
                    var objectRelativesController = m_instance.Application.GetController<IObjectRelativesController>(m_relativesProvider);

                    for (int i = 0; i < m_relatives.Count; i++)
                    {
                        objectRelativesController.Provider.Disconnect(m_instance, m_relatives[i]);
                    }
                }

                m_instance.Application.RemoveController(m_instanceId);
            }
        }
    }
}
