using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NotGrocy.Models
{
    [Table("products")]
    [Index(nameof(Id), IsUnique = true)]
    [Index(nameof(Name), IsUnique = true)]
    public partial class Product
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("description")]
        public string Description { get; set; }

        [Column("product_group_id", TypeName = "INTEGER")]
        public long? ProductGroupId { get; set; }
        
        [Column("amount")]
        public double? Amount { get; set; }
        [Column("shopping_location_id")]
        public long? ShoppingLocationId { get; set; }
        [Column("last_price", TypeName = "DECIMAL(15, 2)")]
        public byte[] LastPrice { get; set; }
        [Column("row_created_timestamp", TypeName = "DATETIME")]
        public byte[] RowCreatedTimestamp { get; set; }
        [Column("note")]
        public string Note { get; set; }
    }
}
