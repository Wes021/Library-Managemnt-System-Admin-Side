using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LMSAdmin.Models;

public partial class LMSV2Context : IdentityDbContext<ApplicationUser>

{

    public LMSV2Context(DbContextOptions<LMSV2Context> options)
        : base(options)
    {
    }



    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookStatus> BookStatuses { get; set; }

    public virtual DbSet<BorrowStatus> BorrowStatuses { get; set; }

    public virtual DbSet<Borrowing> Borrowings { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Language> Languages { get; set; }





    public virtual DbSet<UserStatus> UserStatuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__books__490D1AE11A304099");

            entity.Property(e => e.BookId).ValueGeneratedNever();
            entity.Property(e => e.BookTitle).HasDefaultValue("");

            entity.HasOne(d => d.CategoryNavigation).WithMany(p => p.Books)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("books_fk5");



            entity.HasOne(d => d.LanguageNavigation).WithMany(p => p.Books)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("books_fk3");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.Books)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("books_fk7");


        });

        modelBuilder.Entity<BookStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Book_sta__3683B53106A89BAB");
        });

        modelBuilder.Entity<BorrowStatus>(entity =>
        {
            entity.HasKey(e => e.BorrowStatusId).HasName("PK__borrow_s__A58A5F8EDFE5C57C");
        });



        modelBuilder.Entity<Borrowing>(entity =>
        {
            entity.HasKey(e => e.BorrowId).HasName("PK__borrowin__262B57A0036DCA5E");

            entity.Property(e => e.BorrowId).ValueGeneratedNever();

            entity.HasOne(d => d.Book).WithOne(p => p.Borrowing)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("borrowing_fk2");



            entity.HasOne(d => d.BorrowStatus).WithMany(p => p.Borrowings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("borrowing_fk5");

            // Fix the relationship with IdentityUser
            entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("borrowing_fk1");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__category__D54EE9B43055B0F8");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.LanguageId).HasName("PK__Language__804CF6B3C3083BE2");
        });



        modelBuilder.Entity<UserStatus>(entity =>
        {
            entity.HasKey(e => e.UserStatusId).HasName("PK__user_sta__8E5BDDEF567CFF03");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
