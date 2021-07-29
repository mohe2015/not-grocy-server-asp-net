using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NotGrocy.Models
{
    [Table("quantity_unit_conversions")]
    [Index(nameof(Id), IsUnique = true)]
    public partial class QuantityUnitConversion
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("from_qu_id")]
        public long FromQuId { get; set; }
        [Column("to_qu_id")]
        public long ToQuId { get; set; }
        [Column("factor")]
        public double Factor { get; set; }
        [Column("product_id")]
        public long? ProductId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("row_created_timestamp")]
        public DateTime RowCreatedTimestamp { get; set; }
    }
}
