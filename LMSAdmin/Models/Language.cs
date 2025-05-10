using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LMSAdmin.Models;

[Table("Language")]
[Index("LanguageN", Name = "UQ__Language__7163493D16205E65", IsUnique = true)]
[Index("LanguageId", Name = "UQ__Language__804CF6B2FE1444C2", IsUnique = true)]
public partial class Language
{
    [Key]
    [Column("language_id")]
    public int LanguageId { get; set; }

    [Column("languageN")]
    [StringLength(255)]
    public string LanguageN { get; set; } = null!;

    [InverseProperty("LanguageNavigation")]
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    public static implicit operator Language?(string? v)
    {
        throw new NotImplementedException();
    }
}
