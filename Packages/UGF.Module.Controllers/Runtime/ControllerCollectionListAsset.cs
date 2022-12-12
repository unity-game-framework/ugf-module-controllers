using System.Collections.Generic;
using UGF.EditorTools.Runtime.Assets;
using UGF.EditorTools.Runtime.Ids;
using UnityEngine;

namespace UGF.Module.Controllers.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Controllers/Controller Collection List", order = 2000)]
    public class ControllerCollectionListAsset : ControllerCollectionAsset
    {
        [SerializeField] private List<AssetIdReference<ControllerAsset>> m_controllers = new List<AssetIdReference<ControllerAsset>>();
        [SerializeField] private List<ControllerCollectionAsset> m_collections = new List<ControllerCollectionAsset>();

        public List<AssetIdReference<ControllerAsset>> Controllers { get { return m_controllers; } }
        public List<ControllerCollectionAsset> Collections { get { return m_collections; } }

        protected override void OnGetControllers(IDictionary<GlobalId, IControllerBuilder> controllers)
        {
            for (int i = 0; i < m_controllers.Count; i++)
            {
                AssetIdReference<ControllerAsset> reference = m_controllers[i];

                controllers.Add(reference.Guid, reference.Asset);
            }

            for (int i = 0; i < m_collections.Count; i++)
            {
                ControllerCollectionAsset collection = m_collections[i];

                collection.GetControllers(controllers);
            }
        }
    }
}
