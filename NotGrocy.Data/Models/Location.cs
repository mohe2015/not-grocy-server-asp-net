using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NotGrocy.Models
{
    [Table("locations")]
    [Index(nameof(Id), IsUnique = true)]
    [Index(nameof(Name), IsUnique = true)]
    public partial class Location
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("row_created_timestamp", TypeName = "DATETIME")]
        public byte[] RowCreatedTimestamp { get; set; }
        [Column("is_freezer", TypeName = "TINYINT")]
        public long IsFreezer { get; set; }
    }
}
