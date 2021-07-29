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
        [Comment("This is a test")]
        public long Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; } /*?*/

        [Column("product_group_id")]
        public long? ProductGroupId { get; set; }

        [Required]
        [Column("active")]
        public bool Active;

        [Required]
        [Column("location_id")]
        public long LocationId { get; set; }

        [Column("shopping_location_id")]
        public long? ShoppingLocationId { get; set; }

        [Required]
        [Column("qu_id_purchase")]
        public long QuIdPurchase { get; set; }

        [Required]
        [Column("qu_id_stock")]
        public long QuIdStock { get; set; }

        [Required]
        [Column("qu_factor_purchase_to_stock")]
        public double QuFactorPurchaseToStock { get; set; }

        [Required]
        [Column("min_stock_amount")]
        public long MinStockAmount { get; set; }

        [Required]
        [Column("default_best_before_days")]
        public long DefaultBestBeforeDays { get; set; }

        [Required]
        [Column("default_best_before_days_after_open")]
        public long DefaultBestBeforeDaysAfterOpen { get; set; }

        [Required]
        [Column("default_best_before_days_after_freezing")]
        public long DefaultBestBeforeDaysAfterFreezing { get; set; }

        [Required]
        [Column("default_best_before_days_after_thawing")]
        public long DefaultBestBeforeDaysAfterThawing { get; set; }

        [Required]
        [Column("picture_file_name")]
        public string PictureFileName { get; set; } /*?*/

        [Required]
        [Column("enable_tare_weight_handling")]
        public bool EnableTareWeightHandling;

        [Required]
        [Column("tare_weight")]
        public double TareWeight { get; set; }

        [Column("not_check_stock_fulfillment_for_recipes")]
        public bool? NotCheckStockFulfillmentForRecipes;

        [Required]
        [Column("parent_product_id")]
        public long ParentProductId { get; set; }

        [Column("calories")]
        public long? Calories { get; set; }

        [Column("cumulate_min_stock_amount_of_sub_products")]
        public bool? CumulateMinStockAmountOfSubProducts;

        [Required]
        [Column("due_type")]
        public long DueType { get; set; }

        [Required]
        [Column("quick_consume_amount")]
        public double QuickConsumeAmount { get; set; }

        [Required]
        [Column("hide_on_stock_overview")]
        public bool HideOnStockOverview;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("row_created_timestamp")]
        public DateTime? RowCreatedTimestamp { get; set; }

        [Required]
        [Column("default_print_stock_label")]
        public long DefaultPrintStockLabel { get; set; }

        [Required]
        [Column("allow_label_per_unit")]
        public bool AllowLabelPerUnit;
    }
}
