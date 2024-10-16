using UnityEngine;
using UnityServiceLocator;

namespace Mediator
{
    public class AgentMediator : Mediator<Agent>
    {
        private void Awake() => ServiceLocator.Global.Register(this as Mediator<Agent>);

        protected override bool MediatorConditionMet(Agent target) => target.Status == AgentStatus.Active;
        
        protected override void OnRegistered(Agent entity)
        {
            Debug.Log($"AgentMediator.OnRegistered {entity.name}");
            Broadcast(entity, new MessagePayload.Builder(entity).WithContent("Registered").Build());
        }

        protected override void OnDeregistered(Agent entity)
        {
            Debug.Log($"AgentMediator.OnDeregistered {entity.name}");
            Broadcast(entity, new MessagePayload.Builder(entity).WithContent("Deregistered").Build());
        }
        
        // Add additional logic here
    }
}