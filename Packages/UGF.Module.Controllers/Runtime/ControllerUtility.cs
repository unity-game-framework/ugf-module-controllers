using System;
using UGF.EditorTools.Runtime.Ids;
using Object = UnityEngine.Object;

namespace UGF.Module.Controllers.Runtime
{
    public static class ControllerUtility
    {
        public static GlobalId GetId(Object target)
        {
            if (target == null) throw new ArgumentNullException(nameof(target));

            return new GlobalId((ulong)target.GetInstanceID());
        }
    }
}
