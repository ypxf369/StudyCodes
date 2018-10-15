using System;
using System.Collections.Generic;
using System.Text;

namespace EventBus.Core
{
    public interface IEvent
    {
        Guid Id { get; set; }
    }
}
