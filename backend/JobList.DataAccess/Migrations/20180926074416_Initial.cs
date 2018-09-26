using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobList.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CITIES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    NAME = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CITIES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LANGUAGES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    NAME = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LANGUAGES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ROLES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    NAME = table.Column<string>(unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SCHOOLS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    NAME = table.Column<string>(unicode: false, maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCHOOLS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WORK_AREAS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    PHOTO_DATA = table.Column<byte[]>(nullable: true),
                    PHOTO_MIMETYPE = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WORK_AREAS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "COMPANIES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    BOSS_NAME = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    FULL_DESCRIPTION = table.Column<string>(unicode: false, nullable: false),
                    SHORT_DESCRIPTION = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    ADDRESS = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    PHONE = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    LOGO_DATA = table.Column<byte[]>(nullable: true),
                    LOGO_MIMETYPE = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    SITE = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    EMAIL = table.Column<string>(unicode: false, maxLength: 150, nullable: false),
                    PASSWORD = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    ROLE_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPANIES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_COMPANIES_TO_ROLES",
                        column: x => x.ROLE_ID,
                        principalTable: "ROLES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FIRST_NAME = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    LAST_NAME = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    PHONE = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    PHOTO_DATA = table.Column<byte[]>(nullable: true),
                    PHOTO_MIME_TYPE = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    SEX = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    BIRTH_DATA = table.Column<DateTime>(type: "date", nullable: false),
                    ADDRESS = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    EMAIL = table.Column<string>(unicode: false, maxLength: 150, nullable: false),
                    PASSWORD = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    ROLE_ID = table.Column<int>(nullable: false),
                    CITY_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USERS_TO_CITIES",
                        column: x => x.CITY_ID,
                        principalTable: "CITIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USERS_TO_ROLES",
                        column: x => x.ROLE_ID,
                        principalTable: "ROLES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FACULTIES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    NAME = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    SCHOOL_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FACULTIES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FACULTIES_TO_SCHOOLS",
                        column: x => x.SCHOOL_ID,
                        principalTable: "SCHOOLS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RECRUITERS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FIRST_NAME = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    LAST_NAME = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    PHONE = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    EMAIL = table.Column<string>(unicode: false, maxLength: 150, nullable: false),
                    PASSWORD = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    COMPANY_ID = table.Column<int>(nullable: false),
                    ROLE_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RECRUITERS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RECRUITERS_TO_COMPANIES",
                        column: x => x.COMPANY_ID,
                        principalTable: "COMPANIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RECRUITERS_TO_ROLES",
                        column: x => x.ROLE_ID,
                        principalTable: "ROLES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RESUMES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    LINKEDIN = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    GITHUB = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    FACEBOOK = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    SKYPE = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    INSTAGRAM = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    FAMILY_STATE = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    SOFT_SKILLS = table.Column<string>(unicode: false, nullable: false),
                    KEY_SKILLS = table.Column<string>(unicode: false, nullable: false),
                    COURSES = table.Column<string>(unicode: false, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    MOD_DATE = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    WORK_AREA_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESUMES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RESUMES_TO_USERS",
                        column: x => x.ID,
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RESUMES_TO_WORKAREA",
                        column: x => x.WORK_AREA_ID,
                        principalTable: "WORK_AREAS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VACANCIES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    DESCRIPTION = table.Column<string>(unicode: false, nullable: false),
                    OFFERING = table.Column<string>(unicode: false, nullable: false),
                    REQUIREMENTS = table.Column<string>(unicode: false, nullable: false),
                    BE_PLUS = table.Column<string>(unicode: false, nullable: true),
                    IS_CHECKED = table.Column<bool>(nullable: true),
                    SALARY = table.Column<decimal>(type: "money", nullable: true),
                    FULL_PART_TIME = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    MOD_DATE = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    RECRUITER_ID = table.Column<int>(nullable: false),
                    CITY_ID = table.Column<int>(nullable: false),
                    WORK_AREA_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VACANCIES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VACANCIES_TO_CITIES",
                        column: x => x.CITY_ID,
                        principalTable: "CITIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VACANCIES_TO_RECRUITERS",
                        column: x => x.RECRUITER_ID,
                        principalTable: "RECRUITERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VACANCIES_TO_WORK_AREAS",
                        column: x => x.WORK_AREA_ID,
                        principalTable: "WORK_AREAS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EDUCATION_PERIODS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    START_DATE = table.Column<DateTime>(type: "date", nullable: false),
                    FINISH_DATE = table.Column<DateTime>(type: "date", nullable: false),
                    SCHOOL_ID = table.Column<int>(nullable: false),
                    RESUME_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDUCATION_PERIODS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PK_EDUCATION_PERIODS_TO_RESUMES",
                        column: x => x.RESUME_ID,
                        principalTable: "RESUMES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PK_EDUCATION_PERIODS_TO_SCHOOLS",
                        column: x => x.SCHOOL_ID,
                        principalTable: "SCHOOLS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EXPERIENCES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    COMPANY_NAME = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    POSITION = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    START_DATE = table.Column<DateTime>(type: "date", nullable: false),
                    FINISH_DATE = table.Column<DateTime>(type: "date", nullable: true),
                    RESUME_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXPERIENCES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EXPERIENCES_TO_RESUMES",
                        column: x => x.RESUME_ID,
                        principalTable: "RESUMES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RESUME_LANGUAGES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RESUME_ID = table.Column<int>(nullable: false),
                    LANGUAGE_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESUME_LANGUAGES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PK_RESUME_LANGUAGES_TO_LANGUAGES",
                        column: x => x.LANGUAGE_ID,
                        principalTable: "LANGUAGES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PK_RESUME_LANGUAGES_TO_RESUMES",
                        column: x => x.RESUME_ID,
                        principalTable: "RESUMES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FAVORITE_VACANCIES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VACANCY_ID = table.Column<int>(nullable: false),
                    USER_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAVORITE_VACANCIES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FAVORITE_VACANCIES_TO_USERS",
                        column: x => x.USER_ID,
                        principalTable: "USERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FAVORITE_VACANCIES_TO_VACANCIES",
                        column: x => x.VACANCY_ID,
                        principalTable: "VACANCIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CITIES",
                columns: new[] { "ID", "NAME" },
                values: new object[,]
                {
                    { 1, "Lviv" },
                    { 2, "Kyiv" },
                    { 3, "Dnipro" }
                });

            migrationBuilder.InsertData(
                table: "LANGUAGES",
                columns: new[] { "ID", "NAME" },
                values: new object[,]
                {
                    { 1, "English" },
                    { 2, "Ukrainian" },
                    { 3, "Russian" }
                });

            migrationBuilder.InsertData(
                table: "ROLES",
                columns: new[] { "ID", "NAME" },
                values: new object[,]
                {
                    { 1, "admin" },
                    { 2, "user" }
                });

            migrationBuilder.InsertData(
                table: "SCHOOLS",
                columns: new[] { "ID", "NAME" },
                values: new object[,]
                {
                    { 1, "NU LP" },
                    { 2, "LNU" },
                    { 3, "KPI" }
                });

            migrationBuilder.InsertData(
                table: "WORK_AREAS",
                columns: new[] { "ID", "NAME", "PHOTO_DATA", "PHOTO_MIMETYPE" },
                values: new object[,]
                {
                    { 1, "IT", null, null },
                    { 2, "Sales", null, null },
                    { 3, "Medicine", null, null }
                });

            migrationBuilder.InsertData(
                table: "COMPANIES",
                columns: new[] { "ID", "ADDRESS", "BOSS_NAME", "EMAIL", "FULL_DESCRIPTION", "LOGO_DATA", "LOGO_MIMETYPE", "NAME", "PASSWORD", "PHONE", "ROLE_ID", "SHORT_DESCRIPTION", "SITE" },
                values: new object[,]
                {
                    { 1, "38347 King Circles, New Lorena, Gibraltar", "Kadin", "Edison.Kovacek77@hotmail.com", "Neque laborum vel qui ex vitae provident laboriosam.", null, null, "Company № 914", "22np1428du", "073 8145", 1, "voluptatem", "http://candice.org" },
                    { 10, "5613 Beatty Ramp, East Saigemouth, Jamaica", "Mya", "Bryon_OConnell30@hotmail.com", "Excepturi totam aliquid consequatur error repudiandae nisi libero quasi.", null, null, "Company № 219", "aFFLz1wY6a", "073 4527", 2, "earum", "https://jayce.com" },
                    { 8, "315 Zemlak Lights, West Annabel, Liberia", "Adella", "Catalina95@hotmail.com", "Numquam molestias et est sit.", null, null, "Company № 801", "VWlpTveR6V", "073 602", 2, "molestiae", "https://sarina.info" },
                    { 7, "7200 Lorenzo Prairie, Lakinshire, Hungary", "Merle", "Elian_Hettinger@yahoo.com", "Aut voluptas velit et aut.", null, null, "Company № 881", "gVKDVar_J6", "073 8114", 2, "cum", "https://shemar.com" },
                    { 6, "055 Jewell Village, Willside, Mozambique", "Delbert", "Easton_Klocko67@hotmail.com", "Non sed sequi est iste ut iste sed sunt.", null, null, "Company № 830", "KLOTMdLQzK", "073 7057", 2, "et", "https://shaina.info" },
                    { 3, "166 Sawayn Shoals, Lake Stella, Saint Vincent and the Grenadines", "Dante", "Hudson87@gmail.com", "Fugiat sint aliquid dolores voluptatibus.", null, null, "Company № 644", "rk8ttnU2nP", "073 9359", 2, "ea", "http://jalen.biz" },
                    { 9, "043 Hegmann Circles, Vivienneborough, Denmark", "Marlin", "Reed.Cronin67@yahoo.com", "Consequuntur accusamus eum.", null, null, "Company № 707", "Dq0rz2nbgj", "073 9071", 2, "corporis", "http://ansel.name" },
                    { 5, "671 Turner Drive, Port Juwanbury, Slovenia", "Toni", "Rosalinda_Miller@hotmail.com", "Illum velit ratione itaque aliquid recusandae.", null, null, "Company № 356", "F43XlcFKFR", "073 2323", 1, "doloremque", "https://shane.info" },
                    { 4, "79419 Rempel Glen, West Keonberg, Vanuatu", "Willa", "Nettie1@yahoo.com", "Eveniet ea debitis expedita consequatur consequatur.", null, null, "Company № 396", "Nyfi7cBV2o", "073 80", 1, "consequatur", "https://eldridge.com" },
                    { 2, "0956 Kelton Estates, West Anthonymouth, Oman", "Calista", "Dino_Howell@yahoo.com", "Fugit ducimus suscipit.", null, null, "Company № 20", "vx6l_0YTvg", "073 9896", 1, "ab", "https://jon.name" }
                });

            migrationBuilder.InsertData(
                table: "FACULTIES",
                columns: new[] { "ID", "NAME", "SCHOOL_ID" },
                values: new object[,]
                {
                    { 17, "Applied Mathematics", 3 },
                    { 15, "Computer Science", 3 },
                    { 11, "Software Engineering", 3 },
                    { 14, "Applied Mathematics", 2 },
                    { 12, "Applied Mathematics", 2 },
                    { 16, "Applied Mathematics", 3 },
                    { 20, "Applied Mathematics", 1 },
                    { 19, "Computer Science", 1 },
                    { 18, "Applied Mathematics", 1 },
                    { 13, "Software Engineering", 1 }
                });

            migrationBuilder.InsertData(
                table: "USERS",
                columns: new[] { "ID", "ADDRESS", "BIRTH_DATA", "CITY_ID", "EMAIL", "FIRST_NAME", "LAST_NAME", "PASSWORD", "PHONE", "PHOTO_DATA", "PHOTO_MIME_TYPE", "ROLE_ID", "SEX" },
                values: new object[,]
                {
                    { 47, "Therese Ports", "2012-02-21T18:10:00", 1, "Karlie_Sanford8@yahoo.com", "Irwin", "MacGyver", "Fflsg3ql6k", "073 5264", null, null, 2, "m" },
                    { 45, "Lueilwitz Flat", "2012-02-21T18:10:00", 2, "Lorenzo_Hirthe@yahoo.com", "Sophia", "Hamill", "nPJ18S6685", "073 904", null, null, 1, "m" },
                    { 44, "Rau Trail", "2012-02-21T18:10:00", 2, "Mavis_Johnson@hotmail.com", "Cayla", "Rodriguez", "MZVaa3wRne", "073 1567", null, null, 2, "f" },
                    { 42, "Kobe Ranch", "2012-02-21T18:10:00", 2, "Noe_Jast75@gmail.com", "Frederik", "Hyatt", "kgilAcvKyB", "073 8289", null, null, 2, "f" },
                    { 41, "Kenneth Landing", "2012-02-21T18:10:00", 2, "Jordan54@hotmail.com", "Miles", "Doyle", "AKCh652gdn", "073 2285", null, null, 1, "f" },
                    { 43, "Beer Isle", "2012-02-21T18:10:00", 3, "Princess77@hotmail.com", "Isabelle", "Kuvalis", "jZA7IOJC7M", "073 8094", null, null, 1, "m" },
                    { 49, "Torphy Villages", "2012-02-21T18:10:00", 2, "Iva.Stiedemann@hotmail.com", "Kristopher", "Roob", "HCrxowzI9R", "073 2866", null, null, 1, "m" },
                    { 48, "Ida Bridge", "2012-02-21T18:10:00", 3, "Lucienne_Hills46@gmail.com", "Alfredo", "Purdy", "By0B_k75e_", "073 5054", null, null, 1, "f" },
                    { 50, "Josiah Inlet", "2012-02-21T18:10:00", 1, "Jennings.Barrows@gmail.com", "Ebba", "Hessel", "ydHeVeqmpr", "073 2471", null, null, 2, "m" },
                    { 46, "Janae Points", "2012-02-21T18:10:00", 1, "Elza_Morar@yahoo.com", "Ella", "Stracke", "Q2EIc2rDST", "073 1292", null, null, 1, "m" }
                });

            migrationBuilder.InsertData(
                table: "RECRUITERS",
                columns: new[] { "ID", "COMPANY_ID", "EMAIL", "FIRST_NAME", "LAST_NAME", "PASSWORD", "PHONE", "ROLE_ID" },
                values: new object[,]
                {
                    { 26, 1, "Anastacio51@hotmail.com", "Beth", "Morissette", "Gam6gUS7V1", "073 5877", 2 },
                    { 30, 1, "Dario46@gmail.com", "Nathanial", "Lang", "A0_3ozXZT6", "073 6249", 1 },
                    { 21, 2, "Wilhelmine_Wisozk@hotmail.com", "Alek", "Roob", "bSlOqa1uBi", "073 6554", 2 },
                    { 22, 4, "Lavern.Lind80@gmail.com", "Avis", "Brakus", "bIKPgHgq0A", "073 9573", 2 },
                    { 24, 4, "Roberta_VonRueden@gmail.com", "Gertrude", "Hintz", "hZYb9rij99", "073 9312", 2 },
                    { 28, 5, "Haven_Lueilwitz97@hotmail.com", "Marielle", "D'Amore", "8B4zU1f4ZA", "073 3240", 2 },
                    { 25, 6, "Greg81@yahoo.com", "Valentine", "Dietrich", "L5D3sHerRY", "073 739", 1 },
                    { 23, 7, "Ardella30@hotmail.com", "Zena", "Howe", "jf9MWiVa7q", "073 8576", 2 },
                    { 27, 9, "Ron.Marvin66@yahoo.com", "Kasey", "Nienow", "L3sqVFbmdQ", "073 5791", 2 },
                    { 29, 10, "Maudie.Rice66@yahoo.com", "Walter", "DuBuque", "gFGzc0dsUj", "073 2859", 1 }
                });

            migrationBuilder.InsertData(
                table: "RESUMES",
                columns: new[] { "ID", "COURSES", "CREATE_DATE", "FACEBOOK", "FAMILY_STATE", "GITHUB", "INSTAGRAM", "KEY_SKILLS", "LINKEDIN", "MOD_DATE", "SKYPE", "SOFT_SKILLS", "WORK_AREA_ID" },
                values: new object[,]
                {
                    { 48, "A quas quod nostrum impedit.", "2012-02-21T18:10:00", "http://dell.net", "Velit.", "https://minnie.org", "http://meda.net", "Vero quia illo quaerat et.", "https://dave.name", "2012-02-21T18:10:00", "http://jerad.net", "Non corrupti officia et vero ad animi aut qui.", 3 },
                    { 42, "Est in voluptatem aspernatur enim.", "2012-02-21T18:10:00", "https://jermey.net", "Architecto.", "https://cheyanne.info", "https://loma.name", "Non nihil eligendi et sed quidem iusto quos molestias et.", "https://billie.biz", "2012-02-21T18:10:00", "http://leonel.com", "Autem et impedit nihil reiciendis.", 2 }
                });

            migrationBuilder.InsertData(
                table: "EDUCATION_PERIODS",
                columns: new[] { "ID", "FINISH_DATE", "RESUME_ID", "SCHOOL_ID", "START_DATE" },
                values: new object[,]
                {
                    { 70, "2012-02-21T18:10:00", 48, 3, "2012-02-21T18:10:00" },
                    { 72, "2012-02-21T18:10:00", 42, 1, "2012-02-21T18:10:00" },
                    { 66, "2012-02-21T18:10:00", 42, 1, "2012-02-21T18:10:00" },
                    { 64, "2012-02-21T18:10:00", 42, 2, "2012-02-21T18:10:00" },
                    { 65, "2012-02-21T18:10:00", 48, 3, "2012-02-21T18:10:00" },
                    { 67, "2012-02-21T18:10:00", 48, 3, "2012-02-21T18:10:00" },
                    { 68, "2012-02-21T18:10:00", 48, 2, "2012-02-21T18:10:00" },
                    { 69, "2012-02-21T18:10:00", 48, 2, "2012-02-21T18:10:00" },
                    { 71, "2012-02-21T18:10:00", 48, 3, "2012-02-21T18:10:00" },
                    { 63, "2012-02-21T18:10:00", 42, 1, "2012-02-21T18:10:00" }
                });

            migrationBuilder.InsertData(
                table: "EXPERIENCES",
                columns: new[] { "ID", "COMPANY_NAME", "FINISH_DATE", "POSITION", "RESUME_ID", "START_DATE" },
                values: new object[,]
                {
                    { 60, "Ivah Boyer", "2012-02-21T18:10:00", "Molestiae nostrum excepturi voluptatem atque ipsa vero vero.", 42, "2012-02-21T18:10:00" },
                    { 59, "Ilene Kerluke", "2012-02-21T18:10:00", "Exercitationem quia expedita beatae.", 42, "2012-02-21T18:10:00" },
                    { 57, "Lupe Rowe", "2012-02-21T18:10:00", "Fugiat autem et.", 42, "2012-02-21T18:10:00" },
                    { 58, "Robert Kihn", "2012-02-21T18:10:00", "Ut asperiores nulla architecto praesentium repudiandae velit quo sunt.", 42, "2012-02-21T18:10:00" },
                    { 55, "Marcelino Frami", "2012-02-21T18:10:00", "Eligendi incidunt nihil.", 48, "2012-02-21T18:10:00" },
                    { 53, "Nat Prosacco", "2012-02-21T18:10:00", "Saepe earum repellat cum a quidem explicabo sed eius rerum.", 48, "2012-02-21T18:10:00" },
                    { 62, "Elyse Denesik", "2012-02-21T18:10:00", "Id nihil quo porro.", 42, "2012-02-21T18:10:00" },
                    { 54, "America Casper", "2012-02-21T18:10:00", "Sapiente accusantium porro.", 42, "2012-02-21T18:10:00" },
                    { 56, "Jordi Douglas", "2012-02-21T18:10:00", "Et explicabo incidunt maxime rerum tempore delectus sit animi nihil.", 48, "2012-02-21T18:10:00" },
                    { 61, "Faye Parisian", "2012-02-21T18:10:00", "Nesciunt rerum aspernatur eum libero nihil omnis voluptas dolorum.", 42, "2012-02-21T18:10:00" }
                });

            migrationBuilder.InsertData(
                table: "RESUME_LANGUAGES",
                columns: new[] { "ID", "LANGUAGE_ID", "RESUME_ID" },
                values: new object[,]
                {
                    { 74, 1, 48 },
                    { 82, 2, 48 },
                    { 77, 3, 48 },
                    { 76, 1, 48 },
                    { 73, 3, 42 },
                    { 75, 2, 42 },
                    { 78, 1, 42 },
                    { 79, 1, 42 },
                    { 80, 1, 42 },
                    { 81, 1, 42 }
                });

            migrationBuilder.InsertData(
                table: "VACANCIES",
                columns: new[] { "ID", "BE_PLUS", "CITY_ID", "CREATE_DATE", "DESCRIPTION", "FULL_PART_TIME", "IS_CHECKED", "MOD_DATE", "NAME", "OFFERING", "RECRUITER_ID", "REQUIREMENTS", "SALARY", "WORK_AREA_ID" },
                values: new object[,]
                {
                    { 33, "Quia aperiam minus quis fugiat.", 1, "2012-02-21T18:10:00", "Lead", "Part-time", true, "2012-02-21T18:10:00", "Global Solutions Facilitator", "Freeda Kub", 25, "Labore veritatis qui ea eum est alias animi neque.", 1000m, 1 },
                    { 31, "Totam hic itaque et dolor eaque.", 3, "2012-02-21T18:10:00", "Internal", "Full-time", true, "2012-02-21T18:10:00", "Principal Directives Producer", "Trever Rolfson", 29, "Nihil commodi officia animi amet aut.", 1000m, 2 },
                    { 34, "Animi alias dolor dolorum.", 2, "2012-02-21T18:10:00", "Chief", "Full-time", true, "2012-02-21T18:10:00", "Lead Intranet Engineer", "Zita Zulauf", 23, "Esse quod beatae est est voluptatem molestias et mollitia sed.", 1000m, 3 },
                    { 32, "Maxime corporis ab id dolorem quisquam consequuntur velit dolorem voluptatem.", 3, "2012-02-21T18:10:00", "Dynamic", "Full-time", true, "2012-02-21T18:10:00", "Dynamic Paradigm Liaison", "Jamey Murphy", 25, "Iure itaque voluptatem ut aspernatur.", 1000m, 3 },
                    { 35, "Quam nostrum debitis cumque.", 2, "2012-02-21T18:10:00", "Regional", "Full-time", false, "2012-02-21T18:10:00", "International Quality Director", "Percival Berge", 28, "Et quam illum omnis.", 1000m, 2 },
                    { 40, "Ut blanditiis sit sunt qui non aperiam voluptatem nesciunt qui.", 2, "2012-02-21T18:10:00", "Internal", "Full-time", true, "2012-02-21T18:10:00", "Regional Quality Associate", "Jude Lindgren", 22, "Modi exercitationem aut.", 1000m, 3 },
                    { 39, "Ut quo repudiandae eligendi dolores nobis autem accusamus.", 2, "2012-02-21T18:10:00", "Customer", "Full-time", false, "2012-02-21T18:10:00", "Dynamic Response Manager", "Catharine Runte", 22, "Dolorem repellendus libero et repellat vel laudantium error minima.", 1000m, 2 },
                    { 37, "Reprehenderit eos consequatur ut sapiente.", 2, "2012-02-21T18:10:00", "Principal", "Full-time", true, "2012-02-21T18:10:00", "Central Mobility Planner", "Juliet Fisher", 22, "Omnis deserunt inventore ex non omnis similique sed provident aut.", 1000m, 1 },
                    { 38, "Eum quos velit.", 1, "2012-02-21T18:10:00", "Regional", "Full-time", true, "2012-02-21T18:10:00", "Human Usability Analyst", "Izaiah Ziemann", 29, "Rerum nam eligendi quia animi saepe.", 1000m, 3 },
                    { 36, "Repudiandae enim assumenda nostrum laboriosam quia.", 2, "2012-02-21T18:10:00", "Lead", "Full-time", true, "2012-02-21T18:10:00", "Corporate Infrastructure Assistant", "Alysa Bechtelar", 21, "Velit quis ipsam quas tempore.", 1000m, 2 }
                });

            migrationBuilder.InsertData(
                table: "FAVORITE_VACANCIES",
                columns: new[] { "ID", "USER_ID", "VACANCY_ID" },
                values: new object[,]
                {
                    { 86, 46, 37 },
                    { 88, 41, 37 },
                    { 89, 45, 37 },
                    { 91, 41, 37 },
                    { 84, 49, 35 },
                    { 85, 48, 35 },
                    { 87, 46, 35 },
                    { 92, 45, 32 },
                    { 83, 47, 31 },
                    { 90, 44, 38 }
                });

            migrationBuilder.CreateIndex(
                name: "UQ_CITIES_NAME",
                table: "CITIES",
                column: "NAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_COMPANIES_ADDRESS",
                table: "COMPANIES",
                column: "ADDRESS",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_COMPANIES_EMAIL",
                table: "COMPANIES",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_COMPANIES_NAME",
                table: "COMPANIES",
                column: "NAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_COMPANIES_PHONE",
                table: "COMPANIES",
                column: "PHONE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_COMPANIES_ROLE_ID",
                table: "COMPANIES",
                column: "ROLE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EDUCATION_PERIODS_RESUME_ID",
                table: "EDUCATION_PERIODS",
                column: "RESUME_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EDUCATION_PERIODS_SCHOOL_ID",
                table: "EDUCATION_PERIODS",
                column: "SCHOOL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EXPERIENCES_RESUME_ID",
                table: "EXPERIENCES",
                column: "RESUME_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FACULTIES_SCHOOL_ID",
                table: "FACULTIES",
                column: "SCHOOL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FAVORITE_VACANCIES_USER_ID",
                table: "FAVORITE_VACANCIES",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FAVORITE_VACANCIES_VACANCY_ID",
                table: "FAVORITE_VACANCIES",
                column: "VACANCY_ID");

            migrationBuilder.CreateIndex(
                name: "UQ_LANGUAGES_NAME",
                table: "LANGUAGES",
                column: "NAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RECRUITERS_COMPANY_ID",
                table: "RECRUITERS",
                column: "COMPANY_ID");

            migrationBuilder.CreateIndex(
                name: "UQ_RECRUITERS_EMAIL",
                table: "RECRUITERS",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_RECRUITERS_PHONE",
                table: "RECRUITERS",
                column: "PHONE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RECRUITERS_ROLE_ID",
                table: "RECRUITERS",
                column: "ROLE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RESUME_LANGUAGES_LANGUAGE_ID",
                table: "RESUME_LANGUAGES",
                column: "LANGUAGE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RESUME_LANGUAGES_RESUME_ID",
                table: "RESUME_LANGUAGES",
                column: "RESUME_ID");

            migrationBuilder.CreateIndex(
                name: "UQ_RESUMES_FACEBOOK",
                table: "RESUMES",
                column: "FACEBOOK",
                unique: true,
                filter: "[FACEBOOK] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ_RESUMES_INSTAGRAM",
                table: "RESUMES",
                column: "INSTAGRAM",
                unique: true,
                filter: "[INSTAGRAM] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ_RESUMES_LINKEDIN",
                table: "RESUMES",
                column: "LINKEDIN",
                unique: true,
                filter: "[LINKEDIN] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ_RESUMES_SKYPE",
                table: "RESUMES",
                column: "SKYPE",
                unique: true,
                filter: "[SKYPE] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RESUMES_WORK_AREA_ID",
                table: "RESUMES",
                column: "WORK_AREA_ID");

            migrationBuilder.CreateIndex(
                name: "UQ_ROLES_NAME",
                table: "ROLES",
                column: "NAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_SCHOOLS_NAME",
                table: "SCHOOLS",
                column: "NAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USERS_CITY_ID",
                table: "USERS",
                column: "CITY_ID");

            migrationBuilder.CreateIndex(
                name: "UQ_USERS_EMAIL",
                table: "USERS",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_USERS_PHONE",
                table: "USERS",
                column: "PHONE",
                unique: true,
                filter: "[PHONE] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_ROLE_ID",
                table: "USERS",
                column: "ROLE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_VACANCIES_CITY_ID",
                table: "VACANCIES",
                column: "CITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_VACANCIES_RECRUITER_ID",
                table: "VACANCIES",
                column: "RECRUITER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_VACANCIES_WORK_AREA_ID",
                table: "VACANCIES",
                column: "WORK_AREA_ID");

            migrationBuilder.CreateIndex(
                name: "UQ_WORK_AREAS_NAME",
                table: "WORK_AREAS",
                column: "NAME",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EDUCATION_PERIODS");

            migrationBuilder.DropTable(
                name: "EXPERIENCES");

            migrationBuilder.DropTable(
                name: "FACULTIES");

            migrationBuilder.DropTable(
                name: "FAVORITE_VACANCIES");

            migrationBuilder.DropTable(
                name: "RESUME_LANGUAGES");

            migrationBuilder.DropTable(
                name: "SCHOOLS");

            migrationBuilder.DropTable(
                name: "VACANCIES");

            migrationBuilder.DropTable(
                name: "LANGUAGES");

            migrationBuilder.DropTable(
                name: "RESUMES");

            migrationBuilder.DropTable(
                name: "RECRUITERS");

            migrationBuilder.DropTable(
                name: "USERS");

            migrationBuilder.DropTable(
                name: "WORK_AREAS");

            migrationBuilder.DropTable(
                name: "COMPANIES");

            migrationBuilder.DropTable(
                name: "CITIES");

            migrationBuilder.DropTable(
                name: "ROLES");
        }
    }
}
