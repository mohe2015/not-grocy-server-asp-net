using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NotGrocy.Models
{
    [Table("userfield_values")]
    [Index(nameof(Id), IsUnique = true)]
    [Index(nameof(FieldId), nameof(ObjectId), IsUnique = true)]
    public partial class UserfieldValue
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("field_id")]
        public long FieldId { get; set; }
        [Column("object_id")]
        public long ObjectId { get; set; }
        [Required]
        [Column("value")]
        public string Value { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("row_created_timestamp", TypeName = "DATETIME")]
        public DateTime RowCreatedTimestamp { get; set; }
    }
}
