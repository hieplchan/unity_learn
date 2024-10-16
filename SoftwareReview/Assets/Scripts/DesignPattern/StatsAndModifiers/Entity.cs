using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace StatsAndModifiers
{
    public class Entity: MonoBehaviour, IVisitable
    {
        [SerializeField, InlineEditor, Required] private BaseStats baseStats; 
        
        public Stats Stats { get; private set; }

        private void Awake()
        {
            Stats = new Stats(baseStats, new StatsMediator());
        }

        private void Update()
        {
            Stats.Mediator.Update(Time.deltaTime);
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void Equip(IEquiptable equiptable)
        {
            Stats.Mediator.AddModifier(equiptable.GetStatModifier());
        }

        public void Remove(IEquiptable equiptable)
        {
            equiptable.GetStatModifier().MarkedForRemoval = true;
        }
        
#if UNITY_EDITOR
        [Button(ButtonSizes.Large)]
        void CheckStats() => Debug.Log(Stats);
#endif
    }
    
    public interface IEquiptable
    {
        StatModifier GetStatModifier(); 
    }
    
    public class SwordPlusOne : IEquiptable
    {
        private StatModifier _swordModifier = new BasicStatModifier(10, StatType.Attack, x => x + 1);

        public StatModifier GetStatModifier() => _swordModifier;
    }
}