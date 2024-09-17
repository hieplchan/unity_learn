using UnityEngine;

namespace Harvestable
{
    [CreateAssetMenu(menuName = "Harvestable/ResourceConfig", fileName = "ResourceConfig")]
    public class ResourceConfig : ScriptableObject
    {
        public ResourceType ResourceType;
        public int Amount;

        public Resource Generate()
        {
            return new Resource()
            {
                ResourceType = ResourceType,
                Amount = Amount
            };
        }
    }
}