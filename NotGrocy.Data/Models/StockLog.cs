using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NotGrocy.Models
{
    [Table("stock_log")]
    [Index(nameof(Id), IsUnique = true)]
    public partial class StockLog
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("product_id")]
        public long ProductId { get; set; }
        [Required]
        [Column("amount", TypeName = "DECIMAL(15, 2)")]
        public Double Amount { get; set; }
        [Column("best_before_date", TypeName = "DATE")]
        public DateTime BestBeforeDate { get; set; }
        [Column("purchased_date", TypeName = "DATE")]
        public DateTime PurchasedDate { get; set; }
        [Column("used_date", TypeName = "DATE")]
        public DateTime UsedDate { get; set; }
        [Column("spoiled")]
        public long Spoiled { get; set; }
        [Required]
        [Column("stock_id")]
        public string StockId { get; set; }
        [Required]
        [Column("transaction_type")]
        public string TransactionType { get; set; }
        [Column("price", TypeName = "DECIMAL(15, 2)")]
        public Double Price { get; set; }
        [Column("undone", TypeName = "TINYINT")]
        public long Undone { get; set; }
        [Column("undone_timestamp", TypeName = "DATETIME")]
        public DateTime UndoneTimestamp { get; set; }
        [Column("opened_date", TypeName = "DATETIME")]
        public DateTime OpenedDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("row_created_timestamp", TypeName = "DATETIME")]
        public DateTime RowCreatedTimestamp { get; set; }
        [Column("location_id")]
        public long? LocationId { get; set; }
        [Column("recipe_id")]
        public long? RecipeId { get; set; }
        [Column("correlation_id")]
        public string CorrelationId { get; set; }
        [Column("transaction_id")]
        public string TransactionId { get; set; }
        [Column("stock_row_id")]
        public long? StockRowId { get; set; }
        [Column("shopping_location_id")]
        public long? ShoppingLocationId { get; set; }
        [Column("user_id")]
        public long UserId { get; set; }
    }
}
