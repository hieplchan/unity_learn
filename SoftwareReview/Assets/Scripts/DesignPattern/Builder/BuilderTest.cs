using System;
using UnityEngine;

public class BuilderTest : MonoBehaviour
{
    private void Start()
    {
        Enemy enemy = new Enemy.Builder()
            .WithName("Goblin")
            .WithHealth(100)
            .WithSpeed(5)   
            .WithDamage(10)
            .WithIsBoss(true)
            .Build();
        enemy.gameObject.transform.SetParent(transform);
    }
}