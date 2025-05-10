using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LMSAdmin.Models;

[Table("Book_status")]
[Index("BookStatusN", Name = "UQ__Book_sta__1BBF736C931370F5", IsUnique = true)]
[Index("StatusId", Name = "UQ__Book_sta__3683B530CDFF0794", IsUnique = true)]
public partial class BookStatus
{
    [Key]
    [Column("status_id")]
    public int StatusId { get; set; }

    [Column("Book_statusN")]
    [StringLength(255)]
    public string BookStatusN { get; set; } = null!;

    [InverseProperty("StatusNavigation")]
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
