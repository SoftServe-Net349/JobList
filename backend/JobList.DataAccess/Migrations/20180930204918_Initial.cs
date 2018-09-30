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
                name: "FACULTIES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    NAME = table.Column<string>(unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FACULTIES", x => x.ID);
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
                    ID = table.Column<int>(nullable: false),
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
                name: "RECRUITERS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FIRST_NAME = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    LAST_NAME = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    PHONE = table.Column<string>(unicode: false, maxLength: 15, nullable: false),
                    LOGO_DATA = table.Column<byte[]>(nullable: true),
                    LOGO_MIMETYPE = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
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
                    FACULTY_ID = table.Column<int>(nullable: false),
                    RESUME_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDUCATION_PERIODS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PK_EDUCATION_PERIODS_TO_FACULTIES",
                        column: x => x.FACULTY_ID,
                        principalTable: "FACULTIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
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
                table: "FACULTIES",
                columns: new[] { "ID", "NAME" },
                values: new object[,]
                {
                    { 1, "Computer Science" },
                    { 2, "Software Engineering" },
                    { 3, "Applied Mathematics" }
                });

            migrationBuilder.InsertData(
                table: "LANGUAGES",
                columns: new[] { "ID", "NAME" },
                values: new object[,]
                {
                    { 2, "Ukrainian" },
                    { 3, "Russian" },
                    { 1, "English" }
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
                    { 2, "Sales", null, null },
                    { 1, "IT", null, null },
                    { 3, "Medicine", null, null }
                });

            migrationBuilder.InsertData(
                table: "COMPANIES",
                columns: new[] { "ID", "ADDRESS", "BOSS_NAME", "EMAIL", "FULL_DESCRIPTION", "LOGO_DATA", "LOGO_MIMETYPE", "NAME", "PASSWORD", "PHONE", "ROLE_ID", "SHORT_DESCRIPTION", "SITE" },
                values: new object[,]
                {
                    { 1, "253 Bianka Squares, Laneton, Kenya", "Adolfo", "Willow.Kemmer45@hotmail.com", "Ducimus vel rerum commodi ab facere recusandae.", null, null, "Company № 457", "qLI43M1j7v", "073 154", 1, "voluptatem", "https://johnathan.net" },
                    { 2, "8308 Bernadette Hill, West Elwin, Honduras", "Kayden", "Christian_Zulauf45@gmail.com", "Corporis repudiandae magni fuga incidunt assumenda et.", null, null, "Company № 866", "KwsPlz_zxm", "073 1071", 1, "fugit", "http://vicenta.name" },
                    { 3, "776 Bethel Hill, Lake Alan, Andorra", "Deanna", "Elissa58@gmail.com", "Velit quos et.", null, null, "Company № 430", "u81MK4oxlE", "073 7992", 1, "nam", "https://manley.org" },
                    { 4, "814 Kira Forge, North Rozella, Azerbaijan", "Gregory", "Phyllis.Emard27@yahoo.com", "Aliquid sit sit sunt vel et.", null, null, "Company № 126", "FLoz19QAEr", "073 9278", 1, "autem", "https://elvis.info" },
                    { 8, "0789 Ortiz Greens, Deckowhaven, Hong Kong", "Mauricio", "Heather_Will96@yahoo.com", "Sed omnis ut error nemo.", null, null, "Company № 938", "0kytZkhdVS", "073 9904", 1, "rerum", "http://baron.com" },
                    { 10, "04091 Princess Burg, East Agustin, Jersey", "Jesse", "Kevon_Daugherty85@gmail.com", "Ab consectetur velit est.", null, null, "Company № 903", "kiu2XtItjk", "073 6098", 1, "odio", "http://chance.name" },
                    { 9, "29031 Towne Via, North Shaniatown, Portugal", "Frederic", "Justice_Schiller@gmail.com", "Eligendi nihil fugit.", null, null, "Company № 322", "NZnX3MRb4y", "073 5637", 2, "labore", "https://dominique.com" },
                    { 7, "7251 MacGyver Mills, Port Alisha, Syrian Arab Republic", "Boyd", "Delphine51@hotmail.com", "Adipisci pariatur fugit aut tempora aperiam dolores.", null, null, "Company № 913", "58NMB1s67V", "073 8527", 2, "nisi", "http://naomie.name" },
                    { 5, "85056 Lessie Run, East Lucileton, Dominica", "Landen", "Erling_Rath@gmail.com", "Et nulla perferendis.", null, null, "Company № 997", "ClzhXuE43a", "073 7777", 2, "sed", "http://deion.com" },
                    { 6, "5708 Murazik Islands, East Ramiroport, Uganda", "Ezekiel", "Bobbie18@yahoo.com", "Mollitia itaque qui vel reiciendis autem animi ut.", null, null, "Company № 944", "iCFj5O1PXp", "073 1714", 2, "voluptatem", "https://alexander.org" }
                });

            migrationBuilder.InsertData(
                table: "USERS",
                columns: new[] { "ID", "ADDRESS", "BIRTH_DATA", "CITY_ID", "EMAIL", "FIRST_NAME", "LAST_NAME", "PASSWORD", "PHONE", "PHOTO_DATA", "PHOTO_MIME_TYPE", "ROLE_ID", "SEX" },
                values: new object[,]
                {
                    { 33, "Kreiger Parks", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Selmer_Dickinson@yahoo.com", "Kristy", "Schamberger", "aHxd7qyYhl", "073 9756", null, null, 2, "m" },
                    { 32, "Koepp Vista", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Carleton_Gulgowski@hotmail.com", "Callie", "Orn", "QDcSaxDlSZ", "073 6115", null, null, 2, "f" },
                    { 31, "Powlowski Branch", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Chaz.Moore7@gmail.com", "Yasmeen", "Heathcote", "hQV5B7KDVN", "073 1525", null, null, 2, "m" },
                    { 38, "Madilyn Vista", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Sheldon.Herman@yahoo.com", "Madeline", "Morar", "eSH3x1hq5E", "073 277", null, null, 1, "f" },
                    { 37, "Maureen Tunnel", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Mellie.Buckridge@gmail.com", "Thaddeus", "Kunde", "mNLW09RpxT", "073 3138", null, null, 2, "m" },
                    { 36, "Koss Squares", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Rosalinda.Kreiger@yahoo.com", "Jovani", "Maggio", "8to7IYon5J", "073 2910", null, null, 1, "m" },
                    { 35, "Terry Rapid", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ila_Beer@hotmail.com", "Kayla", "Botsford", "aeTXKnwnBH", "073 4389", null, null, 1, "f" },
                    { 34, "Christelle Passage", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sydney43@yahoo.com", "Emmalee", "Waters", "Aa3swtKcdl", "073 32", null, null, 1, "m" },
                    { 39, "Botsford Club", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Deon69@yahoo.com", "Letha", "Bernhard", "nW6VkiRyxj", "073 9372", null, null, 1, "f" },
                    { 40, "Alysha Stravenue", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Norene44@yahoo.com", "Caterina", "Conn", "6fcvNP0KXF", "073 6212", null, null, 2, "m" }
                });

            migrationBuilder.InsertData(
                table: "RECRUITERS",
                columns: new[] { "ID", "COMPANY_ID", "EMAIL", "FIRST_NAME", "LAST_NAME", "LOGO_DATA", "LOGO_MIMETYPE", "PASSWORD", "PHONE", "ROLE_ID" },
                values: new object[,]
                {
                    { 16, 2, "Caterina.Huel@yahoo.com", "Chyna", "Bartoletti", null, null, "nRve9k9KGR", "073 332", 1 },
                    { 11, 4, "Lacy.Koch88@gmail.com", "Harrison", "O'Hara", null, null, "UrGJys_llh", "073 5283", 2 },
                    { 15, 4, "Ollie.Borer76@yahoo.com", "Mason", "Gerlach", null, null, "586_3C0e6P", "073 2077", 2 },
                    { 17, 10, "Monroe.Weimann@hotmail.com", "Marianne", "Beer", null, null, "y6ZjGD_LIK", "073 483", 2 },
                    { 12, 5, "Danielle47@gmail.com", "Kathlyn", "Goodwin", null, null, "h1E9EsjT7U", "073 3075", 2 },
                    { 13, 5, "Heath82@hotmail.com", "Joanne", "Stamm", null, null, "oZmnyTYsj7", "073 2989", 2 },
                    { 14, 5, "Oda49@hotmail.com", "Blake", "Aufderhar", null, null, "UPBU9RbeS4", "073 704", 1 },
                    { 19, 6, "Ericka.Kulas@gmail.com", "Cristopher", "Cremin", null, null, "7qyuCQkrP7", "073 868", 1 },
                    { 18, 7, "Kiara.Moore12@gmail.com", "Julius", "Koss", null, null, "cGtWl4ETNq", "073 4016", 2 },
                    { 20, 7, "Judge_Marquardt50@yahoo.com", "Wendy", "Kulas", null, null, "O8sMBMMheI", "073 585", 1 }
                });

            migrationBuilder.InsertData(
                table: "RESUMES",
                columns: new[] { "ID", "COURSES", "CREATE_DATE", "FACEBOOK", "FAMILY_STATE", "GITHUB", "INSTAGRAM", "KEY_SKILLS", "LINKEDIN", "MOD_DATE", "SKYPE", "SOFT_SKILLS", "WORK_AREA_ID" },
                values: new object[,]
                {
                    { 38, "Praesentium distinctio maiores.", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://enoch.org", "Quidem.", "http://trace.com", "http://katrine.info", "Architecto repellat tenetur debitis consequatur fugit aut alias.", "http://priscilla.name", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://sheridan.org", "Velit atque et.", 1 },
                    { 32, "Vero illo pariatur non ipsam expedita odit ipsum ea.", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://lonny.name", "Recusandae.", "http://dasia.org", "https://reilly.net", "Perspiciatis cum cupiditate ut et error et eligendi.", "https://sydnee.com", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://clement.net", "Voluptas nostrum distinctio quia et voluptatem quis consequatur.", 1 }
                });

            migrationBuilder.InsertData(
                table: "EDUCATION_PERIODS",
                columns: new[] { "ID", "FACULTY_ID", "FINISH_DATE", "RESUME_ID", "SCHOOL_ID", "START_DATE" },
                values: new object[,]
                {
                    { 61, 3, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 38, 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, 3, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, 3, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 38, 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 38, 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 38, 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 54, 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, 3, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 38, 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 38, 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "EXPERIENCES",
                columns: new[] { "ID", "COMPANY_NAME", "FINISH_DATE", "POSITION", "RESUME_ID", "START_DATE" },
                values: new object[,]
                {
                    { 49, "Florence Roberts", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Voluptatibus eum corporis velit aliquam.", 32, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, "Mason Lang", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laboriosam quo sit dignissimos iste suscipit quia cumque.", 32, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, "Manuela Kunde", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laudantium omnis suscipit dolor et commodi.", 32, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, "Dusty Robel", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Commodi velit voluptatibus.", 38, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, "Naomie Sanford", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ut adipisci vel expedita earum voluptatem repellat aut debitis.", 38, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, "Agustina Harris", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eligendi quis quia delectus tempore voluptatem illum quas tempora.", 38, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, "Golda Goldner", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Est maxime repellendus et quo aut exercitationem eos.", 38, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, "Uriel Weber", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Architecto nostrum sit dolore quam.", 38, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, "Genesis Williamson", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aperiam nam impedit.", 38, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, "Marjorie Kemmer", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aperiam voluptatibus aut atque dolor voluptatem.", 32, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "RESUME_LANGUAGES",
                columns: new[] { "ID", "LANGUAGE_ID", "RESUME_ID" },
                values: new object[,]
                {
                    { 64, 1, 32 },
                    { 65, 3, 32 },
                    { 66, 3, 38 },
                    { 69, 2, 32 },
                    { 71, 3, 38 },
                    { 70, 1, 38 },
                    { 67, 1, 38 },
                    { 68, 1, 32 },
                    { 63, 2, 38 },
                    { 72, 2, 38 }
                });

            migrationBuilder.InsertData(
                table: "VACANCIES",
                columns: new[] { "ID", "BE_PLUS", "CITY_ID", "CREATE_DATE", "DESCRIPTION", "FULL_PART_TIME", "IS_CHECKED", "MOD_DATE", "NAME", "OFFERING", "RECRUITER_ID", "REQUIREMENTS", "SALARY", "WORK_AREA_ID" },
                values: new object[,]
                {
                    { 22, "Necessitatibus quas sit provident laborum.", 3, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lead", "Part-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lead Division Coordinator", "Clementine Zieme", 13, "Occaecati odio pariatur quis praesentium et at.", 1000m, 3 },
                    { 24, "Molestias veniam ex eum dicta voluptate aut.", 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Regional", "Part-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Future Accountability Analyst", "Samara Hartmann", 13, "Vel quia dicta dolorum placeat consequuntur omnis est eos in.", 1000m, 3 },
                    { 25, "Optio vitae dolor vel.", 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "National", "Part-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Human Communications Facilitator", "Horacio Bergnaum", 14, "Atque blanditiis corrupti alias.", 1000m, 3 },
                    { 30, "Tempore voluptas optio.", 3, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Legacy", "Full-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Human Web Administrator", "Eloise Hand", 14, "Qui enim voluptatibus dolore voluptas nostrum iusto sed non.", 1000m, 3 },
                    { 23, "A voluptatem minima et.", 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Global", "Part-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Legacy Paradigm Associate", "Pink King", 15, "Eaque doloribus eos corrupti illum est voluptatem.", 1000m, 3 },
                    { 21, "Id ut non vero a possimus.", 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Global", "Full-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "District Research Director", "Lukas Schoen", 15, "Repellat sit quia delectus.", 1000m, 2 },
                    { 28, "Ex voluptatum deserunt nostrum.", 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "District", "Full-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dynamic Group Architect", "Lauryn Lockman", 11, "Laboriosam accusantium expedita qui omnis commodi.", 1000m, 3 },
                    { 27, "Vel neque vel provident illum dolore.", 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chief", "Part-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dynamic Markets Director", "Juliana Kshlerin", 11, "Molestiae corrupti praesentium voluptates aliquid tenetur velit.", 1000m, 3 },
                    { 29, "Non quasi et dolorem doloribus id et dolor maiores est.", 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lead", "Full-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dynamic Usability Supervisor", "Alexzander Kling", 16, "Harum corrupti non veritatis sit qui.", 1000m, 1 },
                    { 26, "Earum et dolor non excepturi voluptate.", 3, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forward", "Full-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dynamic Paradigm Facilitator", "Lewis Schumm", 16, "Exercitationem odit rem.", 1000m, 1 }
                });

            migrationBuilder.InsertData(
                table: "FAVORITE_VACANCIES",
                columns: new[] { "ID", "USER_ID", "VACANCY_ID" },
                values: new object[,]
                {
                    { 78, 39, 26 },
                    { 79, 33, 26 },
                    { 75, 31, 29 },
                    { 73, 35, 21 },
                    { 82, 37, 21 },
                    { 77, 36, 23 },
                    { 81, 34, 23 },
                    { 76, 35, 22 },
                    { 80, 32, 24 },
                    { 74, 37, 30 }
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
                name: "IX_EDUCATION_PERIODS_FACULTY_ID",
                table: "EDUCATION_PERIODS",
                column: "FACULTY_ID");

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
                name: "UQ_FACULTIES_NAME",
                table: "FACULTIES",
                column: "NAME",
                unique: true);

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
                name: "FAVORITE_VACANCIES");

            migrationBuilder.DropTable(
                name: "RESUME_LANGUAGES");

            migrationBuilder.DropTable(
                name: "FACULTIES");

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
