using System.Collections.Generic;
using UGF.EditorTools.Runtime.IMGUI.AssetReferences;
using UnityEngine;

namespace UGF.Module.Controllers.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Controllers/Controller Collection", order = 2000)]
    public class ControllerCollectionAsset : ScriptableObject
    {
        [SerializeField] private List<AssetReference<ControllerAsset>> m_controllers = new List<AssetReference<ControllerAsset>>();

        public List<AssetReference<ControllerAsset>> Controllers { get { return m_controllers; } }
    }
}
