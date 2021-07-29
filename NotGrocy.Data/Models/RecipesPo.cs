using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NotGrocy.Models
{
    [Table("recipes_pos")]
    [Index(nameof(Id), IsUnique = true)]
    public partial class RecipesPo
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("recipe_id")]
        public long RecipeId { get; set; }
        [Column("product_id")]
        public long ProductId { get; set; }
        [Column("amount")]
        public double Amount { get; set; }
        [Column("note")]
        public string Note { get; set; }
        [Column("qu_id")]
        public long? QuId { get; set; }
        [Column("only_check_single_unit_in_stock")]
        public long OnlyCheckSingleUnitInStock { get; set; }
        [Column("ingredient_group")]
        public string IngredientGroup { get; set; }
        [Column("not_check_stock_fulfillment")]
        public long NotCheckStockFulfillment { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("row_created_timestamp")]
        public DateTime RowCreatedTimestamp { get; set; }
        [Column("variable_amount")]
        public string VariableAmount { get; set; }
        [Column("price_factor")]
        public double PriceFactor { get; set; }
    }
}
