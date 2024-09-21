using UnityEngine;

namespace AbilitySystem
{
    public interface ICommand
    {
        void Execute();
    }
    
    public class AbilityCommand : ICommand
    {
        private AbilityData data;
        public float duration => data.duration;

        public AbilityCommand(AbilityData data)
        {
            this.data = data;
        }
        
        public void Execute()
        {
            // Public event with data.animationHash to message bus
            Debug.Log($"AbilityCommand Execute animationHash {data.animationHash}");
        }
    }
}