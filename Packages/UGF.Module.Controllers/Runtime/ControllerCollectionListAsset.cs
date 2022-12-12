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

        public List<AssetIdReference<ControllerAsset>> Controllers { get { return m_controllers; } }

        protected override void OnGetControllers(IDictionary<GlobalId, IControllerBuilder> controllers)
        {
            for (int i = 0; i < m_controllers.Count; i++)
            {
                AssetIdReference<ControllerAsset> reference = m_controllers[i];

                controllers.Add(reference.Guid, reference.Asset);
            }
        }
    }
}
