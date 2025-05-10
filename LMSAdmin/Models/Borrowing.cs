using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LMSAdmin.Models;

[Table("borrowing")]
[Index("BorrowId", Name = "UQ__borrowin__262B57A1A3F5D613", IsUnique = true)]
[Index("BookId", Name = "UQ__borrowin__490D1AE003E79D9E", IsUnique = true)]
[Index("UserId", Name = "UQ__borrowin__B9BE370EB5727638", IsUnique = true)]
public partial class Borrowing
{
    [Key]
    [Column("borrow_id")]
    public int BorrowId { get; set; }

    [Column("user_id")]
    public string UserId { get; set; }

    [Column("book_id")]
    public int BookId { get; set; }

    [Column("borrowed_at", TypeName = "datetime")]
    public DateTime? BorrowedAt { get; set; }

    [Column("return_at", TypeName = "datetime")]
    public DateTime? ReturnAt { get; set; }

    [Column("borrow_status_id")]
    public int BorrowStatusId { get; set; }

    [Column("fine_amount", TypeName = "decimal(18, 0)")]
    public decimal FineAmount { get; set; }

    [ForeignKey("BookId")]
    [InverseProperty("Borrowing")]
    public virtual Book Book { get; set; } = null!;

    [ForeignKey("BorrowStatusId")]
    [InverseProperty("Borrowings")]
    public virtual BorrowStatus BorrowStatus { get; set; } = null!;

    public virtual ApplicationUser User { get; set; } = null!;
}
