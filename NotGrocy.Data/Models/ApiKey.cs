using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NotGrocy.Models
{
    [Table("api_keys")]
    [Index(nameof(ApiKey1), IsUnique = true)]
    [Index(nameof(Id), IsUnique = true)]
    public partial class ApiKey
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("api_key")]
        public string ApiKey1 { get; set; }
        [Column("user_id")]
        public long UserId { get; set; }
        [Column("expires", TypeName = "DATETIME")]
        public DateTime Expires { get; set; }
        [Column("last_used", TypeName = "DATETIME")]
        public DateTime LastUsed { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("row_created_timestamp", TypeName = "DATETIME")]
        public DateTime RowCreatedTimestamp { get; set; }
        [Required]
        [Column("key_type")]
        public string KeyType { get; set; }
    }
}
