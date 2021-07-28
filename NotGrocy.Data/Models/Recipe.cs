using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NotGrocy.Models
{
    [Table("recipes")]
    [Index(nameof(Id), IsUnique = true)]
    [Index(nameof(Name), nameof(Type), Name = "ix_recipes")]
    public partial class Recipe
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("row_created_timestamp", TypeName = "DATETIME")]
        public DateTime RowCreatedTimestamp { get; set; }
        [Column("picture_file_name")]
        public string PictureFileName { get; set; }
        [Column("base_servings")]
        public long? BaseServings { get; set; }
        [Column("desired_servings")]
        public long? DesiredServings { get; set; }
        [Column("not_check_shoppinglist", TypeName = "TINYINT")]
        public long NotCheckShoppinglist { get; set; }
        [Column("type")]
        public string Type { get; set; }
        [Column("product_id")]
        public long? ProductId { get; set; }
    }
}
