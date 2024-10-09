using System;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "PowerUp", fileName = "PowerUp")]
public class PowerUp : ScriptableObject, IVisitor
{
    public int healthBonus = 10;
    public int manaBonus = 20;
    
    public void Visit(HealthComponent healthComponent)
    {
        healthComponent.health += healthBonus;
        Debug.Log("PowerUp.Visit(HealthComponent)");
    }

    public void Visit(ManaComponent manaComponent)
    {
        manaComponent.mana += manaBonus;
        Debug.Log("PowerUp.Visit(ManaComponent)");
    }
}