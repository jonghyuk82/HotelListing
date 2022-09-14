using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelListing.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotels_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[,]
                {
                    { new Guid("2bf26677-e991-4986-9f0b-f7776ee3e488"), "Korea", "KR" },
                    { new Guid("9c419819-985d-41cd-8a63-feb00412c137"), "Bahamas", "BS" },
                    { new Guid("edaf5e66-1331-4511-961c-66ba0c783390"), "Jamaica", "JM" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CountryId", "Name", "Rating" },
                values: new object[,]
                {
                    { new Guid("30153109-b244-44b7-bcd4-4a25a1f8eb2e"), "Seoul", new Guid("2bf26677-e991-4986-9f0b-f7776ee3e488"), "Hilton", 4.0 },
                    { new Guid("7a2b42c0-4e45-46ce-9dfb-6cc2bbf545ab"), "Gangjin-gu", new Guid("9c419819-985d-41cd-8a63-feb00412c137"), "Walker Hill", 4.4000000000000004 },
                    { new Guid("d55b4a2f-dcbc-4543-ba48-9e6a9ba5ca66"), "Jamsil", new Guid("edaf5e66-1331-4511-961c-66ba0c783390"), "Lotte Hotel", 5.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_CountryId",
                table: "Hotels",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
