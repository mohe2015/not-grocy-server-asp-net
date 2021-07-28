using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NotGrocy.Models
{
    [Table("users")]
    [Index(nameof(Id), IsUnique = true)]
    [Index(nameof(Username), IsUnique = true)]
    public partial class User
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("username")]
        public string Username { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Required]
        [Column("password")]
        public string Password { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("row_created_timestamp", TypeName = "DATETIME")]
        public DateTime RowCreatedTimestamp { get; set; }
        [Column("picture_file_name")]
        public string PictureFileName { get; set; }
    }
}
