using System;
using System.Collections.Generic;
using System.Text;

namespace EventBus.Core
{
    public sealed class ActionDelegatedEventHandler<TEvent> : IEventHandler<TEvent> where TEvent : IEvent
    {
        private readonly Action<TEvent> _action;

        public ActionDelegatedEventHandler(Action<TEvent> action)
        {
            _action = action;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (!(obj is ActionDelegatedEventHandler<TEvent> other))
                return false;
            return Delegate.Equals(this._action, other._action);
        }

        public void Handle(TEvent evt)
        {
            _action(evt);
        }
    }
}
