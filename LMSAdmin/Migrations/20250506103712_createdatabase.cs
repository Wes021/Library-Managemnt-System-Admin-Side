using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMSAdmin.Migrations
{
    /// <inheritdoc />
    public partial class createdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book_status",
                columns: table => new
                {
                    status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Book_statusN = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Book_sta__3683B53106A89BAB", x => x.status_id);
                });

            migrationBuilder.CreateTable(
                name: "borrow_status",
                columns: table => new
                {
                    borrow_status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    borrow_status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__borrow_s__A58A5F8EDFE5C57C", x => x.borrow_status_id);
                });

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryN = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__category__D54EE9B43055B0F8", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    language_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    languageN = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Language__804CF6B3C3083BE2", x => x.language_id);
                });

            migrationBuilder.CreateTable(
                name: "user_status",
                columns: table => new
                {
                    user_status_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user_sta__8E5BDDEF567CFF03", x => x.user_status_id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    book_id = table.Column<int>(type: "int", nullable: false),
                    ISBN = table.Column<int>(type: "int", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Language = table.Column<int>(type: "int", nullable: false),
                    year = table.Column<int>(type: "int", nullable: true),
                    category = table.Column<int>(type: "int", nullable: false),
                    image = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    status = table.Column<int>(type: "int", nullable: false),
                    fine_rate = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    total_copies = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BookTitle = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__books__490D1AE11A304099", x => x.book_id);
                    table.ForeignKey(
                        name: "books_fk3",
                        column: x => x.Language,
                        principalTable: "Language",
                        principalColumn: "language_id");
                    table.ForeignKey(
                        name: "books_fk5",
                        column: x => x.category,
                        principalTable: "category",
                        principalColumn: "category_id");
                    table.ForeignKey(
                        name: "books_fk7",
                        column: x => x.status,
                        principalTable: "Book_status",
                        principalColumn: "status_id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserStatusId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_user_status_UserStatusId",
                        column: x => x.UserStatusId,
                        principalTable: "user_status",
                        principalColumn: "user_status_id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "borrowing",
                columns: table => new
                {
                    borrow_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    book_id = table.Column<int>(type: "int", nullable: false),
                    borrowed_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    return_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    borrow_status_id = table.Column<int>(type: "int", nullable: false),
                    fine_amount = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__borrowin__262B57A0036DCA5E", x => x.borrow_id);
                    table.ForeignKey(
                        name: "borrowing_fk1",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "borrowing_fk2",
                        column: x => x.book_id,
                        principalTable: "books",
                        principalColumn: "book_id");
                    table.ForeignKey(
                        name: "borrowing_fk5",
                        column: x => x.borrow_status_id,
                        principalTable: "borrow_status",
                        principalColumn: "borrow_status_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserStatusId",
                table: "AspNetUsers",
                column: "UserStatusId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Book_sta__1BBF736C931370F5",
                table: "Book_status",
                column: "Book_statusN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Book_sta__3683B530CDFF0794",
                table: "Book_status",
                column: "status_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_books_category",
                table: "books",
                column: "category");

            migrationBuilder.CreateIndex(
                name: "IX_books_Language",
                table: "books",
                column: "Language");

            migrationBuilder.CreateIndex(
                name: "IX_books_status",
                table: "books",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "UQ__books__447D36EA5D91AC9F",
                table: "books",
                column: "ISBN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__books__490D1AE01EB7F207",
                table: "books",
                column: "book_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__borrow_s__98D7B8E21AB4EEE2",
                table: "borrow_status",
                column: "borrow_status",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__borrow_s__A58A5F8F0AFD67AB",
                table: "borrow_status",
                column: "borrow_status_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_borrowing_borrow_status_id",
                table: "borrowing",
                column: "borrow_status_id");

            migrationBuilder.CreateIndex(
                name: "UQ__borrowin__262B57A1A3F5D613",
                table: "borrowing",
                column: "borrow_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__borrowin__490D1AE003E79D9E",
                table: "borrowing",
                column: "book_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__borrowin__B9BE370EB5727638",
                table: "borrowing",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__category__D54EE9B537B6F6A3",
                table: "category",
                column: "category_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Language__7163493D16205E65",
                table: "Language",
                column: "languageN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Language__804CF6B2FE1444C2",
                table: "Language",
                column: "language_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__user_sta__8E5BDDEE000DE96E",
                table: "user_status",
                column: "user_status_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "borrowing");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "borrow_status");

            migrationBuilder.DropTable(
                name: "user_status");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "Book_status");
        }
    }
}
