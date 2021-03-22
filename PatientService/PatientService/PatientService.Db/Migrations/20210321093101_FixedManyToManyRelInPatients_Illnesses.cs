using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientService.Db.Migrations
{
    public partial class FixedManyToManyRelInPatients_Illnesses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Illnesses_IllnessId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Patients_PatientId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_IllnessId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_PatientId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "IllnessId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Patients");

            migrationBuilder.CreateTable(
                name: "IllnessPatient",
                columns: table => new
                {
                    IllnessesId = table.Column<int>(type: "int", nullable: false),
                    PatientsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IllnessPatient", x => new { x.IllnessesId, x.PatientsId });
                    table.ForeignKey(
                        name: "FK_IllnessPatient_Illnesses_IllnessesId",
                        column: x => x.IllnessesId,
                        principalTable: "Illnesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IllnessPatient_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IllnessPatient_PatientsId",
                table: "IllnessPatient",
                column: "PatientsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IllnessPatient");

            migrationBuilder.AddColumn<int>(
                name: "IllnessId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_IllnessId",
                table: "Patients",
                column: "IllnessId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PatientId",
                table: "Patients",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Illnesses_IllnessId",
                table: "Patients",
                column: "IllnessId",
                principalTable: "Illnesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Patients_PatientId",
                table: "Patients",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
