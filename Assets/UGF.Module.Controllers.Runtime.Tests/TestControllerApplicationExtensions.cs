using NUnit.Framework;
using UGF.Application.Runtime;
using UnityEngine;

namespace UGF.Module.Controllers.Runtime.Tests
{
    public class TestControllerApplicationExtensions
    {
        [Test]
        public void InitializeAndUninitialize()
        {
            IApplication application = CreateApplication();

            application.Initialize();

            var controller = application.GetController<TestController>();

            Assert.NotNull(controller);

            application.Uninitialize();
        }

        private IApplication CreateApplication()
        {
            return new ApplicationConfigured(new ApplicationResources
            {
                new ApplicationConfig
                {
                    Modules =
                    {
                        (IApplicationModuleBuilder)Resources.Load("Module", typeof(IApplicationModuleBuilder))
                    }
                }
            });
        }
    }
}
