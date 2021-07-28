using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NotGrocy.Models
{
    [Table("user_permissions")]
    [Index(nameof(Id), IsUnique = true)]
    [Index(nameof(UserId), nameof(PermissionId), IsUnique = true)]
    public partial class UserPermission
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("permission_id")]
        public long PermissionId { get; set; }
        [Column("user_id")]
        public long UserId { get; set; }
    }
}
