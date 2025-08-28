using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class Nullablepassport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { new Guid("0699cbf7-3941-47e5-b209-9450bb65d95b"), "Гірнолижний отдых" },
                    { new Guid("25b5adc6-b63f-4eb0-b228-dcba2c18db53"), "Пляжный отдых" },
                    { new Guid("31d49a3e-480c-46f7-a7b5-f66016f3b3cd"), "Экскурсионный отдых" },
                    { new Guid("48bc75eb-a591-4328-afed-43e8cf9d259e"), "Семейный отдых" },
                    { new Guid("4f46161e-ef0b-4c96-b4bf-dc2e81f0ee62"), "Постоянный клиент" },
                    { new Guid("6b3f4806-06c8-4437-8bd4-df0df81eaaea"), "Эконом" },
                    { new Guid("70543c2f-4057-4222-aaad-9a795ebf2e2e"), "Активный отдых" },
                    { new Guid("a3ce797f-dbb1-45ee-84e2-1c3f59c5a28b"), "Ездит один" },
                    { new Guid("b9674443-0b2e-4644-a52a-2e034cab2db1"), "VIP" }
                });

            migrationBuilder.InsertData(
                table: "SocialMedias",
                columns: new[] { "Id", "Name", "SecretKey" },
                values: new object[,]
                {
                    { new Guid("3ec62e8a-fcee-4d9d-998e-e587d8839b59"), "Telegram", "" },
                    { new Guid("964542f8-f1fa-4c98-acaa-10a2454461a6"), "WhatsApp", "" },
                    { new Guid("9d4f8642-a837-4baf-92d2-373a8258171b"), "SMS", "" },
                    { new Guid("f033cf56-6198-41b2-87d5-e4ca03c42090"), "Viber", "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClientTags",
                keyColumn: "Id",
                keyValue: new Guid("0699cbf7-3941-47e5-b209-9450bb65d95b"));

            migrationBuilder.DeleteData(
                table: "ClientTags",
                keyColumn: "Id",
                keyValue: new Guid("25b5adc6-b63f-4eb0-b228-dcba2c18db53"));

            migrationBuilder.DeleteData(
                table: "ClientTags",
                keyColumn: "Id",
                keyValue: new Guid("31d49a3e-480c-46f7-a7b5-f66016f3b3cd"));

            migrationBuilder.DeleteData(
                table: "ClientTags",
                keyColumn: "Id",
                keyValue: new Guid("48bc75eb-a591-4328-afed-43e8cf9d259e"));

            migrationBuilder.DeleteData(
                table: "ClientTags",
                keyColumn: "Id",
                keyValue: new Guid("4f46161e-ef0b-4c96-b4bf-dc2e81f0ee62"));

            migrationBuilder.DeleteData(
                table: "ClientTags",
                keyColumn: "Id",
                keyValue: new Guid("6b3f4806-06c8-4437-8bd4-df0df81eaaea"));

            migrationBuilder.DeleteData(
                table: "ClientTags",
                keyColumn: "Id",
                keyValue: new Guid("70543c2f-4057-4222-aaad-9a795ebf2e2e"));

            migrationBuilder.DeleteData(
                table: "ClientTags",
                keyColumn: "Id",
                keyValue: new Guid("a3ce797f-dbb1-45ee-84e2-1c3f59c5a28b"));

            migrationBuilder.DeleteData(
                table: "ClientTags",
                keyColumn: "Id",
                keyValue: new Guid("b9674443-0b2e-4644-a52a-2e034cab2db1"));

            migrationBuilder.DeleteData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: new Guid("3ec62e8a-fcee-4d9d-998e-e587d8839b59"));

            migrationBuilder.DeleteData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: new Guid("964542f8-f1fa-4c98-acaa-10a2454461a6"));

            migrationBuilder.DeleteData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: new Guid("9d4f8642-a837-4baf-92d2-373a8258171b"));

            migrationBuilder.DeleteData(
                table: "SocialMedias",
                keyColumn: "Id",
                keyValue: new Guid("f033cf56-6198-41b2-87d5-e4ca03c42090"));

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
        }
    }
}
