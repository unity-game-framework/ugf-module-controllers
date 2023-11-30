using System.Collections.Generic;
using UGF.Assets.Editor;
using UGF.EditorTools.Runtime.Ids;
using UGF.Module.Controllers.Runtime;
using UnityEngine;

namespace UGF.Module.Controllers.Editor
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Controllers/Controller Id Collection List Folder", order = 2000)]
    public class ControllerIdCollectionListFolderAsset : AssetFolderIdCollectionAsset<ControllerIdCollectionListAsset, ControllerAsset>
    {
        protected override IList<GlobalId> OnGetCollection()
        {
            return Collection.Controllers;
        }
    }
}
