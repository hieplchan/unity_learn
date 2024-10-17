using UnityEngine;
using UnityEngine.Serialization;

namespace Flyweight
{
    public enum FlyweightType { Fire, Ice}
    
    [CreateAssetMenu(menuName = "Flyweight/Settings", fileName = "FlyweightSettings", order = 0)]
    public class FlyweightSettings : ScriptableObject
    {
        public FlyweightType type;
        public GameObject prefab;

        public virtual Flyweight Create()
        {
            var go = Instantiate(prefab);
            go.SetActive(false);
            go.name = prefab.name;

            var flyweight = go.AddComponent<Flyweight>();
            flyweight.settings = this;

            return flyweight;
        }

        public virtual void OnGet(Flyweight obj) => obj.gameObject.SetActive(true);
        public virtual void OnRelease(Flyweight obj) => obj.gameObject.SetActive(false);
        public virtual void OnDestroyPoolObject(Flyweight obj) => Destroy(obj.gameObject);
    }
}