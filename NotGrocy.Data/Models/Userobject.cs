using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NotGrocy.Models
{
    [Table("userobjects")]
    [Index(nameof(Id), IsUnique = true)]
    public partial class Userobject
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("userentity_id")]
        public long UserentityId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("row_created_timestamp", TypeName = "DATETIME")]
        public DateTime RowCreatedTimestamp { get; set; }
    }
}
