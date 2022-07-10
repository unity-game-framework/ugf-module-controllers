using System;
using System.Collections.Generic;
using UGF.Application.Runtime;
using UnityEngine;

namespace UGF.Module.Controllers.Runtime
{
    [AddComponentMenu("Unity Game Framework/Controllers/Controller Collection Controller", 2000)]
    public class ControllerCollectionControllerComponent : ControllerDescribedComponent<ControllerCollectionController, ControllerCollectionControllerDescription>
    {
        [SerializeField] private bool m_combine = true;
        [SerializeField] private List<ControllerComponent> m_controllers = new List<ControllerComponent>();

        public bool Combine { get { return m_combine; } set { m_combine = value; } }
        public List<ControllerComponent> Controllers { get { return m_controllers; } set { m_controllers = value; } }

        protected override ControllerCollectionControllerDescription OnBuildDescription()
        {
            var description = new ControllerCollectionControllerDescription();

            if (m_combine)
            {
                Collect(description, this);
            }
            else
            {
                for (int i = 0; i < m_controllers.Count; i++)
                {
                    ControllerComponent controller = m_controllers[i];

                    description.Controllers.Add(controller.GetControllerId(), controller);
                }
            }

            return description;
        }

        protected override ControllerCollectionController OnBuild(ControllerCollectionControllerDescription description, IApplication application)
        {
            return new ControllerCollectionController(description, application);
        }

        private static void Collect(ControllerCollectionControllerDescription description, ControllerCollectionControllerComponent component)
        {
            if (description == null) throw new ArgumentNullException(nameof(description));
            if (component == null) throw new ArgumentNullException(nameof(component));

            for (int i = 0; i < component.Controllers.Count; i++)
            {
                ControllerComponent controller = component.Controllers[i];

                if (controller is ControllerCollectionControllerComponent collection)
                {
                    Collect(description, collection);
                }
                else
                {
                    description.Controllers.Add(controller.GetControllerId(), controller);
                }
            }
        }
    }
}
