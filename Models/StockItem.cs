using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StockApi.Models
{
    [Table("stock")]
    public class StockItem
    {
        public long Id { get; set; }

        [Column("product_id")]
        public long ProductId { get; set; }

        public double Amount { get; set; }

        [Column("best_before_date")]
        public DateTime? BestBeforeDate { get; set; }

        [Column("purchased_date")]
        public DateTime? PurchasedDate { get; set; }

        [Required]
        [Column("stock_id")]
        public string StockId { get; set; }

        public double? Price { get; set; }

        [Column("open")]
        public bool IsOpen { get; set; }

        [Column("opened_date")]
        public DateTime? OpenedDate { get; set; }

        [Column("row_created_timestamp")]
        public DateTime? RowCreated { get; set; }

        [Column("location_id")]
        public long? LocationId { get; set; }

        [Column("shopping_location_id")]
        public long? ShoppingLocationId { get; set; }
    }
}