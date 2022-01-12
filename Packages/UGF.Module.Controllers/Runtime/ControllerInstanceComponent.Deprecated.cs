using System;

namespace UGF.Module.Controllers.Runtime
{
    public partial class ControllerInstanceComponent
    {
        [Obsolete("BuildUnique has been deprecated. Use BuildAsSingleton property instead.")]
        public bool BuildUnique { get { return !m_buildAsSingleton; } set { m_buildAsSingleton = !value; } }
    }
}
