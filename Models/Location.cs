using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NotGrocy.Models
{
    [Table("locations")]
    public class Location
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Column("row_created_timestamp")]
        public DateTime? RowCreated { get; set; }

        [Column("is_freezer")]
        public bool IsFreezer { get; set; }
    }
}
