using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LMSAdmin.Models;

[Table("user_status")]
[Index("UserStatusId", Name = "UQ__user_sta__8E5BDDEE000DE96E", IsUnique = true)]
public partial class UserStatus
{
    [Key]
    [Column("user_status_id")]
    public int UserStatusId { get; set; }

    [Column("user_status")]
    [StringLength(255)]
    public string UserStatus1 { get; set; } = null!;

    public virtual ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
}
