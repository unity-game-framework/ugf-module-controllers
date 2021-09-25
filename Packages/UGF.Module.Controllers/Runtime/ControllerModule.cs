using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.Initialize.Runtime;
using UGF.Logs.Runtime;
using UGF.RuntimeTools.Runtime.Providers;

namespace UGF.Module.Controllers.Runtime
{
    public class ControllerModule : ApplicationModule<ControllerModuleDescription>, IControllerModule, IApplicationModuleAsync, IApplicationLauncherEventHandler
    {
        public IProvider<string, IController> Provider { get; }
        public IInitializeCollection InitializeCollection { get; }

        IControllerModuleDescription IControllerModule.Description { get { return Description; } }

        public ControllerModule(ControllerModuleDescription description, IApplication application) : this(description, application, new Provider<string, IController>())
        {
        }

        public ControllerModule(ControllerModuleDescription description, IApplication application, IProvider<string, IController> provider) : base(description, application)
        {
            Provider = provider ?? throw new ArgumentNullException(nameof(provider));
            InitializeCollection = new InitializeCollection<IController>(Description.UseReverseUninitializationOrder);
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            Log.Debug("Controller module initialize", new
            {
                controllers = Description.Controllers.Count
            });

            foreach (KeyValuePair<string, IControllerBuilder> pair in Description.Controllers)
            {
                IController controller = pair.Value.Build(Application);

                Add(pair.Key, controller);
            }

            foreach (IControllerCollectionDescription collection in Description.Collections)
            {
                foreach (KeyValuePair<string, IControllerBuilder> pair in collection.Controllers)
                {
                    IController controller = pair.Value.Build(Application);

                    Add(pair.Key, controller);
                }
            }

            InitializeCollection.Initialize();
        }

        public async Task InitializeAsync()
        {
            for (int i = 0; i < InitializeCollection.Count; i++)
            {
                IInitialize initialize = InitializeCollection[i];

                if (initialize is IControllerAsyncInitialize initializeAsync)
                {
                    await initializeAsync.InitializeAsync();
                }
            }
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            Log.Debug("Controller module uninitialize", new
            {
                controllers = Provider.Entries.Count
            });

            InitializeCollection.Uninitialize();

            Provider.Clear();
            InitializeCollection.Clear();
        }

        public void Add(string id, IController controller)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));
            if (controller == null) throw new ArgumentNullException(nameof(controller));

            Provider.Add(id, controller);
            InitializeCollection.Add(controller);
        }

        public bool Remove(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));

            if (Provider.TryGet(id, out IController controller))
            {
                Provider.Remove(id);
                InitializeCollection.Remove(controller);
                return true;
            }

            return false;
        }

        void IApplicationLauncherEventHandler.OnLaunched(IApplication application)
        {
            foreach (KeyValuePair<string, IController> pair in Provider.Entries)
            {
                if (pair.Value is IApplicationLauncherEventHandler handler)
                {
                    handler.OnLaunched(application);
                }
            }
        }

        void IApplicationLauncherEventHandler.OnStopped(IApplication application)
        {
            foreach (KeyValuePair<string, IController> pair in Provider.Entries)
            {
                if (pair.Value is IApplicationLauncherEventHandler handler)
                {
                    handler.OnStopped(application);
                }
            }
        }
    }
}
