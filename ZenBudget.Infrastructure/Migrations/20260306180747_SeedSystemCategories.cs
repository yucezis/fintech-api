using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenBudget.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedSystemCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Icon", "Color", "Type", "IsSystem", "UserId" },
                values: new object[,]
                {
            { Guid.Parse("11111111-1111-1111-1111-111111111101"), "Market",      "🛒", "#4CAF50", 1, true, null },
            { Guid.Parse("11111111-1111-1111-1111-111111111102"), "Ulaşım",      "🚗", "#2196F3", 1, true, null },
            { Guid.Parse("11111111-1111-1111-1111-111111111103"), "Yemek",       "🍽️", "#FF9800", 1, true, null },
            { Guid.Parse("11111111-1111-1111-1111-111111111104"), "Faturalar",   "📱", "#9C27B0", 1, true, null },
            { Guid.Parse("11111111-1111-1111-1111-111111111105"), "Sağlık",      "💊", "#F44336", 1, true, null },
            { Guid.Parse("11111111-1111-1111-1111-111111111106"), "Eğlence",     "🎬", "#E91E63", 1, true, null },
            { Guid.Parse("11111111-1111-1111-1111-111111111107"), "Maaş",        "💼", "#4CAF50", 0, true, null },
            { Guid.Parse("11111111-1111-1111-1111-111111111108"), "Freelance",   "💻", "#00BCD4", 0, true, null },
            { Guid.Parse("11111111-1111-1111-1111-111111111109"), "Kira Geliri", "🏠", "#FF5722", 0, true, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValues: new object[]
                {
            Guid.Parse("11111111-1111-1111-1111-111111111101"),
            Guid.Parse("11111111-1111-1111-1111-111111111102"),
            Guid.Parse("11111111-1111-1111-1111-111111111103"),
            Guid.Parse("11111111-1111-1111-1111-111111111104"),
            Guid.Parse("11111111-1111-1111-1111-111111111105"),
            Guid.Parse("11111111-1111-1111-1111-111111111106"),
            Guid.Parse("11111111-1111-1111-1111-111111111107"),
            Guid.Parse("11111111-1111-1111-1111-111111111108"),
            Guid.Parse("11111111-1111-1111-1111-111111111109")
                });
        }

        
    }
}
