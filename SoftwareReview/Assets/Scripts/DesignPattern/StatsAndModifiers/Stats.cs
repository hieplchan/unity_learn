using UnityEngine;

namespace StatsAndModifiers
{
    public enum StatType { Attack, Defense }
    
    public class Stats
    {
        private readonly BaseStats _baseStats;
        private readonly StatsMediator _statsMediator;

        public StatsMediator Mediator => _statsMediator;

        public Stats(BaseStats baseStats, StatsMediator statsMediator)
        {
            _baseStats = baseStats;
            _statsMediator = statsMediator;
        }

        public int Attack
        {
            get
            {
                var q = new Query(StatType.Attack, _baseStats.attack);
                _statsMediator.PerformQuery(this, q);
                return q.Value;
            }
        }

        public int Defense
        {
            get
            {
                var q = new Query(StatType.Defense, _baseStats.defense);
                _statsMediator.PerformQuery(this, q);
                return q.Value;
            }
        }

        public override string ToString() => $"Attack: {Attack}, Defense: {Defense}";
    }
}