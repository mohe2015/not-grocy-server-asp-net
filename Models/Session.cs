﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NotGrocy.Models
{
    [Table("sessions")]
    [Index(nameof(Id), IsUnique = true)]
    [Index(nameof(SessionKey), IsUnique = true)]
    public partial class Session
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("session_key")]
        public string SessionKey { get; set; }
        [Column("user_id")]
        public long UserId { get; set; }
        [Column("expires", TypeName = "DATETIME")]
        public byte[] Expires { get; set; }
        [Column("last_used", TypeName = "DATETIME")]
        public byte[] LastUsed { get; set; }
        [Column("row_created_timestamp", TypeName = "DATETIME")]
        public byte[] RowCreatedTimestamp { get; set; }
    }
}
