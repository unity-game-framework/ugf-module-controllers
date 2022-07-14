using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Controllers.Runtime
{
    public interface IControllerInstanceProviderController : IController
    {
        T Build<T>(GlobalId id) where T : IController;
        IController Build(GlobalId id);
        bool TryBuild<T>(GlobalId id, out T controller) where T : IController;
        bool TryBuild(GlobalId id, out IController controller);
    }
}
