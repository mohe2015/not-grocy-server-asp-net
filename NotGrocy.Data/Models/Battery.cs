using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NotGrocy.Models
{
    [Table("batteries")]
    [Index(nameof(Id), IsUnique = true)]
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(Id), nameof(Active), Name = "ix_batteries_performance1")]
    public partial class Battery
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("used_in")]
        public string UsedIn { get; set; }
        [Column("charge_interval_days")]
        public long ChargeIntervalDays { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("row_created_timestamp")]
        public DateTime RowCreatedTimestamp { get; set; }
        [Column("active")]
        public long Active { get; set; }
    }
}
