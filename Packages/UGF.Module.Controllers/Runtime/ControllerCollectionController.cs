using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.FileIds;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Controllers.Runtime
{
    public class ControllerCollectionController : ControllerDescribedAsync<ControllerCollectionControllerDescription>
    {
        public ControllerCollection<IController> Controllers { get; } = new ControllerCollection<IController>();

        private readonly Dictionary<FileId, List<GlobalId>> m_fileIds = new Dictionary<FileId, List<GlobalId>>();

        public ControllerCollectionController(ControllerCollectionControllerDescription description, IApplication application) : base(description, application)
        {
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            foreach ((GlobalId key, IControllerBuilder value) in Description.Controllers)
            {
                IController controller = value.Build(Application);

                Controllers.Add(key, controller);
                Application.AddController(key, controller);
            }

            foreach ((GlobalId key, FileId value) in Description.FileIds)
            {
                if (!m_fileIds.TryGetValue(value, out List<GlobalId> ids))
                {
                    ids = new List<GlobalId>();

                    m_fileIds.Add(value, ids);
                }

                ids.Add(key);
            }

            Controllers.Initialize();
        }

        protected override async Task OnInitializeAsync()
        {
            await base.OnInitializeAsync();
            await Controllers.InitializeAsync();
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

        public T Get<T>(GlobalId id) where T : class, IController
        {
            return (T)Get(id);
        }

        public IController Get(GlobalId id)
        {
            return TryGet(id, out IController controller) ? controller : throw new ArgumentException($"Controller not found by the specified id: '{id}'.");
        }

        public bool TryGet<T>(GlobalId id, out T controller) where T : class, IController
        {
            if (TryGet(id, out IController value))
            {
                controller = (T)value;
                return true;
            }

            controller = default;
            return false;
        }

        public bool TryGet(GlobalId id, out IController controller)
        {
            return Controllers.TryGet(id, out controller);
        }

        public T Get<T>(FileId id) where T : class, IController
        {
            return (T)Get(id);
        }

        public IController Get(FileId id)
        {
            return TryGet(id, out IController controller) ? controller : throw new ArgumentException($"Controller not found by the specified file id: '{id}'.");
        }

        public bool TryGet<T>(FileId id, out T controller) where T : class, IController
        {
            if (TryGet(id, out IController value))
            {
                controller = (T)value;
                return true;
            }

            controller = default;
            return false;
        }

        public bool TryGet(FileId id, out IController controller)
        {
            if (!id.IsValid()) throw new ArgumentException("Value should be valid.", nameof(id));

            if (m_fileIds.TryGetValue(id, out List<GlobalId> ids) && ids.Count > 0)
            {
                controller = Application.GetController(ids[0]);
                return true;
            }

            controller = default;
            return false;
        }

        public bool TryGet(FileId id, ICollection<IController> controllers)
        {
            if (!id.IsValid()) throw new ArgumentException("Value should be valid.", nameof(id));
            if (controllers == null) throw new ArgumentNullException(nameof(controllers));

            if (m_fileIds.TryGetValue(id, out List<GlobalId> ids) && ids.Count > 0)
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
