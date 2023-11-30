using System;
using System.Collections.Generic;
using UGF.EditorTools.Runtime.Ids;
using UnityEngine;

namespace UGF.Module.Controllers.Runtime
{
    public abstract class ControllerIdCollectionAsset : ScriptableObject
    {
        public void GetControllers(ICollection<GlobalId> controllers)
        {
            if (controllers == null) throw new ArgumentNullException(nameof(controllers));

            OnGetControllers(controllers);
        }

        protected abstract void OnGetControllers(ICollection<GlobalId> controllers);
    }
}
