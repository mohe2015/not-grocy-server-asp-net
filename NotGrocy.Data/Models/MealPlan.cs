using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NotGrocy.Models
{
    [Table("meal_plan")]
    [Index(nameof(Id), IsUnique = true)]
    public partial class MealPlan
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("day", TypeName = "DATE")]
        public DateTime Day { get; set; }
        [Column("type")]
        public string Type { get; set; }
        [Column("recipe_id")]
        public long? RecipeId { get; set; }
        [Column("recipe_servings")]
        public long? RecipeServings { get; set; }
        [Column("note")]
        public string Note { get; set; }
        [Column("product_id")]
        public long? ProductId { get; set; }
        [Column("product_amount")]
        public double? ProductAmount { get; set; }
        [Column("product_qu_id")]
        public long? ProductQuId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("row_created_timestamp", TypeName = "DATETIME")]
        public DateTime RowCreatedTimestamp { get; set; }
    }
}
