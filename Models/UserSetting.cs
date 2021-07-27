using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NotGrocy.Models
{
    [Table("user_settings")]
    [Index(nameof(Id), IsUnique = true)]
    [Index(nameof(UserId), nameof(Key), IsUnique = true)]
    public partial class UserSetting
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("user_id")]
        public long UserId { get; set; }
        [Required]
        [Column("key")]
        public string Key { get; set; }
        [Column("value")]
        public string Value { get; set; }
        [Column("row_created_timestamp", TypeName = "DATETIME")]
        public byte[] RowCreatedTimestamp { get; set; }
        [Column("row_updated_timestamp", TypeName = "DATETIME")]
        public byte[] RowUpdatedTimestamp { get; set; }
    }
}
