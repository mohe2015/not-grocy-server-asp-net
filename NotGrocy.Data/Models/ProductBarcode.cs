using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NotGrocy.Models
{
    [Table("product_barcodes")]
    [Index(nameof(Id), IsUnique = true)]
    [Index(nameof(Barcode), Name = "ix_product_barcodes", IsUnique = true)]
    public partial class ProductBarcode
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("product_id")]
        public long ProductId { get; set; }
        [Required]
        [Column("barcode")]
        public string Barcode { get; set; }
        [Column("qu_id")]
        public long? QuId { get; set; }
        [Column("amount")]
        public double? Amount { get; set; }
        [Column("shopping_location_id")]
        public long? ShoppingLocationId { get; set; }
        [Column("last_price", TypeName = "DECIMAL(15, 2)")]
        public double LastPrice { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("row_created_timestamp")]
        public DateTime RowCreatedTimestamp { get; set; }
        [Column("note")]
        public string Note { get; set; }
    }
}
