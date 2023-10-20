using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class NewProjectStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Person_PersonId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Institution_InstitutionType_InstitutionTypeId",
                table: "Institution");

            migrationBuilder.DropTable(
                name: "CompetitionOrganizer");

            migrationBuilder.DropTable(
                name: "ConcertOrganizer");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "InstitutionAcronym");

            migrationBuilder.DropTable(
                name: "InstitutionType");

            migrationBuilder.DropTable(
                name: "PersonAtCompetition");

            migrationBuilder.DropTable(
                name: "PersonAtConcert");

            migrationBuilder.DropTable(
                name: "PersonInJury");

            migrationBuilder.DropTable(
                name: "PersonOnCurriculum");

            migrationBuilder.DropTable(
                name: "PersonSubject");

            migrationBuilder.DropTable(
                name: "Round");

            migrationBuilder.DropTable(
                name: "TeacherInClass");

            migrationBuilder.DropTable(
                name: "ContactType");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Jury");

            migrationBuilder.DropIndex(
                name: "IX_Institution_InstitutionTypeId",
                table: "Institution");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PersonId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ECTS",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "EstablishedAt",
                table: "Institution");

            migrationBuilder.DropColumn(
                name: "FinishedAt",
                table: "Institution");

            migrationBuilder.DropColumn(
                name: "InstitutionTypeId",
                table: "Institution");

            migrationBuilder.DropColumn(
                name: "RegistryCode",
                table: "Institution");

            migrationBuilder.DropColumn(
                name: "IsNotInSchedule",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "ReturnedAt",
                table: "BookLentOut");

            migrationBuilder.DropColumn(
                name: "YearReleased",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Room",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CompetitionId",
                table: "Concert",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AppUserAtConcert",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ConcertId = table.Column<Guid>(type: "uuid", nullable: false),
                    From = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Until = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserAtConcert", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserAtConcert_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppUserAtConcert_Concert_ConcertId",
                        column: x => x.ConcertId,
                        principalTable: "Concert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppUserOnCurriculum",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CurriculumId = table.Column<Guid>(type: "uuid", nullable: false),
                    From = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Until = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserOnCurriculum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserOnCurriculum_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppUserOnCurriculum_Curriculum_CurriculumId",
                        column: x => x.CurriculumId,
                        principalTable: "Curriculum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JuryMember",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ConcertId = table.Column<Guid>(type: "uuid", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    From = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Until = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JuryMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JuryMember_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JuryMember_Concert_ConcertId",
                        column: x => x.ConcertId,
                        principalTable: "Concert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MajorTeachers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    From = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Until = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SubjectTeacherId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MajorTeachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MajorTeachers_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MajorTeachers_AspNetUsers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MajorTeachers_SubjectTeacher_SubjectTeacherId",
                        column: x => x.SubjectTeacherId,
                        principalTable: "SubjectTeacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppUserOnSubject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AppUserOnCurriculumId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubjectInCurriculumId = table.Column<Guid>(type: "uuid", nullable: false),
                    From = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Until = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserOnSubject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppUserOnSubject_AppUserOnCurriculum_AppUserOnCurriculumId",
                        column: x => x.AppUserOnCurriculumId,
                        principalTable: "AppUserOnCurriculum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppUserOnSubject_SubjectInCurriculum_SubjectInCurriculumId",
                        column: x => x.SubjectInCurriculumId,
                        principalTable: "SubjectInCurriculum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Concert_CompetitionId",
                table: "Concert",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserAtConcert_AppUserId",
                table: "AppUserAtConcert",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserAtConcert_ConcertId",
                table: "AppUserAtConcert",
                column: "ConcertId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserOnCurriculum_AppUserId",
                table: "AppUserOnCurriculum",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserOnCurriculum_CurriculumId",
                table: "AppUserOnCurriculum",
                column: "CurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserOnSubject_AppUserOnCurriculumId",
                table: "AppUserOnSubject",
                column: "AppUserOnCurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserOnSubject_SubjectInCurriculumId",
                table: "AppUserOnSubject",
                column: "SubjectInCurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_JuryMember_AppUserId",
                table: "JuryMember",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_JuryMember_ConcertId",
                table: "JuryMember",
                column: "ConcertId");

            migrationBuilder.CreateIndex(
                name: "IX_MajorTeachers_StudentId",
                table: "MajorTeachers",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_MajorTeachers_SubjectTeacherId",
                table: "MajorTeachers",
                column: "SubjectTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_MajorTeachers_TeacherId",
                table: "MajorTeachers",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Concert_Competition_CompetitionId",
                table: "Concert",
                column: "CompetitionId",
                principalTable: "Competition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concert_Competition_CompetitionId",
                table: "Concert");

            migrationBuilder.DropTable(
                name: "AppUserAtConcert");

            migrationBuilder.DropTable(
                name: "AppUserOnSubject");

            migrationBuilder.DropTable(
                name: "JuryMember");

            migrationBuilder.DropTable(
                name: "MajorTeachers");

            migrationBuilder.DropTable(
                name: "AppUserOnCurriculum");

            migrationBuilder.DropIndex(
                name: "IX_Concert_CompetitionId",
                table: "Concert");

            migrationBuilder.DropColumn(
                name: "CompetitionId",
                table: "Concert");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "ECTS",
                table: "Subject",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Room",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EstablishedAt",
                table: "Institution",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishedAt",
                table: "Institution",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InstitutionTypeId",
                table: "Institution",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "RegistryCode",
                table: "Institution",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsNotInSchedule",
                table: "Class",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReturnedAt",
                table: "BookLentOut",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YearReleased",
                table: "Book",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "AspNetUsers",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ContactType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InstitutionAcronym",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InstitutionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Acronym = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    From = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Until = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstitutionAcronym", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstitutionAcronym_Institution_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstitutionType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstitutionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jury",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompetitionId = table.Column<Guid>(type: "uuid", nullable: false),
                    From = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Until = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jury", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jury_Competition_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    LastName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonOnCurriculum",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CurriculumId = table.Column<Guid>(type: "uuid", nullable: false),
                    From = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Until = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonOnCurriculum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonOnCurriculum_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonOnCurriculum_Curriculum_CurriculumId",
                        column: x => x.CurriculumId,
                        principalTable: "Curriculum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonSubject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    AverageGrade = table.Column<double>(type: "double precision", nullable: true),
                    From = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Until = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonSubject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonSubject_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonSubject_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeacherInClass",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClassId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubjectTeacherId = table.Column<Guid>(type: "uuid", nullable: false),
                    From = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Until = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherInClass", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherInClass_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherInClass_SubjectTeacher_SubjectTeacherId",
                        column: x => x.SubjectTeacherId,
                        principalTable: "SubjectTeacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompetitionId = table.Column<Guid>(type: "uuid", nullable: false),
                    JuryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Competition_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category_Jury_JuryId",
                        column: x => x.JuryId,
                        principalTable: "Jury",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Round",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompetitionId = table.Column<Guid>(type: "uuid", nullable: false),
                    InstitutionId = table.Column<Guid>(type: "uuid", nullable: false),
                    JuryId = table.Column<Guid>(type: "uuid", nullable: false),
                    From = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Until = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Round", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Round_Competition_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Round_Institution_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Round_Jury_JuryId",
                        column: x => x.JuryId,
                        principalTable: "Jury",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionOrganizer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompetitionId = table.Column<Guid>(type: "uuid", nullable: false),
                    InstitutionId = table.Column<Guid>(type: "uuid", nullable: true),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    From = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Until = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionOrganizer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetitionOrganizer_Competition_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompetitionOrganizer_Institution_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompetitionOrganizer_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConcertOrganizer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ConcertId = table.Column<Guid>(type: "uuid", nullable: false),
                    InstitutionId = table.Column<Guid>(type: "uuid", nullable: true),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: true),
                    From = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Until = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcertOrganizer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConcertOrganizer_Concert_ConcertId",
                        column: x => x.ConcertId,
                        principalTable: "Concert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConcertOrganizer_Institution_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConcertOrganizer_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ContactTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    From = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Until = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Value = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_ContactType_ContactTypeId",
                        column: x => x.ContactTypeId,
                        principalTable: "ContactType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contact_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonAtConcert",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ConcertId = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    From = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Until = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonAtConcert", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonAtConcert_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonAtConcert_Concert_ConcertId",
                        column: x => x.ConcertId,
                        principalTable: "Concert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonAtConcert_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonInJury",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    JuryId = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    From = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Until = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInJury", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonInJury_Jury_JuryId",
                        column: x => x.JuryId,
                        principalTable: "Jury",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonInJury_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonAtCompetition",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    CompetitionId = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uuid", nullable: true),
                    From = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Until = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonAtCompetition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonAtCompetition_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonAtCompetition_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonAtCompetition_Competition_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonAtCompetition_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Institution_InstitutionTypeId",
                table: "Institution",
                column: "InstitutionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PersonId",
                table: "AspNetUsers",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_CompetitionId",
                table: "Category",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_JuryId",
                table: "Category",
                column: "JuryId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionOrganizer_CompetitionId",
                table: "CompetitionOrganizer",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionOrganizer_InstitutionId",
                table: "CompetitionOrganizer",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionOrganizer_PersonId",
                table: "CompetitionOrganizer",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcertOrganizer_ConcertId",
                table: "ConcertOrganizer",
                column: "ConcertId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcertOrganizer_InstitutionId",
                table: "ConcertOrganizer",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcertOrganizer_PersonId",
                table: "ConcertOrganizer",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_ContactTypeId",
                table: "Contact",
                column: "ContactTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_PersonId",
                table: "Contact",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_InstitutionAcronym_InstitutionId",
                table: "InstitutionAcronym",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Jury_CompetitionId",
                table: "Jury",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAtCompetition_AppUserId",
                table: "PersonAtCompetition",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAtCompetition_CategoryId",
                table: "PersonAtCompetition",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAtCompetition_CompetitionId",
                table: "PersonAtCompetition",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAtCompetition_PersonId",
                table: "PersonAtCompetition",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAtConcert_AppUserId",
                table: "PersonAtConcert",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAtConcert_ConcertId",
                table: "PersonAtConcert",
                column: "ConcertId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAtConcert_PersonId",
                table: "PersonAtConcert",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInJury_JuryId",
                table: "PersonInJury",
                column: "JuryId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInJury_PersonId",
                table: "PersonInJury",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonOnCurriculum_AppUserId",
                table: "PersonOnCurriculum",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonOnCurriculum_CurriculumId",
                table: "PersonOnCurriculum",
                column: "CurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonSubject_AppUserId",
                table: "PersonSubject",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonSubject_SubjectId",
                table: "PersonSubject",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Round_CompetitionId",
                table: "Round",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Round_InstitutionId",
                table: "Round",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Round_JuryId",
                table: "Round",
                column: "JuryId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherInClass_ClassId",
                table: "TeacherInClass",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherInClass_SubjectTeacherId",
                table: "TeacherInClass",
                column: "SubjectTeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Person_PersonId",
                table: "AspNetUsers",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Institution_InstitutionType_InstitutionTypeId",
                table: "Institution",
                column: "InstitutionTypeId",
                principalTable: "InstitutionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
