using System;
using UnityEngine;
using Utilities;

namespace UnityServiceLocator
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(ServiceLocator))]
    public abstract class Bootstrapper : MonoBehaviour
    {
        ServiceLocator _container;
        internal ServiceLocator Container => _container.OrNull() ?? (_container = GetComponent<ServiceLocator>());

        private bool _hasBeenBootstrapped;

        private void Awake() => BootstrapOnDemand();

        public void BootstrapOnDemand()
        {
            if (_hasBeenBootstrapped) return;

            _hasBeenBootstrapped = true;
            Bootstrap();
        }

        protected abstract void Bootstrap();
    }
}