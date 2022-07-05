using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.IMGUI.AssetReferences;
using UnityEngine;

namespace UGF.Module.Controllers.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Controllers/Controller Collection Controller", order = 2000)]
    public class ControllerCollectionControllerAsset : ControllerDescribedAsset<ControllerCollectionController, ControllerCollectionControllerDescription>
    {
        [SerializeField] private List<AssetReference<ControllerAsset>> m_controllers = new List<AssetReference<ControllerAsset>>();

        public List<AssetReference<ControllerAsset>> Controllers { get { return m_controllers; } set { m_controllers = value; } }

        protected override ControllerCollectionControllerDescription OnBuildDescription()
        {
            var description = new ControllerCollectionControllerDescription();

            for (int i = 0; i < m_controllers.Count; i++)
            {
                AssetReference<ControllerAsset> reference = m_controllers[i];

                description.Controllers.Add(reference.Guid, reference.Asset);
            }

            return description;
        }

        protected override ControllerCollectionController OnBuild(ControllerCollectionControllerDescription description, IApplication application)
        {
            return new ControllerCollectionController(description, application);
        }
    }
}
