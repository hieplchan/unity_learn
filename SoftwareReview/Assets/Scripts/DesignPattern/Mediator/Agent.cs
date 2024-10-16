using System;
using UnityEngine;
using UnityServiceLocator;

namespace Mediator
{
    public enum AgentStatus
    {
        Active,
        Rest
    }
    public class Agent : MonoBehaviour, IVisitable
    {
        private Mediator<Agent> _mediator;
        public AgentStatus Status { get; set; }

        private void Start()
        {
            ServiceLocator.For(this).Get<Mediator<Agent>>(out _mediator);
            _mediator.Register(this);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Send(new MessagePayload.Builder(this).WithContent("Hello").Build(), IsNearby);
            }
        }

        private void Send(IVisitor message) => _mediator.Broadcast(this, message);

        private void Send(IVisitor message, Func<Agent, bool> predicate) =>
            _mediator.Broadcast(this, message, predicate);

        private const float k_radius = 5f;
        private Func<Agent, bool> IsNearby => target =>
            Vector3.Distance(transform.position, target.transform.position) <= k_radius; 

        private void OnDestroy() => _mediator.Deregister(this);
        public void Accept(IVisitor message) => message.Visit(this);
    }
}