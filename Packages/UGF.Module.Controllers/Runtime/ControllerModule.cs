using System;
using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Controllers.Runtime
{
    public class ControllerModule : ApplicationModule<ControllerModuleDescription>, IControllerModule
    {
        public IControllerProvider Provider { get; }

        IControllerModuleDescription IControllerModule.Description { get { return Description; } }

        public ControllerModule(ControllerModuleDescription description, IApplication application) : this(description, application, new ControllerProvider())
        {
        }

        public ControllerModule(ControllerModuleDescription description, IApplication application, IControllerProvider provider) : base(description, application)
        {
            Provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            foreach (KeyValuePair<GlobalId, IControllerBuilder> pair in Description.Controllers)
            {
                IController controller = pair.Value.Build(Application);

                Provider.Add(pair.Key, controller);
            }

            Provider.Initialize();
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            Provider.Uninitialize();
            Provider.Clear();
        }
    }
}
