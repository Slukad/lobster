using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Adventure.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Decision",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decision", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Choice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true),
                    DecisionId = table.Column<int>(nullable: true),
                    NextDecisionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Choice_Decision_DecisionId",
                        column: x => x.DecisionId,
                        principalTable: "Decision",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Choice_Decision_NextDecisionId",
                        column: x => x.NextDecisionId,
                        principalTable: "Decision",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Adventure",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adventure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adventure_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SelectedChoice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdventureId = table.Column<int>(nullable: true),
                    ChoiceId = table.Column<int>(nullable: true),
                    DecisionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedChoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedChoice_Adventure_AdventureId",
                        column: x => x.AdventureId,
                        principalTable: "Adventure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SelectedChoice_Choice_ChoiceId",
                        column: x => x.ChoiceId,
                        principalTable: "Choice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SelectedChoice_Decision_DecisionId",
                        column: x => x.DecisionId,
                        principalTable: "Decision",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            
            migrationBuilder.InsertData(
                table: "Decision",
                columns: new[] { "Id", "Level", "Order", "Text" },
                values: new object[,]
                {
                    { 11, 4, 4, "Play Assassins Creed" },
                    { 17, 5, 2, "Play Metal Slug" },
                    { 16, 5, 1, "Play Tekken" },
                    { 15, 4, 8, "Play League of legends" },
                    { 14, 4, 7, "Play Apex Legends" },
                    { 13, 4, 6, "Play Mario Kart" },
                    { 12, 4, 5, "Play FIFA 2020" },
                    { 10, 4, 3, "Play Cities Skilynes" },
                    { 1, 1, 1, "Are your reflexes below average?" },
                    { 8, 4, 1, "Are you ok with microtransactions?" },
                    { 7, 3, 4, "Are you into FPS games?" },
                    { 6, 3, 3, "Are you into football?" },
                    { 5, 3, 2, "Do you enjoy simulations?" },
                    { 4, 3, 1, "Are you ok using small devices?" },
                    { 3, 2, 2, "Are you into sports?" },
                    { 2, 2, 1, "Do you like arcade-type games?" },
                    { 18, 5, 1, "Play Candy crush" },
                    { 9, 4, 2, "Good Storytelling?" },
                    { 19, 5, 2, "PlayPlague inc" }
                });

            migrationBuilder.InsertData(
                table: "Choice",
                columns: new[] { "Id", "DecisionId", "NextDecisionId", "Text" },
                values: new object[,]
                {
                    { 1, 1, 2, "Yes" },
                    { 17, 9, 16, "Yes" },
                    { 16, 8, 19, "No" },
                    { 15, 8, 18, "Yes" },
                    { 14, 7, 15, "No" },
                    { 13, 7, 14, "Yes" },
                    { 12, 6, 13, "No" },
                    { 11, 6, 12, "Yes" },
                    { 10, 5, 11, "No" },
                    { 18, 9, 17, "No" },
                    { 8, 4, 9, "No" },
                    { 7, 4, 8, "Yes" },
                    { 6, 3, 7, "No" },
                    { 5, 3, 6, "Yes" },
                    { 4, 2, 5, "No" },
                    { 3, 2, 4, "Yes" },
                    { 2, 1, 3, "No" },
                    { 9, 5, 10, "Yes" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adventure_PlayerId",
                table: "Adventure",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Choice_DecisionId",
                table: "Choice",
                column: "DecisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Choice_NextDecisionId",
                table: "Choice",
                column: "NextDecisionId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedChoice_AdventureId",
                table: "SelectedChoice",
                column: "AdventureId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedChoice_ChoiceId",
                table: "SelectedChoice",
                column: "ChoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedChoice_DecisionId",
                table: "SelectedChoice",
                column: "DecisionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SelectedChoice");

            migrationBuilder.DropTable(
                name: "Adventure");

            migrationBuilder.DropTable(
                name: "Choice");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Decision");
        }
    }
}
