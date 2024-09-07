using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProConsulta.Migrations
{
    /// <inheritdoc />
    public partial class Seeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d2d69a2-577a-401a-b65a-3ff2e3039b09",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7800122b-f4c8-42ac-aa23-345848f9e716", "AQAAAAIAAYagAAAAELKnT5dN4uVudptkW6syMu6wnmLnfD6O4AF61dbArEfPNetitK7tJ4LxEdtToKFi9w==", "3f8a2885-8ee9-4e10-947f-e125b8479754" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d2d69a2-577a-401a-b65a-3ff2e3039b09",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4eab756f-a2ba-491f-9284-2abee144e19c", "AQAAAAIAAYagAAAAEP+fjShtxPhIiXQs2pYyWFb2S+00EUbgN8ZQ3qmXwsMz5tsos//clwi4v3dNP2boIg==", "8a070214-4931-4497-bb9f-7960f713e44c" });
        }
    }
}
