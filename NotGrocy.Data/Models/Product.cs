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
        public string? Description { get; set; }

        [Column("product_group_id")]
        public long? ProductGroupId { get; set; }

        [Column("active")]
        public bool Active;

        [Column("location_id")]
        public long LocationId { get; set; }

        [Column("shopping_location_id")]
        public long? ShoppingLocationId { get; set; }

        [Column("qu_id_purchase")]
        public long QuIdPurchase { get; set; }

        [Column("qu_id_stock")]
        public long QuIdStock { get; set; }

        [Column("qu_factor_purchase_to_stock")]
        public double QuFactorPurchaseToStock { get; set; }

        [Column("min_stock_amount")]
        public long MinStockAmount { get; set; }

        [Column("default_best_before_days")]
        public long DefaultBestBeforeDays { get; set; }

        [Column("default_best_before_days_after_open")]
        public long DefaultBestBeforeDaysAfterOpen { get; set; }

        [Column("default_best_before_days_after_freezing")]
        public long DefaultBestBeforeDaysAfterFreezing { get; set; }

        [Column("default_best_before_days_after_thawing")]
        public long DefaultBestBeforeDaysAfterThawing { get; set; }

        [Column("picture_file_name")]
        public string? PictureFileName { get; set; }

        [Column("enable_tare_weight_handling")]
        public bool EnableTareWeightHandling;

        [Column("tare_weight")]
        public double TareWeight { get; set; }

        [Column("not_check_stock_fulfillment_for_recipes")]
        public bool? NotCheckStockFulfillmentForRecipes;

        [Column("parent_product_id")]
        public long ParentProductId { get; set; }

        [Column("calories")]
        public long? Calories { get; set; }

        [Column("cumulate_min_stock_amount_of_sub_products")]
        public bool? CumulateMinStockAmountOfSubProducts;

        [Column("due_type")]
        public long DueType { get; set; }

        [Column("quick_consume_amount")]
        public double QuickConsumeAmount { get; set; }

        [Column("hide_on_stock_overview")]
        public bool HideOnStockOverview;

        [Column("row_created_timestamp")]
        public DateTime? RowCreatedTimestamp { get; set; }

        [Column("default_print_stock_label")]
        public long DefaultPrintStockLabel { get; set; }

        [Column("allow_label_per_unit")]
        public bool AllowLabelPerUnit;
    }
}
