﻿using System;
using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Assets;
using UnityEngine;

namespace UGF.Module.Controllers.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Controllers/Controller Collection Controller", order = 2000)]
    public class ControllerCollectionControllerAsset : ControllerDescribedAsset<ControllerCollectionController, ControllerCollectionControllerDescription>
    {
        [SerializeField] private bool m_combine = true;
        [SerializeField] private List<AssetIdReference<ControllerAsset>> m_controllers = new List<AssetIdReference<ControllerAsset>>();

        public bool Combine { get { return m_combine; } set { m_combine = value; } }
        public List<AssetIdReference<ControllerAsset>> Controllers { get { return m_controllers; } }

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
                    AssetIdReference<ControllerAsset> reference = m_controllers[i];

                    description.Controllers.Add(reference.Guid, reference.Asset);
                }
            }

            return description;
        }

        protected override ControllerCollectionController OnBuild(ControllerCollectionControllerDescription description, IApplication application)
        {
            return new ControllerCollectionController(description, application);
        }

        private static void Collect(ControllerCollectionControllerDescription description, ControllerCollectionControllerAsset asset)
        {
            if (description == null) throw new ArgumentNullException(nameof(description));
            if (asset == null) throw new ArgumentNullException(nameof(asset));

            for (int i = 0; i < asset.Controllers.Count; i++)
            {
                AssetIdReference<ControllerAsset> reference = asset.Controllers[i];

                if (reference.Asset is ControllerCollectionControllerAsset collection)
                {
                    Collect(description, collection);
                }
                else
                {
                    description.Controllers.Add(reference.Guid, reference.Asset);
                }
            }
        }
    }
}
