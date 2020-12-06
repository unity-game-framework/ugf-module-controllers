using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.IMGUI.AssetReferences;
using UnityEngine;

namespace UGF.Module.Controllers.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Controllers/Controller Module", order = 2000)]
    public class ControllerModuleAsset : ApplicationModuleAsset<IControllerModule, ControllerModuleDescription>
    {
        [SerializeField] private bool m_useReverseUninitializationOrder = true;
        [SerializeField] private List<AssetReference<ControllerAsset>> m_controllers = new List<AssetReference<ControllerAsset>>();

        public bool UseReverseUninitializationOrder { get { return m_useReverseUninitializationOrder; } set { m_useReverseUninitializationOrder = value; } }
        public List<AssetReference<ControllerAsset>> Controllers { get { return m_controllers; } }

        protected override IApplicationModuleDescription OnBuildDescription()
        {
            var description = new ControllerModuleDescription(typeof(IControllerModule))
            {
                UseReverseUninitializationOrder = m_useReverseUninitializationOrder
            };

            for (int i = 0; i < m_controllers.Count; i++)
            {
                AssetReference<ControllerAsset> reference = m_controllers[i];

                description.Controllers.Add(reference.Guid, reference.Asset);
            }

            return description;
        }

        protected override IControllerModule OnBuild(ControllerModuleDescription description, IApplication application)
        {
            return new ControllerModule(description, application);
        }
    }
}
