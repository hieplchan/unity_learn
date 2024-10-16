using UnityEngine;
using UnityEngine.Serialization;

namespace StatsAndModifiers
{
    public abstract class BaseModifierPickup : MonoBehaviour, IVisitor
    {
        protected abstract void ApplyPickupEffect(Entity entity);
        
        public void Visit<T>(T visitable) where T : Component, IVisitable
        {
            if (visitable is Entity entity)
            {
                ApplyPickupEffect(entity);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            other.GetComponent<IVisitable>()?.Accept(this);
            Destroy(gameObject);
        }
    }
}