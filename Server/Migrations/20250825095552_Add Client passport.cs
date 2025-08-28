using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class AddClientpassport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ClientsPassports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DateOfIssue = table.Column<DateOnly>(type: "date", nullable: false),
                    DateOfExpiry = table.Column<DateOnly>(type: "date", nullable: false),
                    Record = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Authority = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientsPassports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientsPassports_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClientTags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("06956855-0e82-4c00-b8ff-0287cb619e1a"), "Активный отдых" },
                    { new Guid("0bd4e9fe-9f70-43f3-9a5b-a5e3474ba503"), "Эконом" },
                    { new Guid("275506d2-3eed-44fb-85ee-ed234844b3e0"), "Гірнолижний отдых" },
                    { new Guid("44d7c07f-516e-4a60-b9b6-c05423870c00"), "Ездит один" },
                    { new Guid("52633958-f984-41c5-a275-71f5c13f9c58"), "Пляжный отдых" },
                    { new Guid("5f4a40b7-7e70-4d7c-a749-e7231989e89e"), "VIP" },
                    { new Guid("654a6de0-2026-4b7d-b458-a0d38c8320a1"), "Семейный отдых" },
                    { new Guid("67aafb75-1fc6-4ad8-a15e-4574d12523b1"), "Постоянный клиент" },
                    { new Guid("fafe9349-fee0-4c92-b035-fb22bf338c5f"), "Экскурсионный отдых" }
                });

            migrationBuilder.InsertData(
                table: "SocialMedias",
                columns: new[] { "Id", "Name", "SecretKey" },
                values: new object[,]
                {
                    { new Guid("4f24b9d5-6e13-46ae-baeb-e1f31389d092"), "Telegram", "" },
                    { new Guid("7bb05478-0129-49d0-986e-62a9870fe393"), "SMS", "" },
                    { new Guid("d692b28d-6924-4b18-878e-ec6f91f38df0"), "WhatsApp", "" },
                    { new Guid("df49d0b2-f09f-409b-8d27-ee20b4508333"), "Viber", "" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientsPassports_ClientId",
                table: "ClientsPassports",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientsPassports_FirstName",
                table: "ClientsPassports",
                column: "FirstName");

            migrationBuilder.CreateIndex(
                name: "IX_ClientsPassports_LastName",
                table: "ClientsPassports",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "IX_ClientsPassports_SerialNumber",
                table: "ClientsPassports",
                column: "SerialNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientsPassports");

            migrationBuilder.DeleteData(
                table: "ClientTags",
                keyColumn: "Id",
                keyValue: new Guid("06956855-0e82-4c00-b8ff-0287cb619e1a"));

            migrationBuilder.DeleteData(
                table: "ClientTags",
                keyColumn: "Id",
                keyValue: new Guid("0bd4e9fe-9f70-43f3-9a5b-a5e3474ba503"));

            migrationBuilder.DeleteData(
                table: "ClientTags",
                keyColumn: "Id",
                keyValue: new Guid("275506d2-3eed-44fb-85ee-ed234844b3e0"));

            migrationBuilder.DeleteData(
                table: "ClientTags",
                keyColumn: "Id",
                keyValue: new Guid("44d7c07f-516e-4a60-b9b6-c05423870c00"));

            migrationBuilder.DeleteData(
                table: "ClientTags",
                keyColumn: "Id",
                keyValue: new Guid("52633958-f984-41c5-a275-71f5c13f9c58"));

            migrationBuilder.DeleteData(
                table: "ClientTags",
                keyColumn: "Id",
                keyValue: new Guid("5f4a40b7-7e70-4d7c-a749-e7231989e89e"));

            migrationBuilder.DeleteData(
                table: "ClientTags",
                keyColumn: "Id",
                keyValue: new Guid("654a6de0-2026-4b7d-b458-a0d38c8320a1"));

            migrationBuilder.DeleteData(
                table: "ClientTags",
                keyColumn: "Id",
                keyValue: new Guid("67aafb75-1fc6-4ad8-a15e-4574d12523b1"));

            migrationBuilder.DeleteData(
                table: "ClientTags",
                keyColumn: "Id",
                keyValue: new Guid("fafe9349-fee0-4c92-b035-fb22bf338c5f"));

            migrationBuilder.DeleteData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: new Guid("4f24b9d5-6e13-46ae-baeb-e1f31389d092"));

            migrationBuilder.DeleteData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: new Guid("7bb05478-0129-49d0-986e-62a9870fe393"));

            migrationBuilder.DeleteData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: new Guid("d692b28d-6924-4b18-878e-ec6f91f38df0"));

            migrationBuilder.DeleteData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: new Guid("df49d0b2-f09f-409b-8d27-ee20b4508333"));

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
    }
}
