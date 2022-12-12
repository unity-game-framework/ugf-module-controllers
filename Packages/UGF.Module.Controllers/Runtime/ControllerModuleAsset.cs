using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Assets;
using UnityEngine;

namespace UGF.Module.Controllers.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Controllers/Controller Module", order = 2000)]
    public class ControllerModuleAsset : ApplicationModuleAsset<IControllerModule, ControllerModuleDescription>
    {
        [SerializeField] private bool m_useReverseUninitializationOrder = true;
        [SerializeField] private List<AssetIdReference<ControllerAsset>> m_controllers = new List<AssetIdReference<ControllerAsset>>();
        [SerializeField] private List<ControllerCollectionAsset> m_collections = new List<ControllerCollectionAsset>();

        public bool UseReverseUninitializationOrder { get { return m_useReverseUninitializationOrder; } set { m_useReverseUninitializationOrder = value; } }
        public List<AssetIdReference<ControllerAsset>> Controllers { get { return m_controllers; } }
        public List<ControllerCollectionAsset> Collections { get { return m_collections; } }

        protected override IApplicationModuleDescription OnBuildDescription()
        {
            var description = new ControllerModuleDescription
            {
                RegisterType = typeof(IControllerModule),
                UseReverseUninitializationOrder = m_useReverseUninitializationOrder
            };

            for (int i = 0; i < m_controllers.Count; i++)
            {
                AssetIdReference<ControllerAsset> reference = m_controllers[i];

                description.Controllers.Add(reference.Guid, reference.Asset);
            }

            for (int i = 0; i < m_collections.Count; i++)
            {
                ControllerCollectionAsset collection = m_collections[i];

                collection.GetControllers(description.Controllers);
            }

            return description;
        }

        protected override IControllerModule OnBuild(ControllerModuleDescription description, IApplication application)
        {
            return new ControllerModule(description, application);
        }
    }
}
