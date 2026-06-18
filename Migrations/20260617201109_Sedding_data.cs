using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorldWalks.Migrations
{
    /// <inheritdoc />
    public partial class Sedding_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { new Guid("5fdc857e-016d-46f1-b069-35a6ca94595f"), "Medium" },
                    { new Guid("68a7f624-b174-480a-bda6-00e6d95b1285"), "Hard" },
                    { new Guid("b1165848-9b75-4650-a742-ff3fbff79a61"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("1a8f4cb2-41ad-44c0-8dd1-2cc14856e4bb"), "WLG", "Wellington", "https://example.com/region2.jpg" },
                    { new Guid("57c7a9ff-ea12-4df1-a5d1-dcd6730fb158"), "GIS", "Gisborne", "https://example.com/region10.jpg" },
                    { new Guid("6fba3df7-6453-47d0-9844-9df0f08d2441"), "TOS", "Tasman", "https://example.com/region6.jpg" },
                    { new Guid("7f3c8c11-9c5f-41db-9e4d-bd45efc78121"), "AKL", "Auckland", "https://example.com/region1.jpg" },
                    { new Guid("a5c044b6-29ea-4e20-b59e-7e7efca067d3"), "DND", "Dunedin", "https://example.com/region4.jpg" },
                    { new Guid("ad3ee423-2e06-463d-b99e-7e09bc9e6ffe"), "NTL", "Northland", "https://example.com/region9.jpg" },
                    { new Guid("bb3a9cbe-cce3-4be3-b836-94dbb54c0f7d"), "NSN", "Nelson", "https://example.com/region5.jpg" },
                    { new Guid("d84ddc36-d8cd-4737-8dee-397a093c8d06"), "WKO", "Waikato", "https://example.com/region8.jpg" },
                    { new Guid("e29bdc8c-b2df-48b4-9eb7-0da3e7cf5c9c"), "CHC", "Christchurch", "https://example.com/region3.jpg" },
                    { new Guid("fc0b3800-9e0a-4d4b-b165-a05a1ba1cbe5"), "BOP", "Bay of Plenty", "https://example.com/region7.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("5fdc857e-016d-46f1-b069-35a6ca94595f"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("68a7f624-b174-480a-bda6-00e6d95b1285"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("b1165848-9b75-4650-a742-ff3fbff79a61"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1a8f4cb2-41ad-44c0-8dd1-2cc14856e4bb"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("57c7a9ff-ea12-4df1-a5d1-dcd6730fb158"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6fba3df7-6453-47d0-9844-9df0f08d2441"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("7f3c8c11-9c5f-41db-9e4d-bd45efc78121"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a5c044b6-29ea-4e20-b59e-7e7efca067d3"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("ad3ee423-2e06-463d-b99e-7e09bc9e6ffe"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("bb3a9cbe-cce3-4be3-b836-94dbb54c0f7d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d84ddc36-d8cd-4737-8dee-397a093c8d06"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e29bdc8c-b2df-48b4-9eb7-0da3e7cf5c9c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("fc0b3800-9e0a-4d4b-b165-a05a1ba1cbe5"));
        }
    }
}
