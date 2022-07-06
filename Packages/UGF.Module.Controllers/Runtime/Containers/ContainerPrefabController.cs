using System;
using UGF.Application.Runtime;
using UGF.RuntimeTools.Runtime.Containers;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UGF.Module.Controllers.Runtime.Containers
{
    public class ContainerPrefabController : ContainerComponentController
    {
        public GameObject Prefab { get; }
        public Transform Parent { get { return m_parent ? m_parent : throw new ArgumentException("Value not specified."); } }
        public bool HasParent { get { return m_parent != null; } }

        private readonly Transform m_parent;

        public ContainerPrefabController(IApplication application, GameObject prefab) : base(application)
        {
            Prefab = prefab ? prefab : throw new ArgumentNullException(nameof(prefab));
        }

        public ContainerPrefabController(IApplication application, GameObject prefab, Transform parent) : base(application)
        {
            Prefab = prefab ? prefab : throw new ArgumentNullException(nameof(prefab));

            m_parent = parent;
        }

        protected override ContainerComponent OnGetContainer()
        {
            return HasParent
                ? Object.Instantiate(Prefab, Parent).GetComponent<ContainerComponent>()
                : Object.Instantiate(Prefab).GetComponent<ContainerComponent>();
        }

        protected override void OnReleaseContainer()
        {
            base.OnReleaseContainer();

            Object.Destroy(Component.gameObject);
        }
    }
}
