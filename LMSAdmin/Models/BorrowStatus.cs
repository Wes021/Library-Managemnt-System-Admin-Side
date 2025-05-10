using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LMSAdmin.Models;

[Table("borrow_status")]
[Index("BorrowStatus1", Name = "UQ__borrow_s__98D7B8E21AB4EEE2", IsUnique = true)]
[Index("BorrowStatusId", Name = "UQ__borrow_s__A58A5F8F0AFD67AB", IsUnique = true)]
public partial class BorrowStatus
{
    [Key]
    [Column("borrow_status_id")]
    public int BorrowStatusId { get; set; }

    [Column("borrow_status")]
    [StringLength(255)]
    public string BorrowStatus1 { get; set; } = null!;

    [InverseProperty("BorrowStatus")]
    public virtual ICollection<Borrowing> Borrowings { get; set; } = new List<Borrowing>();
}
