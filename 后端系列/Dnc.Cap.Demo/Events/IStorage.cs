using System;
using System.Collections.Generic;
using System.Text;

namespace Events
{
    public interface IStorage
    {
        string ID { get; set; }
        int StorageNumber { get; set; }
        DateTime CreatedTime { get; set; }
        DateTime UpdatedTime { get; set; }
    }
}
