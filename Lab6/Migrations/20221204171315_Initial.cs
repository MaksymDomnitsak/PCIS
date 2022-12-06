using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab6.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Workplaces",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workplaces", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UniversityTeachers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    LastName = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    PatronymicName = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    WorkPlace = table.Column<int>(type: "int", nullable: false),
                    PositionName = table.Column<int>(type: "int", nullable: false),
                    FirstSubjectName = table.Column<int>(type: "int", nullable: false),
                    SecondSubjectName = table.Column<int>(type: "int", nullable: true),
                    PositionHourlyRate = table.Column<int>(type: "int", nullable: false),
                    CountReadHours = table.Column<int>(type: "int", nullable: false),
                    HomeAddress = table.Column<string>(type: "varchar(128)", unicode: false, maxLength: 128, nullable: false),
                    Characteristics = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityTeachers", x => x.ID);
                    table.ForeignKey(
                        name: "UniversityTeachers_fk0",
                        column: x => x.WorkPlace,
                        principalTable: "Workplaces",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "UniversityTeachers_fk1",
                        column: x => x.PositionName,
                        principalTable: "Positions",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "UniversityTeachers_fk2",
                        column: x => x.FirstSubjectName,
                        principalTable: "Subjects",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "UniversityTeachers_fk3",
                        column: x => x.SecondSubjectName,
                        principalTable: "Subjects",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UniversityTeachers_FirstSubjectName",
                table: "UniversityTeachers",
                column: "FirstSubjectName");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityTeachers_PositionName",
                table: "UniversityTeachers",
                column: "PositionName");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityTeachers_SecondSubjectName",
                table: "UniversityTeachers",
                column: "SecondSubjectName");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityTeachers_WorkPlace",
                table: "UniversityTeachers",
                column: "WorkPlace");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UniversityTeachers");

            migrationBuilder.DropTable(
                name: "Workplaces");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
