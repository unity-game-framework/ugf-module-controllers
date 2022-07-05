using System;
using Object = UnityEngine.Object;

namespace UGF.Module.Controllers.Runtime
{
    public static class ControllerUtility
    {
        public static string GetId(Object target)
        {
            if (target == null) throw new ArgumentNullException(nameof(target));

            uint id = (uint)target.GetInstanceID();

            return id.ToString("x8");
        }
    }
}
