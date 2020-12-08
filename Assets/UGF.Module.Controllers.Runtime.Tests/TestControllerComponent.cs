using UGF.Application.Runtime;

namespace UGF.Module.Controllers.Runtime.Tests
{
    public class TestControllerComponent : ControllerComponent<TestController>
    {
        protected override TestController OnBuild(ControllerDescription description, IApplication application)
        {
            return new TestController(description, application);
        }
    }
}
