using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UGF.Application.Runtime;

namespace UGF.Module.Controllers.Runtime
{
    public class ControllerCollectionController : ControllerDescribedAsync<ControllerCollectionControllerDescription>
    {
        public ControllerCollection<IController> Controllers { get; } = new ControllerCollection<IController>();

        private readonly Dictionary<string, List<string>> m_fileIds = new Dictionary<string, List<string>>();

        public ControllerCollectionController(ControllerCollectionControllerDescription description, IApplication application) : base(description, application)
        {
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            foreach ((string key, IControllerBuilder value) in Description.Controllers)
            {
                IController controller = value.Build(Application);

                Controllers.Add(key, controller);
                Application.AddController(key, controller);
            }

            foreach ((string key, string value) in Description.FileIds)
            {
                if (!m_fileIds.TryGetValue(value, out List<string> ids))
                {
                    ids = new List<string>();

                    m_fileIds.Add(value, ids);
                }

                ids.Add(key);
            }

            Controllers.Initialize();
        }

        protected override async Task OnInitializeAsync()
        {
            await base.OnInitializeAsync();

            foreach ((_, IController value) in Controllers)
            {
                if (value is IControllerAsyncInitialize controller)
                {
                    await controller.InitializeAsync();
                }
            }
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            Controllers.Uninitialize();

            foreach ((string key, _) in Controllers)
            {
                Application.RemoveController(key);
            }

            Controllers.Clear();

            m_fileIds.Clear();
        }

        public T Get<T>(string id) where T : class, IController
        {
            return (T)Get(id);
        }

        public IController Get(string id)
        {
            return TryGet(id, out IController controller) ? controller : throw new ArgumentException($"Controller not found by the specified id: '{id}'.");
        }

        public bool TryGet<T>(string id, out T controller) where T : class, IController
        {
            if (TryGet(id, out IController value))
            {
                controller = (T)value;
                return true;
            }

            controller = default;
            return false;
        }

        public bool TryGet(string id, out IController controller)
        {
            return Controllers.TryGet(id, out controller) || TryGetByFileId(id, out controller);
        }

        public T GetByFileId<T>(string id) where T : class, IController
        {
            return (T)GetByFileId(id);
        }

        public IController GetByFileId(string id)
        {
            return TryGetByFileId(id, out IController controller) ? controller : throw new ArgumentException($"Controller not found by the specified file id: '{id}'.");
        }

        public bool TryGetByFileId<T>(string id, out T controller) where T : class, IController
        {
            if (TryGetByFileId(id, out IController value))
            {
                controller = (T)value;
                return true;
            }

            controller = default;
            return false;
        }

        public bool TryGetByFileId(string id, out IController controller)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));

            if (m_fileIds.TryGetValue(id, out List<string> ids) && ids.Count > 0)
            {
                controller = Application.GetController(ids[0]);
                return true;
            }

            controller = default;
            return false;
        }

        public bool TryGetByFileId(string id, ICollection<IController> controllers)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));
            if (controllers == null) throw new ArgumentNullException(nameof(controllers));

            if (m_fileIds.TryGetValue(id, out List<string> ids) && ids.Count > 0)
            {
                for (int i = 0; i < ids.Count; i++)
                {
                    IController controller = Application.GetController(ids[i]);

                    controllers.Add(controller);
                }

                return true;
            }

            return false;
        }
    }
}
