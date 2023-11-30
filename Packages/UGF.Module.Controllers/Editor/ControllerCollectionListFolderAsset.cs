using System.Collections.Generic;
using UGF.Assets.Editor;
using UGF.EditorTools.Runtime.Assets;
using UGF.Module.Controllers.Runtime;
using UnityEngine;

namespace UGF.Module.Controllers.Editor
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Controllers/Controller Collection List Folder", order = 2000)]
    public class ControllerCollectionListFolderAsset : AssetFolderIdReferenceCollectionAsset<ControllerCollectionListAsset, ControllerAsset>
    {
        protected override IList<AssetIdReference<ControllerAsset>> OnGetCollection()
        {
            return Collection.Controllers;
        }
    }
}
