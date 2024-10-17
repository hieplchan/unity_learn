using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Flyweight
{
    public class HeroWithFlyweight : MonoBehaviour
    {
        [SerializeField] private List<ProjectileSettings> projectileSettings;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                var flyweight = FlyweightFactory.Spawn(projectileSettings[0]);
                flyweight.transform.position = transform.position;
                flyweight.transform.rotation = transform.rotation;
            }
            
            if (Input.GetKeyDown(KeyCode.V))
            {
                var flyweight = FlyweightFactory.Spawn(projectileSettings[1]);
                flyweight.transform.position = transform.position;
                flyweight.transform.rotation = transform.rotation;
            }
        }
    }
}