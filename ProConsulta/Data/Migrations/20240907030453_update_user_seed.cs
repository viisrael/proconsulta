using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProConsulta.Migrations
{
    /// <inheritdoc />
    public partial class update_user_seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d2d69a2-577a-401a-b65a-3ff2e3039b09",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6eea7035-2abd-4278-bf39-e22b6193f295", "ATENDENTE@EMAIL.COM", "AQAAAAIAAYagAAAAEIksUPmf0xrLf9QzYOSMFDrY+QIK9IOxkc2JZ8wEK9oaNxbLNGwxZe78AVMueo3hDw==", "05617150-eaa4-4666-93b4-4e50837e95a8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d2d69a2-577a-401a-b65a-3ff2e3039b09",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7800122b-f4c8-42ac-aa23-345848f9e716", "ATENDENTE", "AQAAAAIAAYagAAAAELKnT5dN4uVudptkW6syMu6wnmLnfD6O4AF61dbArEfPNetitK7tJ4LxEdtToKFi9w==", "3f8a2885-8ee9-4e10-947f-e125b8479754" });
        }
    }
}
