using System;
using UGF.Application.Runtime;
using UGF.RuntimeTools.Runtime.Containers;
using UGF.RuntimeTools.Runtime.Providers;
using Object = UnityEngine.Object;

namespace UGF.Module.Controllers.Runtime.Containers
{
    public class ContainerComponentController : ControllerBase
    {
        public ContainerComponent Container { get; }
        public IProvider<string, IController> Controllers { get { return m_controllers; } }

        private readonly ControllerCollection<IController> m_controllers = new ControllerCollection<IController>();

        public ContainerComponentController(IApplication application, ContainerComponent container) : base(application)
        {
            if (container == null) throw new ArgumentNullException(nameof(container));

            Container = container;
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            for (int i = 0; i < Container.Values.Count; i++)
            {
                Object component = Container.Values[i];

                if (component is ControllerComponent controllerComponent)
                {
                    string id = controllerComponent.GetControllerId();
                    IController controller = Application.GetController(id);

                    m_controllers.Add(id, controller);
                }
            }
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            m_controllers.Clear();
        }

        public T Get<T>() where T : class, IController
        {
            return m_controllers.Get<T>();
        }

        public IController Get(Type type)
        {
            return TryGet(type, out IController controller) ? controller : throw new ArgumentException($"Controller not found by the specified type: '{type}'.");
        }

        public bool TryGet<T>(out T controller) where T : class, IController
        {
            return m_controllers.TryGet(out controller);
        }

        public bool TryGet(Type type, out IController controller)
        {
            return m_controllers.TryGet(type, out controller);
        }
    }
}
