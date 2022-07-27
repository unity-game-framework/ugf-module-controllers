using System.Collections.Generic;
using System.Reflection;

namespace UGF.Module.Controllers.Runtime
{
    public class ControllerComponentCollectPriorityComparer : IComparer<ControllerComponent>
    {
        public static ControllerComponentCollectPriorityComparer Default { get; } = new ControllerComponentCollectPriorityComparer();

        public int Compare(ControllerComponent first, ControllerComponent second)
        {
            if (ReferenceEquals(first, second)) return 0;
            if (ReferenceEquals(null, second)) return 1;
            if (ReferenceEquals(null, first)) return -1;

            int firstPriority = first.GetType().GetCustomAttribute<ControllerComponentCollectPriorityAttribute>()?.Priority ?? 0;
            int secondPriority = second.GetType().GetCustomAttribute<ControllerComponentCollectPriorityAttribute>()?.Priority ?? 0;

            return firstPriority.CompareTo(secondPriority);
        }
    }
}
