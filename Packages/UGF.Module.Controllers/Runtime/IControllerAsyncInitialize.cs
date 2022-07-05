using System.Threading.Tasks;

namespace UGF.Module.Controllers.Runtime
{
    public interface IControllerAsyncInitialize
    {
        bool IsInitializedAsync { get; }

        Task InitializeAsync();
    }
}
