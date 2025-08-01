using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class AddSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ClientTags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("037c14c8-8007-4dc2-b5a6-9a8e04b31005"), "Активный отдых" },
                    { new Guid("67174e5c-bf1d-48e0-b899-d12b806d1354"), "Гірнолижний отдых" },
                    { new Guid("72173a88-fe04-41fe-a5da-330cd2614df2"), "Эконом" },
                    { new Guid("b6c79da8-8226-4576-bc86-9bca9a86bdb1"), "Семейный отдых" },
                    { new Guid("c4846917-4ac1-43fd-a31e-263b53cc29f7"), "Постоянный клиент" },
                    { new Guid("d27f8fb3-43d5-415f-8b49-4a1e1bc4acd7"), "Ездит один" },
                    { new Guid("e1e04141-db1f-456d-917b-6d09b54c944e"), "VIP" },
                    { new Guid("e91e15dd-c410-47f7-80f8-f3167fd3a3b9"), "Экскурсионный отдых" },
                    { new Guid("f800ad54-bd85-4d14-bace-4dddb53b79ae"), "Пляжный отдых" }
                });

            migrationBuilder.InsertData(
                table: "SocialMedias",
                columns: new[] { "Id", "Name", "SecretKey" },
                values: new object[,]
                {
                    { new Guid("529c6f82-4a00-4ac1-8f3f-e7ae86ab29cf"), "WhatsApp", "" },
                    { new Guid("c9151dd2-7d1b-4814-a072-7f9887ce0825"), "SMS", "" },
                    { new Guid("c9dd4dd4-0766-430d-85f4-856777f7274f"), "Telegram", "" },
                    { new Guid("fa053701-ca07-459e-a486-f8a0e8a19cce"), "Viber", "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClientTags",
                keyColumn: "Id",
                keyValue: new Guid("037c14c8-8007-4dc2-b5a6-9a8e04b31005"));

            migrationBuilder.DeleteData(
                table: "ClientTags",
                keyColumn: "Id",
                keyValue: new Guid("67174e5c-bf1d-48e0-b899-d12b806d1354"));

            migrationBuilder.DeleteData(
                table: "ClientTags",
                keyColumn: "Id",
                keyValue: new Guid("72173a88-fe04-41fe-a5da-330cd2614df2"));

            migrationBuilder.DeleteData(
                table: "ClientTags",
                keyColumn: "Id",
                keyValue: new Guid("b6c79da8-8226-4576-bc86-9bca9a86bdb1"));

            migrationBuilder.DeleteData(
                table: "ClientTags",
                keyColumn: "Id",
                keyValue: new Guid("c4846917-4ac1-43fd-a31e-263b53cc29f7"));

            migrationBuilder.DeleteData(
                table: "ClientTags",
                keyColumn: "Id",
                keyValue: new Guid("d27f8fb3-43d5-415f-8b49-4a1e1bc4acd7"));

            migrationBuilder.DeleteData(
                table: "ClientTags",
                keyColumn: "Id",
                keyValue: new Guid("e1e04141-db1f-456d-917b-6d09b54c944e"));

            migrationBuilder.DeleteData(
                table: "ClientTags",
                keyColumn: "Id",
                keyValue: new Guid("e91e15dd-c410-47f7-80f8-f3167fd3a3b9"));

            migrationBuilder.DeleteData(
                table: "ClientTags",
                keyColumn: "Id",
                keyValue: new Guid("f800ad54-bd85-4d14-bace-4dddb53b79ae"));

            migrationBuilder.DeleteData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: new Guid("529c6f82-4a00-4ac1-8f3f-e7ae86ab29cf"));

            migrationBuilder.DeleteData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: new Guid("c9151dd2-7d1b-4814-a072-7f9887ce0825"));

            migrationBuilder.DeleteData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: new Guid("c9dd4dd4-0766-430d-85f4-856777f7274f"));

            migrationBuilder.DeleteData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: new Guid("fa053701-ca07-459e-a486-f8a0e8a19cce"));
        }
    }
}
