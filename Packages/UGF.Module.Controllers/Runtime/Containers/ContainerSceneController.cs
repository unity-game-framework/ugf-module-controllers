using System;
using UGF.Application.Runtime;
using UGF.RuntimeTools.Runtime.Containers;
using UGF.RuntimeTools.Runtime.Scenes;
using UnityEngine.SceneManagement;

namespace UGF.Module.Controllers.Runtime.Containers
{
    public class ContainerSceneController : ContainerComponentController
    {
        public Scene Scene { get; }

        public ContainerSceneController(IApplication application, Scene scene) : base(application)
        {
            if (!scene.IsValid()) throw new ArgumentException("Value should be valid.", nameof(scene));

            Scene = scene;
        }

        protected override ContainerComponent OnGetContainer()
        {
            return Scene.GetComponent<ContainerComponent>();
        }
    }
}
