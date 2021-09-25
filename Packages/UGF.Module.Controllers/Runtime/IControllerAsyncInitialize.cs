using System.Threading.Tasks;

namespace UGF.Module.Controllers.Runtime
{
    public interface IControllerAsyncInitialize
    {
        Task InitializeAsync();
    }
}
