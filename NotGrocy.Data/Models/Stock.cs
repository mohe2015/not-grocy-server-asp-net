using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NotGrocy.Models
{
    [Table("stock")]
    [Index(nameof(Id), IsUnique = true)]
    [Index(nameof(ProductId), nameof(Open), nameof(BestBeforeDate), nameof(Amount), Name = "ix_stock_performance1")]
    public partial class Stock
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("product_id")]
        public long ProductId { get; set; }
        [Required]
        [Column("amount", TypeName = "DECIMAL(15, 2)")]
        public double Amount { get; set; }
        [Column("best_before_date", TypeName = "DATE")]
        public DateTime BestBeforeDate { get; set; }
        [Column("purchased_date", TypeName = "DATE")]
        public DateTime PurchasedDate { get; set; }
        [Required]
        [Column("stock_id")]
        public string StockId { get; set; }
        [Column("price", TypeName = "DECIMAL(15, 2)")]
        public double Price { get; set; }
        [Column("open", TypeName = "TINYINT")]
        public long Open { get; set; }
        [Column("opened_date", TypeName = "DATETIME")]
        public DateTime OpenedDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("row_created_timestamp", TypeName = "DATETIME")]
        public DateTime RowCreatedTimestamp { get; set; }
        [Column("location_id")]
        public long? LocationId { get; set; }
        [Column("shopping_location_id")]
        public long? ShoppingLocationId { get; set; }
    }
}
