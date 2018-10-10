using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JobList.DataAccess.Migrations
{
    public partial class init : Migration
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
                    PHONE = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
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
                    EMAIL = table.Column<string>(unicode: false, maxLength: 150, nullable: false),
                    PASSWORD = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    ROLE_ID = table.Column<int>(nullable: false),
                    CITY_ID = table.Column<int>(nullable: false),
                    REFRESH_TOKEN = table.Column<string>(unicode: false, maxLength: 70, nullable: true)
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
                    PHONE = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
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
                    { 1, "New York City" },
                    { 12, "Chicago" },
                    { 11, "San Francisco" },
                    { 10, "Phoneix" },
                    { 8, "Washington DC" },
                    { 7, "Seattle" },
                    { 9, "Las Vegas" },
                    { 5, "Boston" },
                    { 4, "Los Angeles" },
                    { 3, "Atlanta" },
                    { 2, "Jersey City" },
                    { 6, "Philadephia" }
                });

            migrationBuilder.InsertData(
                table: "FACULTIES",
                columns: new[] { "ID", "NAME" },
                values: new object[,]
                {
                    { 7, "Design" },
                    { 10, "Journalism" },
                    { 9, "Marketing" },
                    { 8, "Faculty of Law" },
                    { 6, "Economics" },
                    { 1, "Computer Science" },
                    { 4, "Foreign Languages" },
                    { 3, "Applied Mathematics" },
                    { 2, "Software Engineering" },
                    { 5, "International Relationships" }
                });

            migrationBuilder.InsertData(
                table: "LANGUAGES",
                columns: new[] { "ID", "NAME" },
                values: new object[,]
                {
                    { 8, "Chinese" },
                    { 10, "Roman" },
                    { 9, "German" },
                    { 6, "Japanese" },
                    { 7, "Spanish" },
                    { 4, "Polish" },
                    { 3, "Russian" },
                    { 2, "Ukrainian" },
                    { 1, "English" },
                    { 5, "Greek" }
                });

            migrationBuilder.InsertData(
                table: "ROLES",
                columns: new[] { "ID", "NAME" },
                values: new object[,]
                {
                    { 1, "admin" },
                    { 2, "user" },
                    { 3, "company" },
                    { 4, "recruiter" }
                });

            migrationBuilder.InsertData(
                table: "SCHOOLS",
                columns: new[] { "ID", "NAME" },
                values: new object[,]
                {
                    { 10, "Yale University" },
                    { 9, "University of Arizona" },
                    { 8, "New York University" },
                    { 6, "Massachusetts Institute of Technology" },
                    { 7, "Columbia University" },
                    { 4, "Berklee College Of Arts" },
                    { 3, "Prinston University" },
                    { 2, "Harvard University" },
                    { 1, "Chicago State University" },
                    { 5, "Stanford University" }
                });

            migrationBuilder.InsertData(
                table: "WORK_AREAS",
                columns: new[] { "ID", "NAME", "PHOTO_DATA", "PHOTO_MIMETYPE" },
                values: new object[,]
                {
                    { 10, "Real Estate", null, null },
                    { 9, "Insurance", null, null },
                    { 8, "Arts", null, null },
                    { 7, "Tourism", null, null },
                    { 6, "Science", null, null },
                    { 4, "Marketing and Advertising", null, null },
                    { 3, "Medicine", null, null },
                    { 2, "Sales", null, null },
                    { 1, "IT", null, null },
                    { 11, "Finances", null, null },
                    { 5, "Law and Politics", null, null },
                    { 12, "Media", null, null }
                });

            migrationBuilder.InsertData(
                table: "COMPANIES",
                columns: new[] { "ID", "ADDRESS", "BOSS_NAME", "EMAIL", "FULL_DESCRIPTION", "LOGO_DATA", "LOGO_MIMETYPE", "NAME", "PASSWORD", "PHONE", "ROLE_ID", "SHORT_DESCRIPTION", "SITE" },
                values: new object[,]
                {
                    { 10, "05287 Brown Mission, Littleburgh, Belize", "Johnathan", "Lacy_DuBuque@yahoo.com", "Nulla quis quo ad enim maxime nemo.", null, null, "Company № 543", "QYLsC0KuPl", "073 4788", 1, "asperiores", "http://ethelyn.net" },
                    { 3, "4747 Nickolas Place, Port Daytonmouth, Finland", "Elsa", "Camille18@hotmail.com", "Eum eum occaecati id quidem ad necessitatibus eligendi suscipit voluptas.", null, null, "Company № 278", "Q9Mj4g_Xwc", "073 1353", 4, "ad", "https://gordon.org" },
                    { 1, "669 Wolff Stravenue, Daughertyland, Pakistan", "Anya", "Pink4@yahoo.com", "Modi minus voluptatibus quisquam ratione explicabo aut dignissimos.", null, null, "Company № 279", "fQ3lKR0XdN", "073 3533", 4, "quidem", "http://arturo.info" },
                    { 2, "1318 Mante Harbor, Roscoeport, Uruguay", "Eugene", "Charity36@gmail.com", "Hic accusantium accusamus.", null, null, "Company № 996", "6kcJwBJ6Ij", "073 1665", 2, "minus", "https://gage.net" },
                    { 5, "59723 Casimir Cliff, Hacketttown, Macao", "Nicolette", "Jordi95@yahoo.com", "Aut ipsa id est rerum.", null, null, "Company № 443", "WCRapovrCa", "073 2558", 2, "voluptatum", "http://salvador.com" },
                    { 9, "36334 Bruce Prairie, Rolfsonmouth, Luxembourg", "Adolph", "Abigale_Tillman3@hotmail.com", "Et voluptatem sit ea exercitationem impedit harum cum voluptates corporis.", null, null, "Company № 76", "Jem3PHRKFG", "073 93", 3, "repellat", "http://gussie.com" },
                    { 7, "6761 Brown Curve, North Stanfordburgh, Saint Martin", "Benjamin", "Juwan21@yahoo.com", "Consequatur distinctio iste quisquam accusamus repudiandae magnam dolore non.", null, null, "Company № 758", "tvqSru4HnQ", "073 3240", 3, "libero", "http://raymundo.com" },
                    { 6, "74971 Price Lodge, East Mario, Guam", "Sunny", "Velda44@gmail.com", "Dolores eum labore et dolores perspiciatis quod culpa natus sapiente.", null, null, "Company № 224", "TqjikHswt5", "073 6235", 3, "repudiandae", "http://estrella.com" },
                    { 4, "15412 Hayden Hill, West Daryl, Norfolk Island", "Aniya", "Hester22@yahoo.com", "Assumenda similique sint rerum officia tenetur ipsam.", null, null, "Company № 680", "qHDAxkJ786", "073 5257", 3, "et", "http://luis.info" },
                    { 8, "01148 Kerluke Crossing, Dexterburgh, Jamaica", "Abe", "Pierce.Tremblay29@gmail.com", "Consequatur repudiandae autem.", null, null, "Company № 797", "MKkFdPPwhe", "073 7774", 4, "quibusdam", "http://brett.com" }
                });

            migrationBuilder.InsertData(
                table: "USERS",
                columns: new[] { "ID", "BIRTH_DATA", "CITY_ID", "EMAIL", "FIRST_NAME", "LAST_NAME", "PASSWORD", "PHONE", "PHOTO_DATA", "PHOTO_MIME_TYPE", "REFRESH_TOKEN", "ROLE_ID", "SEX" },
                values: new object[,]
                {
                    { 34, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, "Darron_Rowe39@yahoo.com", "Lionel", "Kemmer", "bAjgYvRokn", "073 9623", null, null, null, 3, "f" },
                    { 40, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Kitty39@yahoo.com", "Novella", "Monahan", "NZEOPQM75q", "073 3444", null, null, null, 2, "m" },
                    { 39, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Marilyne_Robel92@yahoo.com", "Marlon", "Sauer", "8xl1zHgoGe", "073 8719", null, null, null, 2, "m" },
                    { 38, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Juvenal95@yahoo.com", "Nikita", "Klocko", "63sIliGs3s", "073 2216", null, null, null, 2, "m" },
                    { 32, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, "Abelardo.Lakin53@hotmail.com", "Estevan", "Haag", "t89ZksGUyJ", "073 8490", null, null, null, 2, "m" },
                    { 31, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Amina_Kuhlman15@hotmail.com", "Tina", "Hintz", "GHA67zSjVx", "073 7092", null, null, null, 2, "f" },
                    { 37, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Mekhi_Reinger@hotmail.com", "Destinee", "Gorczany", "v0D3DnZuS5", "073 6569", null, null, null, 1, "m" },
                    { 36, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Hank.Cummings51@yahoo.com", "Micah", "Kihn", "EmYDQmtHxC", "073 4333", null, null, null, 1, "m" },
                    { 35, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Carolanne45@gmail.com", "Aryanna", "Thompson", "WlpFra1bm5", "073 3092", null, null, null, 1, "m" },
                    { 46, new DateTime(1995, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "andr@gmail.com", "Andrew", "Felton", "qwerty", "0502758765", null, null, null, 2, "M" },
                    { 33, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Krista2@gmail.com", "Rae", "White", "nUhH4HJpqn", "073 7082", null, null, null, 4, "f" }
                });

            migrationBuilder.InsertData(
                table: "RECRUITERS",
                columns: new[] { "ID", "COMPANY_ID", "EMAIL", "FIRST_NAME", "LAST_NAME", "LOGO_DATA", "LOGO_MIMETYPE", "PASSWORD", "PHONE", "ROLE_ID" },
                values: new object[,]
                {
                    { 11, 10, "Bradley_Schamberger96@hotmail.com", "Cordelia", "Steuber", null, null, "9hlsxcFGxX", "073 5591", 3 },
                    { 17, 2, "Arnulfo_Moen@yahoo.com", "Lonnie", "Witting", null, null, "HqHAaXSNVA", "073 6191", 2 },
                    { 19, 5, "Vergie.Skiles@yahoo.com", "Fiona", "Schmeler", null, null, "ikOZ8nRSuA", "073 6359", 4 },
                    { 16, 4, "Cornelius_Schmitt2@yahoo.com", "Curtis", "Mante", null, null, "DNWNMUWebp", "073 6813", 4 },
                    { 18, 6, "Gonzalo.Wilkinson@hotmail.com", "Makenzie", "Bartell", null, null, "HfhOd_bZab", "073 9929", 3 },
                    { 12, 1, "Lula26@hotmail.com", "Lloyd", "Waelchi", null, null, "nRibLGSsTc", "073 7163", 3 },
                    { 13, 1, "Grayce26@gmail.com", "Edna", "Legros", null, null, "l83XzOMSpe", "073 274", 4 },
                    { 15, 1, "Elisabeth40@yahoo.com", "Darius", "Lemke", null, null, "t5wctqpYU5", "073 8425", 1 },
                    { 20, 1, "May.Jenkins63@hotmail.com", "Vidal", "Jenkins", null, null, "PSlkvww3Gr", "073 3057", 4 },
                    { 14, 3, "Shanelle42@yahoo.com", "Zane", "Hyatt", null, null, "csKs9PJ8yw", "073 1308", 4 }
                });

            migrationBuilder.InsertData(
                table: "RESUMES",
                columns: new[] { "ID", "COURSES", "CREATE_DATE", "FACEBOOK", "FAMILY_STATE", "GITHUB", "INSTAGRAM", "KEY_SKILLS", "LINKEDIN", "MOD_DATE", "SKYPE", "SOFT_SKILLS", "WORK_AREA_ID" },
                values: new object[,]
                {
                    { 40, "Aut quia id labore eligendi veniam.", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://delbert.name", "Dolorem.", "http://kameron.com", "https://lucy.net", "Quidem nisi qui sequi ipsam.", "http://edwin.com", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://shane.com", "Perspiciatis rerum dolore architecto sequi.", 1 },
                    { 46, "Certification training", new DateTime(2018, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "www.facebook.com", "not married", null, null, "hardworking, persuasive", null, null, null, "plastic surgery", 3 }
                });

            migrationBuilder.InsertData(
                table: "EDUCATION_PERIODS",
                columns: new[] { "ID", "FACULTY_ID", "FINISH_DATE", "RESUME_ID", "SCHOOL_ID", "START_DATE" },
                values: new object[,]
                {
                    { 60, 4, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 8, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 112, 2, new DateTime(2007, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 46, 5, new DateTime(2004, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, 10, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 6, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, 6, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, 9, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 5, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, 8, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, 4, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 10, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 111, 4, new DateTime(2005, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 46, 8, new DateTime(2002, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, 8, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, 9, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 7, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, 8, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 6, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, 10, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 10, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "EXPERIENCES",
                columns: new[] { "ID", "COMPANY_NAME", "FINISH_DATE", "POSITION", "RESUME_ID", "START_DATE" },
                values: new object[,]
                {
                    { 52, "Russ Jones", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aspernatur excepturi quisquam dolorem non cum quia et illo.", 40, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, "Irwin Cummings", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harum quisquam delectus sunt asperiores.", 40, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65, "Triomed", new DateTime(2018, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Surgeon", 46, new DateTime(2008, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, "Reid Russel", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ipsa voluptates vel voluptates est earum omnis provident ipsam.", 40, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, "Fausto Hettinger", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Culpa nobis sunt.", 40, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, "Santina D'Amore", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Repellendus autem sit at laboriosam earum accusamus explicabo qui consequuntur.", 40, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, "Otto Schamberger", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Velit nostrum aut vitae pariatur repellat pariatur et.", 40, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, "Desiree Bruen", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dolorem odio deserunt rerum perferendis libero.", 40, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, "Eldon Kemmer", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consequuntur tempore assumenda distinctio.", 40, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, "Dewayne Powlowski", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rem nihil iure at inventore consequuntur qui.", 40, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, "Elinore Lang", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Et illum odit optio.", 40, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "RESUME_LANGUAGES",
                columns: new[] { "ID", "LANGUAGE_ID", "RESUME_ID" },
                values: new object[,]
                {
                    { 112, 5, 46 },
                    { 111, 10, 46 },
                    { 76, 10, 40 },
                    { 75, 7, 40 },
                    { 74, 10, 40 },
                    { 73, 2, 40 },
                    { 72, 1, 40 },
                    { 70, 4, 40 },
                    { 69, 7, 40 },
                    { 68, 2, 40 },
                    { 67, 1, 40 },
                    { 113, 7, 46 },
                    { 71, 5, 40 }
                });

            migrationBuilder.InsertData(
                table: "VACANCIES",
                columns: new[] { "ID", "BE_PLUS", "CITY_ID", "CREATE_DATE", "DESCRIPTION", "FULL_PART_TIME", "IS_CHECKED", "MOD_DATE", "NAME", "OFFERING", "RECRUITER_ID", "REQUIREMENTS", "SALARY", "WORK_AREA_ID" },
                values: new object[,]
                {
                    { 28, "Quibusdam labore qui nihil perferendis molestias.", 10, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Corporate", "Full-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Regional Response Liaison", "Henderson Wiegand", 12, "Inventore corporis quas delectus.", 1000m, 5 },
                    { 26, "Sequi velit eaque aperiam quaerat eum aliquid et eaque.", 5, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Internal", "Full-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "National Integration Strategist", "Orville Gerhold", 13, "Repellat aspernatur iure vel dolorum expedita explicabo est qui est.", 1000m, 12 },
                    { 24, "Harum aut ut quae expedita eveniet quo quis voluptas.", 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Future", "Part-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Principal Research Assistant", "Kasey Farrell", 12, "A dolor voluptatem culpa minus consequatur accusantium exercitationem aut.", 1000m, 2 },
                    { 25, "Omnis et qui.", 12, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Internal", "Part-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chief Intranet Planner", "Lucie Kling", 18, "Laborum illum qui natus aut dolorum.", 1000m, 1 },
                    { 23, "Architecto eveniet earum.", 12, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forward", "Part-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Customer Integration Orchestrator", "Gardner Gibson", 17, "Dolorum iste doloribus magnam nulla harum est laboriosam enim velit.", 1000m, 1 },
                    { 29, "Repellendus necessitatibus reprehenderit et quis voluptate fugit.", 9, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Human", "Part-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Investor Metrics Technician", "Shemar Morissette", 15, "Itaque assumenda est et.", 1000m, 1 },
                    { 27, "Repudiandae beatae dolorum sunt delectus veniam aut officia.", 12, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Central", "Part-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Customer Functionality Orchestrator", "Juliet Quitzon", 19, "Nulla minus praesentium dolorum labore sit quibusdam molestiae ab.", 1000m, 5 },
                    { 30, "Esse voluptatem accusantium et corporis voluptas.", 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Future", "Full-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senior Accountability Architect", "Keely Cronin", 17, "Ut voluptatem cupiditate voluptas.", 1000m, 2 },
                    { 21, "Placeat explicabo perferendis quod aut hic doloribus.", 10, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Direct", "Full-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "National Interactions Specialist", "Jeffry Hettinger", 18, "Asperiores nihil eaque eos doloribus iure iure sequi.", 1000m, 3 },
                    { 22, "Porro voluptatem sunt nemo voluptatem at.", 11, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Regional", "Full-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Future Identity Assistant", "Juston Leuschke", 20, "Facilis qui illum voluptate qui illum consequatur et et sint.", 1000m, 8 }
                });

            migrationBuilder.InsertData(
                table: "FAVORITE_VACANCIES",
                columns: new[] { "ID", "USER_ID", "VACANCY_ID" },
                values: new object[,]
                {
                    { 82, 46, 30 },
                    { 81, 37, 27 },
                    { 86, 32, 21 },
                    { 89, 38, 21 },
                    { 84, 33, 25 },
                    { 85, 46, 25 },
                    { 87, 46, 25 },
                    { 80, 40, 28 },
                    { 88, 31, 29 },
                    { 83, 46, 22 }
                });

            migrationBuilder.CreateIndex(
                name: "UQ_CITIES_NAME",
                table: "CITIES",
                column: "NAME",
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
                unique: true,
                filter: "[PHONE] IS NOT NULL");

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
                unique: true,
                filter: "[PHONE] IS NOT NULL");

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
                name: "UQ_USERS_REFRESH_TOKEN",
                table: "USERS",
                column: "REFRESH_TOKEN",
                unique: true,
                filter: "[REFRESH_TOKEN] IS NOT NULL");

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
