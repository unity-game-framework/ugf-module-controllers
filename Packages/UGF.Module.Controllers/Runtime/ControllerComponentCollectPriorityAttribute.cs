using System;

namespace UGF.Module.Controllers.Runtime
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ControllerComponentCollectPriorityAttribute : Attribute
    {
        public int Priority { get; }

        public ControllerComponentCollectPriorityAttribute(int priority = 0)
        {
            Priority = priority;
        }
    }
}
