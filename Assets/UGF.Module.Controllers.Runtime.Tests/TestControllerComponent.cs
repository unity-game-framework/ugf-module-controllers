using UGF.Application.Runtime;

namespace UGF.Module.Controllers.Runtime.Tests
{
    [ControllerComponentCollectPriority(-1)]
    public class TestControllerComponent : ControllerComponent
    {
        protected override IController OnBuild(IApplication arguments)
        {
            return new TestController(arguments);
        }
    }
}
