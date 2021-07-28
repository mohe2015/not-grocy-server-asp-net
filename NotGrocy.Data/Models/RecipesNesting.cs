using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NotGrocy.Models
{
    [Table("recipes_nestings")]
    [Index(nameof(Id), IsUnique = true)]
    [Index(nameof(RecipeId), nameof(IncludesRecipeId), IsUnique = true)]
    public partial class RecipesNesting
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("recipe_id")]
        public long RecipeId { get; set; }
        [Column("includes_recipe_id")]
        public long IncludesRecipeId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("row_created_timestamp", TypeName = "DATETIME")]
        public DateTime RowCreatedTimestamp { get; set; }
        [Column("servings")]
        public long? Servings { get; set; }
    }
}
