using UGF.Application.Runtime;
using UGF.Initialize.Runtime;
using UnityEngine;

namespace UGF.Module.Controllers.Runtime.Tests
{
    [CreateAssetMenu(menuName = "Tests/TestControllerAsset")]
    public class TestControllerAsset : ControllerAsset<TestController>
    {
        protected override TestController OnBuild(ControllerDescription description, IApplication application)
        {
            return new TestController(description, application);
        }
    }

    public class TestController : Controller<ControllerDescription>
    {
        public TestController(ControllerDescription description, IApplication application) : base(description, application)
        {
        }
    }
}
