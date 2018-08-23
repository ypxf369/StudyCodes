using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Events;

namespace StorageService.Models.Entities
{
    [Table("Storages")]
    public class Storage : IStorage
    {
        [Column("StorageID")]
        public string ID { get; set; }

        [Column("StorageNumber")]
        public int StorageNumber { get; set; }

        [Column("CreatedTime")]
        public DateTime CreatedTime { get; set; } = DateTime.Now;

        [Column("UpdatedTime")]
        public DateTime UpdatedTime { get; set; }
    }
}
