using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventBus.Core
{
    public class EventBus
    {
        /// <summary>
        /// 事件总线对象
        /// </summary>
        private static EventBus _eventBus;

        private static readonly Dictionary<Type, List<object>> DicEventHandler = new Dictionary<Type, List<object>>();

        private static readonly object SyncObject = new object();

        public static EventBus Instance
        {
            get
            {
                if (_eventBus == null)
                {
                    lock (SyncObject)
                    {
                        if (_eventBus == null)
                            _eventBus = new EventBus();
                    }
                }
                return _eventBus;
            }
        }

        private readonly Func<object, object, bool> _eventHandlerEquals = (o1, o2) =>
        {
            var o1Type = o1.GetType();
            var o2Type = o2.GetType();
            return o1Type == o2Type;
        };

        public void Subscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent
        {
            lock (SyncObject)
            {
                var eventType = typeof(TEvent);
                //如果此类型在时间总线中已注册过
                if (DicEventHandler.ContainsKey(eventType))
                {
                    var handlers = DicEventHandler[eventType];
                    if (handlers != null)
                    {
                        handlers.Add(eventHandler);
                    }
                    else
                    {
                        handlers = new List<object>
                        {
                            eventHandler
                        };
                    }
                }
                else
                {
                    DicEventHandler.Add(eventType, new List<object>() { eventHandler });
                }
            }
        }

        public void Subscribe<TEvent>(Action<TEvent> eventHandlerAction) where TEvent : IEvent
        {
            Subscribe(new ActionDelegatedEventHandler<TEvent>(eventHandlerAction));
        }

        public void Subscribe<TEvent>(IEnumerable<IEventHandler<TEvent>> eventHandlers) where TEvent : IEvent
        {
            foreach (var eventHandler in eventHandlers)
            {
                Subscribe(eventHandler);
            }
        }

        public void Publish<TEvent>(TEvent evt, Action<TEvent, bool, Exception> callback) where TEvent : IEvent
        {
            var eventType = typeof(TEvent);
            if (DicEventHandler.ContainsKey(eventType) && DicEventHandler[eventType] != null && DicEventHandler[eventType].Count > 0)
            {
                var handlers = DicEventHandler[eventType];
                try
                {
                    foreach (var handler in handlers)
                    {
                        var eventHandler = handler as IEventHandler<TEvent>;
                        eventHandler?.Handle(evt);
                        callback(evt, true, null);
                    }
                }
                catch (Exception ex)
                {
                    callback(evt, false, ex);
                }
            }
            else
            {
                callback(evt, false, null);
            }
        }

        public void UnSubscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent
        {
            lock (SyncObject)
            {
                var eventType = typeof(TEvent);
                if (DicEventHandler.ContainsKey(eventType))
                {
                    var handlers = DicEventHandler[eventType];
                    if (handlers != null && handlers.Exists(i => _eventHandlerEquals(i, eventHandler)))
                    {
                        var handler = handlers.First(i => _eventHandlerEquals(i, eventHandler));
                        handlers.Remove(handler);
                        handlers.Remove(handler);
                    }
                }
            }
        }
    }
}
