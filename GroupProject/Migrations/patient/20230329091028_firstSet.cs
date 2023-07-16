using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupProject.Migrations.patient
{
    /// <inheritdoc />
    public partial class firstSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    TeleNumber = table.Column<string>(type: "TEXT", nullable: false),
                    AdmittedDate = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    Guardian = table.Column<string>(type: "TEXT", nullable: false),
                    PatientType = table.Column<string>(type: "TEXT", nullable: false),
                    WardNo = table.Column<string>(type: "TEXT", nullable: false),
                    payments = table.Column<int>(type: "INTEGER", nullable: false),
                    GuardianTeleNum = table.Column<string>(type: "TEXT", nullable: true),
                    Doctor = table.Column<string>(type: "TEXT", nullable: true),
                    InsuredName = table.Column<string>(type: "TEXT", nullable: true),
                    InsuaranceCom = table.Column<string>(type: "TEXT", nullable: true),
                    InsuranceComeNum = table.Column<string>(type: "TEXT", nullable: true),
                    InsurancePolicy = table.Column<string>(type: "TEXT", nullable: true),
                    InsuranceRelation = table.Column<string>(type: "TEXT", nullable: true),
                    InsuranceGroup = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
