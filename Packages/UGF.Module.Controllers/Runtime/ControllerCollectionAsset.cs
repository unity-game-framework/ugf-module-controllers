using System.Collections.Generic;
using UGF.EditorTools.Runtime.Assets;
using UnityEngine;

namespace UGF.Module.Controllers.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Controllers/Controller Collection", order = 2000)]
    public class ControllerCollectionAsset : ScriptableObject
    {
        [SerializeField] private List<AssetIdReference<ControllerAsset>> m_controllers = new List<AssetIdReference<ControllerAsset>>();

        public List<AssetIdReference<ControllerAsset>> Controllers { get { return m_controllers; } }
    }
}
