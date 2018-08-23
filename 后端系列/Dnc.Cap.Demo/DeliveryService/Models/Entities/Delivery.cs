using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Events;

namespace DeliveryService.Models.Entities
{
    [Table("Deliveries")]
    public class Delivery : IDelivery
    {
        [Column("DeliveryID")]
        public string ID { get; set; }

        [Column("OrderID")]
        public string OrderID { get; set; }

        [Column("OrderUserID")]
        public string OrderUserID { get; set; }

        [Column("CreatedTime")]
        public DateTime CreatedTime { get; set; } = DateTime.Now;

        [Column("UpdatedTime")]
        public DateTime UpdatedTime { get; set; }
    }
}
