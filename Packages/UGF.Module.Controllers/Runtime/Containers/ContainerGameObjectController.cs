using System;
using UGF.Application.Runtime;
using UGF.RuntimeTools.Runtime.Containers;
using UnityEngine;

namespace UGF.Module.Controllers.Runtime.Containers
{
    public class ContainerGameObjectController : ContainerComponentController
    {
        public GameObject GameObject { get; }

        public ContainerGameObjectController(IApplication application, GameObject gameObject) : base(application)
        {
            GameObject = gameObject ? gameObject : throw new ArgumentNullException(nameof(gameObject));
        }

        protected override ContainerComponent OnGetContainer()
        {
            return GameObject.GetComponent<ContainerComponent>();
        }
    }
}
