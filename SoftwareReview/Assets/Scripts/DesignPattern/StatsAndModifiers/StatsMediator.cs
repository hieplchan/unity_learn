using System;
using System.Collections.Generic;

namespace StatsAndModifiers
{
    public class StatsMediator
    {
        private readonly LinkedList<StatModifier> _modifiers = new LinkedList<StatModifier>();

        public event EventHandler<Query> Queries;
        public void PerformQuery(object sender, Query query) => Queries?.Invoke(sender, query);

        public void AddModifier(StatModifier modifier)
        {
            _modifiers.AddLast(modifier);
            Queries += modifier.Handle;

            modifier.OnDispose += (statModifier =>
            {
                _modifiers.Remove(statModifier);
                Queries -= modifier.Handle;
            });
        }
        
        public void Update(float deltaTime)
        {   
            // update all modifier
            var node = _modifiers.First;
            while (node != null)
            {
                var modifier = node.Value;
                modifier.Update(deltaTime);
                node = node.Next;
            }
            
            // dispose and remove finished modifiers
            node = _modifiers.First;
            while (node != null)
            {
                var nextNode = node.Next;

                if (node.Value.MarkedForRemoval)
                {
                    node.Value.Dispose();
                }

                node = nextNode;
            }
        }
    }

    public class Query
    {
        public readonly StatType StatType;
        public int Value;

        public Query(StatType statType, int value)
        {
            StatType = statType;
            Value = value;
        }
    }
}