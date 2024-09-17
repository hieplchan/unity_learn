using System;
using UnityEngine;

namespace Harvestable
{
    public enum ResourceType { Empty, Stone, Iron, Gold }

    public class BaseNode : MonoBehaviour
    {
        public ResourceConfig ResourceConfig;
        public ResourceConfig SpecialResourceConfig;

        private Resource _baseResource;
        private Resource _specialResource;

        private void Awake()
        {
            _baseResource = ResourceConfig.Generate();
            _specialResource = SpecialResourceConfig.Generate();
        }

        public (Resource baseResource, Resource specialResource) Gather() => (_baseResource, _specialResource);
    }

    public class Resource
    {
        public ResourceType ResourceType;
        public int Amount;
    }
}