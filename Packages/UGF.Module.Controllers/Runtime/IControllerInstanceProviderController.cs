namespace UGF.Module.Controllers.Runtime
{
    public interface IControllerInstanceProviderController : IController
    {
        T Build<T>(string id) where T : IController;
        IController Build(string id);
        bool TryBuild<T>(string id, out T controller) where T : IController;
        bool TryBuild(string id, out IController controller);
    }
}
