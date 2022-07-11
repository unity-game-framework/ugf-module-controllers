using NUnit.Framework;
using UGF.Application.Runtime;
using UnityEngine;

namespace UGF.Module.Controllers.Runtime.Tests
{
    public class TestControllerModule
    {
        [Test]
        public void InitializeAndUninitialize()
        {
            IApplication application = CreateApplication();

            application.Initialize();

            var module = application.GetModule<IControllerModule>();

            Assert.NotNull(module);
            Assert.True(module.Controllers.Entries.ContainsKey("0cecb78aa3f74e24795a355a78af8962"));

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
