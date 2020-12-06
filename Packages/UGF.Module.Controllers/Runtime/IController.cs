using UGF.Application.Runtime;
using UGF.Description.Runtime;
using UGF.Initialize.Runtime;

namespace UGF.Module.Controllers.Runtime
{
    public interface IController : IInitialize, IDescribed
    {
        IApplication Application { get; }
    }
}
