using System;
using UnityEngine;

namespace StatsAndModifiers
{
    public class StatModifierPickup : BaseModifierPickup
    {
        public enum OperatorType { Add, Multiply }

        [SerializeField] private StatType statType = StatType.Attack;
        [SerializeField] private OperatorType operatorType = OperatorType.Add;
        [SerializeField] private int value = 10;
        [SerializeField] private float duration = 5f;

        protected override void ApplyPickupEffect(Entity entity)
        {
            StatModifier statModifier = operatorType switch
            {
                OperatorType.Add => new BasicStatModifier(duration, statType, v => v + value),
                OperatorType.Multiply => new BasicStatModifier(duration, statType, v => v * value),
                _ => throw new ArgumentOutOfRangeException()
            };
            
            entity.Stats.Mediator.AddModifier(statModifier);
        }
    }
}