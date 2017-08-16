using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WifeyApp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DayPlans",
                columns: table => new
                {
                    DayPlanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Links = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayPlans", x => x.DayPlanId);
                });

            migrationBuilder.CreateTable(
                name: "Excercises",
                columns: table => new
                {
                    ExcerciseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActualReps = table.Column<int>(nullable: false),
                    ActualSets = table.Column<int>(nullable: false),
                    DayPlanId = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    TargetReps = table.Column<int>(nullable: false),
                    TargetSets = table.Column<int>(nullable: false),
                    TrackingOption = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Excercises", x => x.ExcerciseId);
                    table.ForeignKey(
                        name: "FK_Excercises_DayPlans_DayPlanId",
                        column: x => x.DayPlanId,
                        principalTable: "DayPlans",
                        principalColumn: "DayPlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    MealId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Calories = table.Column<int>(nullable: false),
                    DayPlanId = table.Column<int>(nullable: false),
                    MealOption = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.MealId);
                    table.ForeignKey(
                        name: "FK_Meals_DayPlans_DayPlanId",
                        column: x => x.DayPlanId,
                        principalTable: "DayPlans",
                        principalColumn: "DayPlanId",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateIndex(
                name: "IX_Excercises_DayPlanId",
                table: "Excercises",
                column: "DayPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_DayPlanId",
                table: "Meals",
                column: "DayPlanId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "Excercises");


            migrationBuilder.DropTable(
                name: "DayPlans");
        }
    }
}
