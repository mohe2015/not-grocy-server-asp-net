using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NotGrocy.Models
{
    [Table("userfields")]
    [Index(nameof(Id), IsUnique = true)]
    [Index(nameof(Entity), nameof(Name), IsUnique = true)]
    public partial class Userfield
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("entity")]
        public string Entity { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Required]
        [Column("caption")]
        public string Caption { get; set; }
        [Required]
        [Column("type")]
        public string Type { get; set; }
        [Column("show_as_column_in_tables", TypeName = "TINYINT")]
        public long ShowAsColumnInTables { get; set; }
        [Column("row_created_timestamp", TypeName = "DATETIME")]
        public byte[] RowCreatedTimestamp { get; set; }
        [Column("config")]
        public string Config { get; set; }
        [Column("sort_number")]
        public long? SortNumber { get; set; }
    }
}
