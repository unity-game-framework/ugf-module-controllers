using System;
using System.Collections.Generic;
using UGF.EditorTools.Runtime.Ids;
using UnityEngine;

namespace UGF.Module.Controllers.Runtime
{
    public abstract class ControllerCollectionAsset : ScriptableObject
    {
        public void GetControllers(IDictionary<GlobalId, IControllerBuilder> controllers)
        {
            if (controllers == null) throw new ArgumentNullException(nameof(controllers));

            OnGetControllers(controllers);
        }

        protected abstract void OnGetControllers(IDictionary<GlobalId, IControllerBuilder> controllers);
    }
}
