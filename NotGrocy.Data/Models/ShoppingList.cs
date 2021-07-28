using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NotGrocy.Models
{
    [Table("shopping_list")]
    [Index(nameof(Id), IsUnique = true)]
    public partial class ShoppingList
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("product_id")]
        public long? ProductId { get; set; }
        [Column("note")]
        public string Note { get; set; }
        [Required]
        [Column("amount", TypeName = "DECIMAL(15, 2)")]
        public double Amount { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("row_created_timestamp", TypeName = "DATETIME")]
        public DateTime RowCreatedTimestamp { get; set; }
        [Column("shopping_list_id", TypeName = "INT")]
        public long? ShoppingListId { get; set; }
        [Column("done", TypeName = "INT")]
        public long? Done { get; set; }
        [Column("qu_id")]
        public long? QuId { get; set; }
    }
}
