using UGF.Application.Runtime;
using UGF.Initialize.Runtime;

namespace UGF.Module.Controllers.Runtime
{
    public interface IController : IInitialize
    {
        IApplication Application { get; }
    }
}
