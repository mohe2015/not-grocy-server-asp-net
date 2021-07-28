using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NotGrocy.Models
{
    [Table("userentities")]
    [Index(nameof(Id), IsUnique = true)]
    [Index(nameof(Name), IsUnique = true)]
    public partial class Userentity
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Required]
        [Column("caption")]
        public string Caption { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("show_in_sidebar_menu", TypeName = "TINYINT")]
        public long ShowInSidebarMenu { get; set; }
        [Column("icon_css_class")]
        public string IconCssClass { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("row_created_timestamp")]
        public DateTime RowCreatedTimestamp { get; set; }
    }
}
