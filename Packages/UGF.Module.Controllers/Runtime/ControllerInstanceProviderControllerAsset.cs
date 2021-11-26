using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.IMGUI.AssetReferences;
using UnityEngine;

namespace UGF.Module.Controllers.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Controllers/Controller Instance Provider Controller", order = 2000)]
    public class ControllerInstanceProviderControllerAsset : ControllerDescribedAsset<ControllerInstanceProviderController, ControllerInstanceProviderControllerDescription>
    {
        [SerializeField] private List<AssetReference<ControllerAsset>> m_controllers = new List<AssetReference<ControllerAsset>>();
        [SerializeField] private List<ControllerCollectionAsset> m_collections = new List<ControllerCollectionAsset>();

        public List<AssetReference<ControllerAsset>> Controllers { get { return m_controllers; } }
        public List<ControllerCollectionAsset> Collections { get { return m_collections; } }

        protected override ControllerInstanceProviderControllerDescription OnBuildDescription()
        {
            var description = new ControllerInstanceProviderControllerDescription();

            for (int i = 0; i < m_controllers.Count; i++)
            {
                AssetReference<ControllerAsset> reference = m_controllers[i];

                description.Controllers.Add(reference.Guid, reference.Asset);
            }

            for (int i = 0; i < m_collections.Count; i++)
            {
                ControllerCollectionAsset collection = m_collections[i];

                for (int j = 0; j < collection.Controllers.Count; j++)
                {
                    AssetReference<ControllerAsset> reference = collection.Controllers[j];

                    description.Controllers.Add(reference.Guid, reference.Asset);
                }
            }

            return description;
        }

        protected override ControllerInstanceProviderController OnBuild(ControllerInstanceProviderControllerDescription description, IApplication application)
        {
            return new ControllerInstanceProviderController(description, application);
        }
    }
}
