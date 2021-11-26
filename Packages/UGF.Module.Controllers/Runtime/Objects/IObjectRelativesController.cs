using UGF.RuntimeTools.Runtime.Objects;

namespace UGF.Module.Controllers.Runtime.Objects
{
    public interface IObjectRelativesController : IController
    {
        IObjectRelativeProvider Provider { get; }
    }
}
