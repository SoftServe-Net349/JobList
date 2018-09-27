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
                    { 2, "958 Bayer Crest, West Brennaview, Austria", "Lazaro", "Hildegard86@yahoo.com", "Impedit magnam ex.", null, null, "Company № 213", "WdpB2WG5kr", "073 6007", 1, "maxime", "http://fredy.biz" },
                    { 5, "0534 Edwina Hills, Abernathyton, Barbados", "Karen", "Linnea_Block@yahoo.com", "Ex sit inventore est dignissimos dolor quaerat et.", null, null, "Company № 230", "LfOjv9pUuT", "073 7243", 2, "ut", "https://kellie.info" },
                    { 4, "7948 Trace Drive, Orieland, Canada", "Tabitha", "Adam.Hickle84@yahoo.com", "Quo mollitia nobis ullam saepe itaque sit tempora nemo.", null, null, "Company № 46", "XcvBlqAXTL", "073 5053", 2, "et", "http://alfred.net" },
                    { 10, "2692 Magdalen Key, Port Ayla, Nauru", "Rhoda", "Erwin.Ritchie86@yahoo.com", "Aspernatur doloremque facere laudantium nihil quidem.", null, null, "Company № 773", "0ir7jufMq2", "073 9064", 1, "quis", "http://bridie.org" },
                    { 9, "67006 Runte Place, Goldnerfurt, Reunion", "Neha", "Mikel54@yahoo.com", "Iure commodi molestiae sit aspernatur sunt voluptates alias.", null, null, "Company № 147", "BdX4IqF8EX", "073 579", 1, "recusandae", "https://lori.biz" },
                    { 1, "161 Laurine Ports, Monserratmouth, Rwanda", "Ludie", "Reinhold_Schimmel66@gmail.com", "Qui doloribus qui libero.", null, null, "Company № 832", "VSEm34uDiT", "073 6449", 2, "nihil", "https://briana.info" },
                    { 7, "96985 Hyman Way, North Kelvin, Turkey", "Arjun", "Nikita9@hotmail.com", "Eum ratione placeat nulla praesentium dolore sed culpa.", null, null, "Company № 883", "GnePxPG8fx", "073 3894", 1, "ex", "https://keshawn.biz" },
                    { 6, "188 Quigley Springs, Smithmouth, Suriname", "Mathias", "Jennings65@yahoo.com", "Delectus fuga est aliquam ut in veniam.", null, null, "Company № 984", "s8iKdDw4BD", "073 608", 1, "id", "http://claudie.org" },
                    { 3, "3799 Fletcher Shoal, Carrollview, Democratic People's Republic of Korea", "Annabell", "Mervin73@gmail.com", "Perspiciatis accusantium quis rem dolores.", null, null, "Company № 664", "rWX75tmtEk", "073 4121", 1, "quia", "http://marilou.info" },
                    { 8, "8757 Norbert Ranch, Armstrongtown, Cayman Islands", "Curt", "Verona31@gmail.com", "Accusamus quo et.", null, null, "Company № 145", "RhF1SD6DhT", "073 2124", 1, "ut", "https://effie.com" }
                });

            migrationBuilder.InsertData(
                table: "FACULTIES",
                columns: new[] { "ID", "NAME", "SCHOOL_ID" },
                values: new object[,]
                {
                    { 20, "Software Engineering", 2 },
                    { 18, "Computer Science", 2 },
                    { 16, "Applied Mathematics", 2 },
                    { 12, "Software Engineering", 2 },
                    { 19, "Applied Mathematics", 1 },
                    { 17, "Software Engineering", 1 },
                    { 15, "Software Engineering", 1 },
                    { 14, "Applied Mathematics", 1 },
                    { 13, "Computer Science", 3 },
                    { 11, "Computer Science", 3 }
                });

            migrationBuilder.InsertData(
                table: "USERS",
                columns: new[] { "ID", "ADDRESS", "BIRTH_DATA", "CITY_ID", "EMAIL", "FIRST_NAME", "LAST_NAME", "PASSWORD", "PHONE", "PHOTO_DATA", "PHOTO_MIME_TYPE", "ROLE_ID", "SEX" },
                values: new object[,]
                {
                    { 49, "Lexus Viaduct", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Clemmie.Turner2@gmail.com", "Aliyah", "Cummings", "MF7YWFiDa3", "073 8830", null, null, 2, "m" },
                    { 50, "Bednar Ridges", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Marcelo.Muller37@yahoo.com", "Raina", "Kozey", "P6d5Nttho6", "073 7794", null, null, 1, "f" },
                    { 48, "Eudora Summit", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Eloise_Borer47@gmail.com", "Noel", "Prosacco", "r3Xuyu83AS", "073 202", null, null, 1, "m" },
                    { 47, "Waters Grove", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Betty.Friesen@yahoo.com", "Jameson", "Haag", "47MpFsWwl1", "073 8041", null, null, 1, "f" },
                    { 46, "Guy Corners", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Paul_Schaden89@hotmail.com", "Alice", "Lubowitz", "uIApO3UCYO", "073 3374", null, null, 1, "m" },
                    { 45, "Keebler Streets", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Royal70@yahoo.com", "Rosario", "Kihn", "t4EnqCfoG5", "073 4951", null, null, 1, "m" },
                    { 44, "Marie Crossing", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Karli_Hamill@gmail.com", "Josiah", "O'Kon", "QeSe7Rwun3", "073 9582", null, null, 1, "m" },
                    { 42, "Darius Trafficway", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Stevie42@hotmail.com", "Jarrod", "Gutkowski", "huDR7bjRP1", "073 222", null, null, 1, "f" },
                    { 43, "Cole Parkways", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Kris8@gmail.com", "Elsa", "Wisoky", "ljrohDjQud", "073 6026", null, null, 2, "m" },
                    { 41, "Talon Estate", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dora33@gmail.com", "Leanne", "Connelly", "OJKPPiroRt", "073 747", null, null, 2, "m" }
                });

            migrationBuilder.InsertData(
                table: "RECRUITERS",
                columns: new[] { "ID", "COMPANY_ID", "EMAIL", "FIRST_NAME", "LAST_NAME", "PASSWORD", "PHONE", "ROLE_ID" },
                values: new object[,]
                {
                    { 26, 3, "Cooper5@gmail.com", "Benedict", "Sawayn", "_K877bRQJm", "073 1220", 2 },
                    { 28, 3, "Bryce.Leffler@hotmail.com", "Derrick", "Metz", "MjBpxgMCE3", "073 8934", 1 },
                    { 21, 6, "Jessika87@yahoo.com", "Lewis", "Ward", "H9yqDZBF43", "073 8169", 2 },
                    { 24, 6, "Jerel_Mante83@hotmail.com", "Fredrick", "Feeney", "wiIyaLXCuA", "073 6659", 1 },
                    { 27, 6, "Pamela.Lemke27@yahoo.com", "Neil", "Mueller", "xEyuYyhOar", "073 8439", 1 },
                    { 23, 7, "Amaya21@gmail.com", "Don", "Lemke", "2Mht3s5LdQ", "073 8631", 2 },
                    { 22, 9, "Madisen_Brekke@hotmail.com", "Leonard", "Kozey", "EdEuasUoPf", "073 1722", 2 },
                    { 25, 9, "Vincent21@yahoo.com", "Antonina", "Nienow", "_vmOr8k9Px", "073 4579", 1 },
                    { 29, 1, "Collin_Ledner@yahoo.com", "Haylie", "Medhurst", "DcExG2ewF1", "073 3398", 1 },
                    { 30, 5, "Daniela73@yahoo.com", "Robb", "Wehner", "on9yXXCKu7", "073 8285", 1 }
                });

            migrationBuilder.InsertData(
                table: "RESUMES",
                columns: new[] { "ID", "COURSES", "CREATE_DATE", "FACEBOOK", "FAMILY_STATE", "GITHUB", "INSTAGRAM", "KEY_SKILLS", "LINKEDIN", "MOD_DATE", "SKYPE", "SOFT_SKILLS", "WORK_AREA_ID" },
                values: new object[,]
                {
                    { 42, "Doloribus consequatur velit possimus sint qui accusamus.", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://faye.com", "Illum.", "https://randy.biz", "https://adelia.name", "Voluptatum aspernatur saepe in quaerat et natus inventore hic magnam.", "http://terence.biz", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://jude.name", "Totam tempora qui ad sint ducimus necessitatibus.", 1 },
                    { 44, "Laboriosam cupiditate officiis.", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://rodrigo.biz", "Quia.", "https://ellsworth.net", "http://morris.info", "Possimus doloremque dolorem error inventore rem voluptatum magni.", "http://hilma.net", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://cornell.info", "Est omnis atque delectus deserunt.", 1 }
                });

            migrationBuilder.InsertData(
                table: "EDUCATION_PERIODS",
                columns: new[] { "ID", "FINISH_DATE", "RESUME_ID", "SCHOOL_ID", "START_DATE" },
                values: new object[,]
                {
                    { 67, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, 3, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 72, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 71, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 70, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, 3, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 66, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 42, 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 69, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 42, 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 68, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, 3, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "EXPERIENCES",
                columns: new[] { "ID", "COMPANY_NAME", "FINISH_DATE", "POSITION", "RESUME_ID", "START_DATE" },
                values: new object[,]
                {
                    { 59, "Tony Hilll", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maiores aut quam temporibus dolor nobis officiis at et sequi.", 44, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, "Tanya Dicki", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Voluptatibus quo pariatur omnis earum.", 44, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, "Brennon Sipes", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quis at earum et aliquam qui dolore quo quidem.", 44, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 54, "Billy Nicolas", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Architecto harum fuga quis odit.", 44, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, "Mercedes Kutch", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Expedita aspernatur nihil recusandae et saepe et enim fugiat molestiae.", 42, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, "Angel Herzog", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quis eveniet qui non aut delectus eius.", 42, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, "Bonita Hermann", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adipisci voluptas quibusdam quia tenetur.", 42, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, "Gregg Lebsack", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quasi excepturi voluptatum amet impedit consequatur dolorem qui.", 42, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, "Domenica Herman", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Molestias nam quisquam possimus explicabo.", 42, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, "Saul Dickinson", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dolorem rerum sunt.", 44, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "RESUME_LANGUAGES",
                columns: new[] { "ID", "LANGUAGE_ID", "RESUME_ID" },
                values: new object[,]
                {
                    { 79, 2, 42 },
                    { 74, 3, 44 },
                    { 75, 3, 44 },
                    { 76, 1, 44 },
                    { 77, 2, 44 },
                    { 78, 1, 44 },
                    { 80, 3, 44 },
                    { 81, 3, 44 },
                    { 82, 1, 44 },
                    { 73, 1, 44 }
                });

            migrationBuilder.InsertData(
                table: "VACANCIES",
                columns: new[] { "ID", "BE_PLUS", "CITY_ID", "CREATE_DATE", "DESCRIPTION", "FULL_PART_TIME", "IS_CHECKED", "MOD_DATE", "NAME", "OFFERING", "RECRUITER_ID", "REQUIREMENTS", "SALARY", "WORK_AREA_ID" },
                values: new object[,]
                {
                    { 33, "Autem et id eum nemo labore ut ab.", 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senior", "Full-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lead Tactics Administrator", "Jamarcus Harber", 26, "Aspernatur quia a est nemo sit omnis quis similique placeat.", 1000m, 3 },
                    { 39, "Odit occaecati officiis ea ullam reiciendis quia error.", 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dynamic", "Part-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "National Quality Consultant", "Dorothea Lebsack", 22, "Officiis velit magni minima omnis.", 1000m, 3 },
                    { 37, "Quibusdam ipsa omnis quas.", 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "National", "Full-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Regional Configuration Agent", "Clement Dare", 22, "Qui ipsa voluptatem excepturi porro sunt atque iusto nam molestias.", 1000m, 2 },
                    { 40, "Vel dolores dolores eligendi voluptas et voluptas corrupti iusto.", 3, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dynamic", "Part-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lead Interactions Supervisor", "Herman Turner", 23, "Amet et inventore molestias.", 1000m, 1 },
                    { 35, "Debitis totam minus nihil nihil corrupti omnis dignissimos recusandae non.", 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chief", "Part-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chief Interactions Planner", "Hugh Schulist", 27, "Eius velit molestiae.", 1000m, 3 },
                    { 32, "Consectetur eius non incidunt ipsum quidem et eos maxime deserunt.", 3, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product", "Full-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Investor Applications Facilitator", "Alden Walker", 24, "Tenetur dolores ut ad voluptatem voluptatem nihil soluta et amet.", 1000m, 3 },
                    { 34, "Dolor nulla esse voluptate quia omnis.", 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Internal", "Part-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Internal Factors Producer", "Ellsworth Gutmann", 21, "Eos consequatur sunt explicabo magnam dolorum et.", 1000m, 3 },
                    { 36, "Earum ut earum deserunt nulla.", 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Direct", "Part-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Regional Accounts Representative", "General Becker", 26, "Reprehenderit aperiam et adipisci excepturi enim unde facilis saepe.", 1000m, 3 },
                    { 31, "Illo quaerat eos rerum praesentium mollitia totam illo quis recusandae.", 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Global", "Part-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Direct Web Manager", "Elvis Hessel", 30, "Sed cupiditate quis doloribus temporibus voluptas rerum eligendi distinctio illum.", 1000m, 3 },
                    { 38, "Pariatur tempora perspiciatis est.", 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dynamic", "Part-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "District Markets Officer", "Walton Mills", 30, "Dolores est suscipit et.", 1000m, 1 }
                });

            migrationBuilder.InsertData(
                table: "FAVORITE_VACANCIES",
                columns: new[] { "ID", "USER_ID", "VACANCY_ID" },
                values: new object[,]
                {
                    { 83, 47, 36 },
                    { 86, 43, 34 },
                    { 92, 46, 34 },
                    { 87, 44, 40 },
                    { 88, 46, 40 },
                    { 90, 48, 40 },
                    { 85, 42, 39 },
                    { 91, 45, 39 },
                    { 84, 50, 31 },
                    { 89, 42, 38 }
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
