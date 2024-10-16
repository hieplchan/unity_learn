using UnityEngine;

namespace Mediator
{
    public abstract class Payload<TData> : Component, IVisitor
    {
        public abstract TData Content { get; set; }
        public abstract void Visit<T>(T visitable) where T : Component, IVisitable;
    }

    public class MessagePayload : Payload<string>
    {
        public Agent Source { get; set; }
        public override string Content { get; set; }
        
        private MessagePayload() {}
        
        public override void Visit<T>(T visitable)
        {
            Debug.Log($"{visitable.name} received message from {Source.name} : {Content}");
            // Execute logic on visitable here
        }

        public class Builder
        {
            private MessagePayload _payload = new MessagePayload();

            public Builder(Agent source) => _payload.Source = source;

            public Builder WithContent(string content)
            {
                _payload.Content = content;
                return this;
            }

            public MessagePayload Build() => _payload;
        }
    }
}