using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Assets;
using UnityEngine;

namespace UGF.Module.Controllers.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Controllers/Controller Module", order = 2000)]
    public class ControllerModuleAsset : ApplicationModuleAsset<IControllerModule, ControllerModuleDescription>
    {
        [SerializeField] private List<AssetIdReference<ControllerAsset>> m_controllers = new List<AssetIdReference<ControllerAsset>>();

        public List<AssetIdReference<ControllerAsset>> Controllers { get { return m_controllers; } }

        protected override IApplicationModuleDescription OnBuildDescription()
        {
            var description = new ControllerModuleDescription(typeof(IControllerModule));

            for (int i = 0; i < m_controllers.Count; i++)
            {
                AssetIdReference<ControllerAsset> reference = m_controllers[i];

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
