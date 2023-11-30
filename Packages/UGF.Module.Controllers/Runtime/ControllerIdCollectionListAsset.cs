using System.Collections.Generic;
using UGF.EditorTools.Runtime.Assets;
using UGF.EditorTools.Runtime.Ids;
using UnityEngine;

namespace UGF.Module.Controllers.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Controllers/Controller Id Collection List", order = 2000)]
    public class ControllerIdCollectionListAsset : ControllerIdCollectionAsset
    {
        [AssetId(typeof(ControllerAsset))]
        [SerializeField] private List<GlobalId> m_controllers = new List<GlobalId>();

        public List<GlobalId> Controllers { get { return m_controllers; } }

        protected override void OnGetControllers(ICollection<GlobalId> controllers)
        {
            for (int i = 0; i < m_controllers.Count; i++)
            {
                GlobalId controllerId = m_controllers[i];

                controllers.Add(controllerId);
            }
        }
    }
}
