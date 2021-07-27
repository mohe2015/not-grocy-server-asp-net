﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NotGrocy.Models
{
    [Table("tasks")]
    [Index(nameof(Id), IsUnique = true)]
    public partial class Task
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("due_date", TypeName = "DATETIME")]
        public byte[] DueDate { get; set; }
        [Column("done", TypeName = "TINYINT")]
        public long Done { get; set; }
        [Column("done_timestamp", TypeName = "DATETIME")]
        public byte[] DoneTimestamp { get; set; }
        [Column("category_id")]
        public long? CategoryId { get; set; }
        [Column("assigned_to_user_id")]
        public long? AssignedToUserId { get; set; }
        [Column("row_created_timestamp", TypeName = "DATETIME")]
        public byte[] RowCreatedTimestamp { get; set; }
    }
}