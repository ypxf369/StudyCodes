using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    public interface IDelivery
    {
        string ID { get; set; }
        string OrderID { get; set; }
        string OrderUserID { get; set; }
        DateTime CreatedTime { get; set; }
        DateTime UpdatedTime { get; set; }
    }
}
