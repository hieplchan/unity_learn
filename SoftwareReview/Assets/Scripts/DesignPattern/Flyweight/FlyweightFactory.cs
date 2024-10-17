using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Flyweight
{
    public class FlyweightFactory : MonoBehaviour
    {
        private static FlyweightFactory _instance;
        private readonly Dictionary<FlyweightType, IObjectPool<Flyweight>> _pools = new();
        
        [SerializeField] private bool collectionCheck = true;
        [SerializeField] private int defaultCapacity = 10;
        [SerializeField] private int maxPoolSize = 100;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public static Flyweight Spawn(FlyweightSettings settings) => _instance.GetPoolFor(settings)?.Get();
        public static void ReturnToPool(Flyweight obj) => _instance.GetPoolFor(obj.settings)?.Release(obj);

        IObjectPool<Flyweight> GetPoolFor(FlyweightSettings settings)
        {
            IObjectPool<Flyweight> pool;

            if (_pools.TryGetValue(settings.type, out pool)) return pool;

            pool = new ObjectPool<Flyweight>(
                settings.Create,
                settings.OnGet,
                settings.OnRelease,
                settings.OnDestroyPoolObject,
                collectionCheck,
                defaultCapacity,
                maxPoolSize);
            _pools.Add(settings.type, pool);
            return pool;
        }
    }
}