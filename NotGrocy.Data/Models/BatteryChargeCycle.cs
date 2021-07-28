using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NotGrocy.Models
{
    [Table("battery_charge_cycles")]
    [Index(nameof(Id), IsUnique = true)]
    public partial class BatteryChargeCycle
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("battery_id")]
        public string BatteryId { get; set; }
        [Column("tracked_time", TypeName = "DATETIME")]
        public DateTime TrackedTime { get; set; }
        [Column("row_created_timestamp", TypeName = "DATETIME")]
        public DateTime RowCreatedTimestamp { get; set; }
        [Column("undone", TypeName = "TINYINT")]
        public long Undone { get; set; }
        [Column("undone_timestamp", TypeName = "DATETIME")]
        public DateTime UndoneTimestamp { get; set; }
    }
}
