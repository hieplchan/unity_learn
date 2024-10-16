using System;

namespace StatsAndModifiers
{
    public class BasicStatModifier : StatModifier
    {
        private readonly StatType _statType;
        private readonly Func<int, int> _operation;
        
        public BasicStatModifier(float duration, StatType statType, Func<int, int> operation) : base(duration)
        {
            _statType = statType;
            _operation = operation;
        }

        public override void Handle(object sender, Query query)
        {
            if (query.StatType == _statType)
            {
                query.Value = _operation(query.Value);
            }
        }
    }
    
    public abstract class StatModifier : IDisposable
    {
        public bool MarkedForRemoval { get; set; }
        public event Action<StatModifier> OnDispose = delegate { }; 
        public abstract void Handle(object sender, Query query);
        private readonly CountdownTimer _timer;

        protected StatModifier(float duration)
        {
            if (duration <= 0) return; // equip forever

            _timer = new CountdownTimer(duration);
            _timer.OnTimerStop += () => MarkedForRemoval = true;
            _timer.Start();
        }

        public void Update(float deltaTime) => _timer?.Tick(deltaTime);
        
        public void Dispose()
        {
            OnDispose.Invoke(this);
        }
    }
}