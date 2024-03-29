﻿using System;
using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.ComponentReferences;
using UGF.EditorTools.Runtime.Ids;
using UnityEngine;

namespace UGF.Module.Controllers.Runtime
{
    [AddComponentMenu("Unity Game Framework/Controllers/Controller Collection Controller", 2000)]
    public class ControllerCollectionControllerComponent : ControllerDescribedComponent<ControllerCollectionController, ControllerCollectionControllerDescription>
    {
        [SerializeField] private bool m_combine = true;
        [SerializeField] private List<ComponentIdReference<ControllerComponent>> m_controllers = new List<ComponentIdReference<ControllerComponent>>();

        public bool Combine { get { return m_combine; } set { m_combine = value; } }
        public List<ComponentIdReference<ControllerComponent>> Controllers { get { return m_controllers; } }

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
                    ComponentIdReference<ControllerComponent> reference = m_controllers[i];
                    GlobalId id = reference.Component.GetControllerId();

                    description.Controllers.Add(id, reference.Component);
                    description.FileIds.Add(id, reference.FileId);
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
                ComponentIdReference<ControllerComponent> reference = component.Controllers[i];

                if (reference.Component is ControllerCollectionControllerComponent collection)
                {
                    Collect(description, collection);
                }
                else
                {
                    GlobalId id = reference.Component.GetControllerId();

                    description.Controllers.Add(id, reference.Component);
                    description.FileIds.Add(id, reference.FileId);
                }
            }
        }
    }
}
