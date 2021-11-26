using System;
using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.RuntimeTools.Runtime.Providers;

namespace UGF.Module.Controllers.Runtime
{
    public static class ControllerApplicationExtensions
    {
        public static void AddController(this IApplication application, string id, IController controller)
        {
            if (application == null) throw new ArgumentNullException(nameof(application));
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));
            if (controller == null) throw new ArgumentNullException(nameof(controller));

            application.GetModule<IControllerModule>().Provider.Add(id, controller);
        }

        public static bool RemoveController(this IApplication application, string id)
        {
            if (application == null) throw new ArgumentNullException(nameof(application));
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));

            return application.GetModule<IControllerModule>().Provider.Remove(id);
        }

        public static T GetController<T>(this IApplication application) where T : IController
        {
            if (application == null) throw new ArgumentNullException(nameof(application));

            IProvider<string, IController> provider = application.GetModule<IControllerModule>().Provider;

            if (provider is Provider<string, IController> providerRegular)
            {
                foreach (KeyValuePair<string, IController> pair in providerRegular)
                {
                    if (pair.Value is T controller)
                    {
                        return controller;
                    }
                }
            }
            else
            {
                foreach (KeyValuePair<string, IController> pair in provider.Entries)
                {
                    if (pair.Value is T controller)
                    {
                        return controller;
                    }
                }
            }

            throw new ArgumentException($"Controller not found by the specified type: '{typeof(T)}'.");
        }

        public static T GetController<T>(this IApplication application, string id) where T : IController
        {
            if (application == null) throw new ArgumentNullException(nameof(application));

            return application.GetModule<IControllerModule>().Provider.Get<T>(id);
        }

        public static IController GetController(this IApplication application, string id)
        {
            if (application == null) throw new ArgumentNullException(nameof(application));

            return application.GetModule<IControllerModule>().Provider.Get(id);
        }
    }
}
