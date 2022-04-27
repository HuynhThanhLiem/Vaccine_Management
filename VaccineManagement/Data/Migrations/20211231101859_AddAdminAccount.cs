using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

namespace VaccineManagement.Data.Migrations
{
    public partial class AddAdminAccount : Migration
    {
        const string ADMIN_USER_GUID = "ee6a5c5c-259a-4482-851d-e916749f8a10";
        const string ADMIN_ROLE_GUID = "c689e84f-3b03-492a-af4d-93726c2f4879";
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hasher = new PasswordHasher<ApplicationDbContext>();

            var passwordHash = hasher.HashPassword(null, "Vaccine@Management23");

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("INSERT INTO Users (Id, UserName, NormalizedUserName, Email, EmailConfirmed, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled," +
                "AccessFailedCount, NormalizedEmail, PasswordHash, SecurityStamp)");
            sb.AppendLine("VALUES(");
            sb.AppendLine($"'{ADMIN_USER_GUID}'");
            sb.AppendLine(",'liemht23@gmail.com'");
            sb.AppendLine(",'LIEMHT23@GMAIL.COM'");
            sb.AppendLine(",'liemht23@gmail.com'");
            sb.AppendLine(", 1");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(",'LIEMHT23@GMAIL.COM'");
            sb.AppendLine($", '{passwordHash}'");
            sb.AppendLine(", ''");
            sb.AppendLine(")");

            migrationBuilder.Sql(sb.ToString());

            migrationBuilder.Sql($"INSERT INTO Roles (Id, Name, NormalizedName) VALUES ('{ADMIN_ROLE_GUID}','Manager', 'MANAGER')");

            migrationBuilder.Sql($"INSERT INTO UserRoles (UserId, RoleId) VALUES ('{ADMIN_USER_GUID}','{ADMIN_ROLE_GUID}')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM UserRoles WHERE UserId = '{ADMIN_USER_GUID}' AND RoleId = '{ADMIN_ROLE_GUID}'");

            migrationBuilder.Sql($"DELETE FROM Users WHERE Id = '{ADMIN_USER_GUID}'");

            migrationBuilder.Sql($"DELETE FROM Roles WHERE Id = '{ADMIN_ROLE_GUID}'");
        }
    }
}
