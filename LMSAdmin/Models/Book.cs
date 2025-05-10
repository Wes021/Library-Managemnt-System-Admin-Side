using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LMSAdmin.Models;

[Table("books")]
[Index("Isbn", Name = "UQ__books__447D36EA5D91AC9F", IsUnique = true)]
[Index("BookId", Name = "UQ__books__490D1AE01EB7F207", IsUnique = true)]
public partial class Book
{
    [Key]
    [Column("book_id")]
    public int BookId { get; set; }

    [Column("ISBN")]
    public int Isbn { get; set; }

    [StringLength(255)]
    public string? Publisher { get; set; }

    public int Language { get; set; }

    [Column("year")]
    public int? Year { get; set; }

    [Column("category")]
    public int
        Category
    { get; set; }

    [Column("image")]
    [StringLength(255)]
    public string? Image { get; set; }

    [Column("status")]
    public int Status { get; set; }

    [Column("fine_rate", TypeName = "decimal(18, 0)")]
    public decimal? FineRate { get; set; }


    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("total_copies")]
    [StringLength(255)]
    public string? TotalCopies { get; set; }

    public string? BookTitle { get; set; }

    [InverseProperty("Book")]
    public virtual Borrowing? Borrowing { get; set; }

    [ForeignKey("Category")]
    [InverseProperty("Books")]
    public virtual Category CategoryNavigation { get; set; } = null!;


    [ForeignKey("Language")]
    [InverseProperty("Books")]
    public virtual Language LanguageNavigation { get; set; } = null!;

    [ForeignKey("Status")]
    [InverseProperty("Books")]
    public virtual BookStatus StatusNavigation { get; set; } = null!;



    public static implicit operator List<object>(Book v)
    {
        throw new NotImplementedException();
    }
}
