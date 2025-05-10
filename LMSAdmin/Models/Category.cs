using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;

namespace LMSAdmin.Models;

[Table("category")]
[Index("CategoryId", Name = "UQ__category__D54EE9B537B6F6A3", IsUnique = true)]
public partial class Category
{
    [Key]
    [Column("category_id")]
    
    public int CategoryId { get; set; }

    [Column("categoryN")]
    [StringLength(255)]
    public string CategoryN { get; set; } = null!;

    [InverseProperty("CategoryNavigation")]
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
