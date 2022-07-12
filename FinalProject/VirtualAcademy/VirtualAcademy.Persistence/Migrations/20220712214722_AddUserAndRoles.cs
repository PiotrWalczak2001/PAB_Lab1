using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualAcademy.Persistence.Migrations
{
    public partial class AddUserAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "29f2dfb3-e391-4b46-9c1b-dfd360bdc40f", "71107636-9130-4a36-81fa-0ea9736b533a", "Lecturer", "LECTURER" },
                    { "41955396-834b-4ee6-901a-fc9dfbd0b92d", "9920dbe1-03aa-45d6-9335-b95b4d1ff7c8", "User", "USER" },
                    { "9c0a5871-fd62-46f6-9aa0-6253ddf8436a", "f60b7a0b-4fa6-49c9-9ba3-831629a858de", "Student", "STUDENT" },
                    { "bb352f3f-dfd1-4c23-a879-84a8885107c6", "d34967dd-f8fd-49cb-84fa-ae1002f3cbc8", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1737574a-e41b-4f2d-b288-da7c2323b4e6", 0, "a8116ca9-77e7-49ff-9b55-0ffc51d0777f", "testlecturer@mail.com", true, false, null, "TESTLECTURER@MAIL.COM", "TEST LECTURER", "AQAAAAEAACcQAAAAEDWFC7BCTe4A3J4Pp5mKK7umF7lBmGaMyIM2v14Ojw1eJOvBLhyJq/ujYBcLTgVmXw==", null, false, "18379c17-efe4-4deb-85b0-6d5b4a5555fa", false, "Test Lecturer" },
                    { "63f3fc0b-ee4a-453e-802b-7e6b554d798f", 0, "af300b55-f58f-42c8-9c35-324565a0e5fe", "testuser@mail.com", true, false, null, "TESTUSER@MAIL.COM", "TEST USER", "AQAAAAEAACcQAAAAEIq5BLJINfJ55FHLvAc59tW/5fGWIQzDZMfdHA6VD2T/kD7B/9UGHnko6kJ7w0+GrQ==", null, false, "49a84c86-71d9-4f0c-9deb-892e8140044a", false, "Test User" },
                    { "d2420772-683a-40ad-a5b7-9bf93cccc1df", 0, "1008b5ac-d36c-4f97-8d30-7b880b5192ee", "testadmin@mail.com", true, false, null, "TESTADMIN@MAIL.COM", "TEST ADMIN", "AQAAAAEAACcQAAAAEHwwdv+jBsj1W2CGZmRPADLC/vGPdmg1bJWHv/BOyxTxSQNbCOypiBED/gdBMSRfcQ==", null, false, "3af09193-19bf-494c-8c47-3d2921ecc86b", false, "Test Admin" },
                    { "dcf71a67-2e23-4582-a461-bf856c1133e3", 0, "50472455-1c91-47bb-ba63-9c925b3695b3", "teststudent@mail.com", true, false, null, "TESTSTUDENT@MAIL.COM", "TEST STUDENT", "AQAAAAEAACcQAAAAEOc7jRhEQYmCMnpuiyRZ80kV9v9ZROcEKsiywJIik7pdrjAr3rjBjMxVi3pr4rMUNw==", null, false, "c23db69d-1092-4c03-8e92-20095f197bbe", false, "Test Student" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "29f2dfb3-e391-4b46-9c1b-dfd360bdc40f", "1737574a-e41b-4f2d-b288-da7c2323b4e6" },
                    { "41955396-834b-4ee6-901a-fc9dfbd0b92d", "63f3fc0b-ee4a-453e-802b-7e6b554d798f" },
                    { "bb352f3f-dfd1-4c23-a879-84a8885107c6", "d2420772-683a-40ad-a5b7-9bf93cccc1df" },
                    { "9c0a5871-fd62-46f6-9aa0-6253ddf8436a", "dcf71a67-2e23-4582-a461-bf856c1133e3" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "29f2dfb3-e391-4b46-9c1b-dfd360bdc40f", "1737574a-e41b-4f2d-b288-da7c2323b4e6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "41955396-834b-4ee6-901a-fc9dfbd0b92d", "63f3fc0b-ee4a-453e-802b-7e6b554d798f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bb352f3f-dfd1-4c23-a879-84a8885107c6", "d2420772-683a-40ad-a5b7-9bf93cccc1df" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9c0a5871-fd62-46f6-9aa0-6253ddf8436a", "dcf71a67-2e23-4582-a461-bf856c1133e3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29f2dfb3-e391-4b46-9c1b-dfd360bdc40f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41955396-834b-4ee6-901a-fc9dfbd0b92d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c0a5871-fd62-46f6-9aa0-6253ddf8436a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb352f3f-dfd1-4c23-a879-84a8885107c6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1737574a-e41b-4f2d-b288-da7c2323b4e6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "63f3fc0b-ee4a-453e-802b-7e6b554d798f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d2420772-683a-40ad-a5b7-9bf93cccc1df");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dcf71a67-2e23-4582-a461-bf856c1133e3");
        }
    }
}
