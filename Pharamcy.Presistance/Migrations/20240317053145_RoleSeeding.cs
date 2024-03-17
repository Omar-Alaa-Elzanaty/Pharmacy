using Microsoft.EntityFrameworkCore.Migrations;
using Pharamcy.Shared;

#nullable disable

namespace Pharamcy.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class RoleSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"insert into Account.Roles(Id,Name,NormalizedName)" +
                $"values('{Guid.NewGuid()}','{SystemRoles.SystemAdmin}','{SystemRoles.SystemAdmin.ToUpper()}')," +
                $"('{Guid.NewGuid()}','{SystemRoles.Admin}','{SystemRoles.Admin.ToUpper()}')," +
                $"('{Guid.NewGuid()}','{SystemRoles.Moderator}','{SystemRoles.Moderator.ToUpper()}')," +
                $"('{Guid.NewGuid()}','{SystemRoles.Cashier}','{SystemRoles.Cashier.ToUpper()}')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Account.Roles");
        }
    }
}
