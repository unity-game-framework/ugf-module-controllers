using System.Collections.Generic;
using UGF.Application.Runtime;
using UnityEngine;

namespace UGF.Module.Controllers.Runtime
{
    [AddComponentMenu("Unity Game Framework/Controllers/Controller Collection Controller", 2000)]
    public class ControllerCollectionControllerComponent : ControllerDescribedComponent<ControllerCollectionController, ControllerCollectionControllerDescription>
    {
        [SerializeField] private List<ControllerComponent> m_controllers = new List<ControllerComponent>();

        public List<ControllerComponent> Controllers { get { return m_controllers; } set { m_controllers = value; } }

        protected override ControllerCollectionControllerDescription OnBuildDescription()
        {
            var description = new ControllerCollectionControllerDescription();

            for (int i = 0; i < m_controllers.Count; i++)
            {
                ControllerComponent component = m_controllers[i];
                string id = component.GetControllerId();

                description.Controllers.Add(id, component);
            }

            return description;
        }

        protected override ControllerCollectionController OnBuild(ControllerCollectionControllerDescription description, IApplication application)
        {
            return new ControllerCollectionController(description, application);
        }
    }
}
