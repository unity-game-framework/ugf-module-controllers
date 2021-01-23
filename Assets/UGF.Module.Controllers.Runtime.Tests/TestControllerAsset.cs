using UGF.Application.Runtime;
using UGF.Initialize.Runtime;
using UnityEngine;

namespace UGF.Module.Controllers.Runtime.Tests
{
    [CreateAssetMenu(menuName = "Tests/TestControllerAsset")]
    public class TestControllerAsset : ControllerAsset
    {
        protected override IController OnBuild(IApplication arguments)
        {
            return new TestController(arguments);
        }
    }

    public class TestController : ControllerBase
    {
        public TestController(IApplication application) : base(application)
        {
        }
    }
}
