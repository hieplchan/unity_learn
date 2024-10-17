using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Flyweight
{
    public class Projectile : Flyweight
    {
        new ProjectileSettings settings => (ProjectileSettings) base.settings;
        private void Awake()
        {
            DespawnAfterDelay(settings.despawnDelay).Forget();
        }

        private void Update()
        {
            transform.Translate(Vector3.forward * (settings.speed * Time.deltaTime));
        }

        async UniTaskVoid DespawnAfterDelay(float delay)
        {
            await UniTask.Delay((int) delay * 1000);
            FlyweightFactory.ReturnToPool(this);
        }
    }
}