using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NotGrocy.Models
{
    [Table("chores_log")]
    [Index(nameof(Id), IsUnique = true)]
    public partial class ChoresLog
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("chore_id")]
        public long ChoreId { get; set; }
        [Column("tracked_time")]
        public DateTime TrackedTime { get; set; }
        [Column("done_by_user_id")]
        public long? DoneByUserId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("row_created_timestamp")]
        public DateTime RowCreatedTimestamp { get; set; }
        [Column("undone")]
        public long Undone { get; set; }
        [Column("undone_timestamp")]
        public DateTime UndoneTimestamp { get; set; }
    }
}
