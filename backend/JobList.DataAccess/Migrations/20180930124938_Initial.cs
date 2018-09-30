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
                    { 20, "Software Engineering" },
                    { 18, "Computer Science" },
                    { 17, "Applied Mathematics" },
                    { 16, "Computer Science" },
                    { 19, "Computer Science" },
                    { 14, "Applied Mathematics" },
                    { 13, "Applied Mathematics" },
                    { 12, "Computer Science" },
                    { 11, "Software Engineering" },
                    { 15, "Software Engineering" }
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
                    { 2, "Sales", null, null },
                    { 1, "IT", null, null },
                    { 3, "Medicine", null, null }
                });

            migrationBuilder.InsertData(
                table: "COMPANIES",
                columns: new[] { "ID", "ADDRESS", "BOSS_NAME", "EMAIL", "FULL_DESCRIPTION", "LOGO_DATA", "LOGO_MIMETYPE", "NAME", "PASSWORD", "PHONE", "ROLE_ID", "SHORT_DESCRIPTION", "SITE" },
                values: new object[,]
                {
                    { 5, "051 Jailyn Spring, Ratkechester, Somalia", "Jazmyne", "Everardo27@hotmail.com", "Sed nisi voluptatem qui blanditiis dolorum recusandae.", null, null, "Company № 113", "UmiVQHTLeh", "073 96", 1, "atque", "http://eldridge.name" },
                    { 10, "61628 Medhurst Garden, Lake Lourdesborough, Puerto Rico", "Broderick", "Jimmy39@gmail.com", "Velit et dolorum quam recusandae delectus nesciunt nobis.", null, null, "Company № 784", "UZN_npe3IW", "073 1423", 2, "sit", "http://jeromy.net" },
                    { 6, "6728 Wolff Route, East Dasia, French Southern Territories", "Bennett", "Carrie.Flatley51@yahoo.com", "Est veniam accusantium in.", null, null, "Company № 722", "0V5ZEh7b30", "073 8009", 2, "aut", "http://ada.net" },
                    { 4, "47882 Jo Rue, Fosterland, Finland", "Lisette", "Louie.Considine@hotmail.com", "Sequi iusto illo aliquam exercitationem aut nam voluptatum.", null, null, "Company № 352", "wSU45ohr9M", "073 5990", 2, "facere", "http://julio.biz" },
                    { 3, "487 Cordelia Locks, Lavernland, Bulgaria", "Aimee", "Neva.Murazik5@gmail.com", "Ullam rerum magni.", null, null, "Company № 235", "5tLXBNi4Co", "073 7459", 2, "iusto", "https://dino.info" },
                    { 2, "1004 Graciela Knoll, Cruickshankstad, Benin", "Katharina", "Leopoldo42@yahoo.com", "Accusamus reiciendis dignissimos provident veniam laboriosam.", null, null, "Company № 293", "unYjU9RsCH", "073 7104", 2, "consequuntur", "https://wyatt.com" },
                    { 1, "39832 Medhurst Crossroad, Darrylland, Saint Pierre and Miquelon", "Coy", "Malinda65@gmail.com", "Exercitationem quo sit possimus non cumque ut.", null, null, "Company № 743", "RcUm54SwLf", "073 5531", 2, "veritatis", "https://alexys.com" },
                    { 9, "64628 Kilback Ford, Windlerton, Equatorial Guinea", "Olen", "Isaiah.Collier29@gmail.com", "Quo sunt aut.", null, null, "Company № 197", "TGLP0R7wYe", "073 6621", 1, "reprehenderit", "http://johan.biz" },
                    { 8, "98533 Micah Turnpike, Abdullahfurt, Mozambique", "Pattie", "Oda61@hotmail.com", "Nihil porro eaque qui fuga quidem aut vel.", null, null, "Company № 903", "86A0aIJkQW", "073 1973", 1, "eligendi", "https://deja.com" },
                    { 7, "52892 Marjorie Place, Lake Carlos, Holy See (Vatican City State)", "Renee", "Leilani_Schoen40@gmail.com", "Ut exercitationem sunt a.", null, null, "Company № 788", "tIy4eOdawn", "073 1066", 1, "esse", "http://margarett.org" }
                });

            migrationBuilder.InsertData(
                table: "USERS",
                columns: new[] { "ID", "ADDRESS", "BIRTH_DATA", "CITY_ID", "EMAIL", "FIRST_NAME", "LAST_NAME", "PASSWORD", "PHONE", "PHOTO_DATA", "PHOTO_MIME_TYPE", "ROLE_ID", "SEX" },
                values: new object[,]
                {
                    { 46, "Kulas Crossroad", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sandy15@gmail.com", "Justyn", "Watsica", "5lkrJY6JgQ", "073 4970", null, null, 1, "f" },
                    { 49, "Wilderman Ports", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Sylvester_Torphy@yahoo.com", "Augustus", "Cummerata", "6VKSPwhbAy", "073 4454", null, null, 1, "f" },
                    { 48, "Halvorson Spring", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Guillermo_Krajcik80@yahoo.com", "Jamarcus", "Rippin", "9mutScNDVl", "073 5187", null, null, 2, "m" },
                    { 44, "Kraig Street", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Orlo74@yahoo.com", "Griffin", "Cassin", "1kfNPhXRxA", "073 4640", null, null, 1, "m" },
                    { 42, "Haley Points", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Norberto.Mertz@gmail.com", "Freeda", "Bogan", "7YE28eaQcN", "073 1096", null, null, 1, "f" },
                    { 41, "Dante Inlet", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Kaley62@yahoo.com", "Rosalinda", "Bruen", "EtQjS1Maif", "073 8386", null, null, 2, "f" },
                    { 43, "William Greens", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Lawson_Erdman@yahoo.com", "Hermann", "Reynolds", "73yayIcVNR", "073 9238", null, null, 2, "f" },
                    { 47, "Dare Center", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Charity_Strosin@hotmail.com", "Marlin", "Howell", "afYCGFd2pt", "073 9436", null, null, 2, "m" },
                    { 45, "Jarrell Shore", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Tyson.Batz@hotmail.com", "Jay", "Rippin", "v7buwXq4J1", "073 8424", null, null, 1, "f" },
                    { 50, "Zora Corners", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Marquise_Moore@gmail.com", "Alejandrin", "Hermann", "e8GIs9FJYd", "073 5732", null, null, 2, "m" }
                });

            migrationBuilder.InsertData(
                table: "RECRUITERS",
                columns: new[] { "ID", "COMPANY_ID", "EMAIL", "FIRST_NAME", "LAST_NAME", "LOGO_DATA", "LOGO_MIMETYPE", "PASSWORD", "PHONE", "ROLE_ID" },
                values: new object[,]
                {
                    { 28, 7, "Kianna_Pouros@hotmail.com", "Daniela", "Smith", null, null, "lTlmxriZQp", "073 1303", 2 },
                    { 22, 8, "Roosevelt.Mann@yahoo.com", "Orpha", "Stokes", null, null, "lC6khD9Yqj", "073 2088", 2 },
                    { 23, 8, "Bartholome28@gmail.com", "Marshall", "Parisian", null, null, "npavD6dEgW", "073 5421", 1 },
                    { 26, 8, "Lemuel8@gmail.com", "Jaime", "Schinner", null, null, "XlsRqtMQxh", "073 5251", 2 },
                    { 30, 8, "Xzavier.Langworth89@hotmail.com", "Gabriella", "Beer", null, null, "GI8LZkbtEh", "073 621", 1 },
                    { 24, 9, "Alaina.Morissette@gmail.com", "Wilfrid", "Mann", null, null, "T8vnwSGj8w", "073 784", 2 },
                    { 27, 9, "Anabelle66@gmail.com", "Janet", "Cummerata", null, null, "27CIqYFonx", "073 7890", 2 },
                    { 21, 1, "Lorena.Doyle46@hotmail.com", "Malachi", "Wunsch", null, null, "SgsykQzvBG", "073 2764", 1 },
                    { 29, 1, "Mario.Littel@hotmail.com", "Naomi", "Parker", null, null, "qw0OrGbMYq", "073 2737", 2 },
                    { 25, 3, "Aaliyah_Green31@yahoo.com", "Clare", "Corkery", null, null, "2gmEVMuLKb", "073 9805", 1 }
                });

            migrationBuilder.InsertData(
                table: "RESUMES",
                columns: new[] { "ID", "COURSES", "CREATE_DATE", "FACEBOOK", "FAMILY_STATE", "GITHUB", "INSTAGRAM", "KEY_SKILLS", "LINKEDIN", "MOD_DATE", "SKYPE", "SOFT_SKILLS", "WORK_AREA_ID" },
                values: new object[,]
                {
                    { 49, "Similique qui qui sit nemo eligendi laudantium.", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://elisha.info", "Porro.", "https://karina.info", "https://cathy.org", "Officia dicta saepe.", "http://gretchen.org", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://kitty.net", "Recusandae omnis illo minus deleniti corporis tempora fugiat qui quis.", 1 },
                    { 50, "Rem mollitia et id.", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://audra.org", "Aspernatur.", "http://lonzo.info", "http://brant.name", "Vero accusantium quidem voluptate.", "https://jaunita.org", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://oswald.com", "Saepe sapiente sunt voluptate quo enim quam quae.", 1 }
                });

            migrationBuilder.InsertData(
                table: "EDUCATION_PERIODS",
                columns: new[] { "ID", "FACULTY_ID", "FINISH_DATE", "RESUME_ID", "SCHOOL_ID", "START_DATE" },
                values: new object[,]
                {
                    { 71, 14, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 49, 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 67, 20, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 68, 12, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 72, 20, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 66, 15, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 70, 14, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 49, 3, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 69, 16, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 49, 3, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65, 16, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, 13, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 49, 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, 13, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 49, 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "EXPERIENCES",
                columns: new[] { "ID", "COMPANY_NAME", "FINISH_DATE", "POSITION", "RESUME_ID", "START_DATE" },
                values: new object[,]
                {
                    { 57, "Maudie Shanahan", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Praesentium aperiam eveniet nemo.", 50, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, "Roberta Schultz", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Est perspiciatis voluptatum quos sit.", 50, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, "Felicita Rogahn", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dolores voluptates rerum soluta.", 49, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, "Jewel Botsford", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Minima dolorem sed et molestiae deserunt et.", 49, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, "Zion Spinka", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "In fugiat iusto ut quas corrupti.", 49, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, "Quincy Simonis", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dolorum ab corrupti mollitia aut cum repudiandae sed dolore ut.", 49, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, "Jesse Kertzmann", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Omnis exercitationem reprehenderit perspiciatis maxime.", 50, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 54, "Beryl Hoppe", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perferendis mollitia ut in.", 50, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, "Olaf Keeling", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alias illo nam repellat suscipit ab aut recusandae.", 50, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, "Tomasa O'Reilly", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Minima cumque ut at et et fugiat vitae modi vel.", 50, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "RESUME_LANGUAGES",
                columns: new[] { "ID", "LANGUAGE_ID", "RESUME_ID" },
                values: new object[,]
                {
                    { 74, 1, 50 },
                    { 78, 2, 49 },
                    { 82, 1, 50 },
                    { 75, 3, 49 },
                    { 80, 1, 49 },
                    { 79, 2, 49 },
                    { 81, 2, 50 },
                    { 77, 3, 49 },
                    { 76, 2, 49 },
                    { 73, 2, 49 }
                });

            migrationBuilder.InsertData(
                table: "VACANCIES",
                columns: new[] { "ID", "BE_PLUS", "CITY_ID", "CREATE_DATE", "DESCRIPTION", "FULL_PART_TIME", "IS_CHECKED", "MOD_DATE", "NAME", "OFFERING", "RECRUITER_ID", "REQUIREMENTS", "SALARY", "WORK_AREA_ID" },
                values: new object[,]
                {
                    { 35, "Dolor saepe dicta ipsa consequatur numquam voluptatem enim quaerat.", 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Internal", "Full-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Regional Paradigm Executive", "Rigoberto Kunde", 22, "Rerum voluptas quam consectetur ad.", 1000m, 1 },
                    { 38, "Dolor at debitis omnis aspernatur quos rerum sed maxime hic.", 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Principal", "Full-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "National Identity Orchestrator", "Dolores Bauch", 23, "Dolores nemo distinctio sunt laborum cupiditate velit ipsa.", 1000m, 3 },
                    { 32, "Nihil mollitia porro aut dolores alias et.", 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Customer", "Full-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senior Quality Representative", "Phoebe Haag", 26, "Fugit error est veniam.", 1000m, 2 },
                    { 33, "Dolorem cumque sed voluptatum est unde possimus illum aut.", 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Legacy", "Full-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Central Applications Technician", "Rafael Dickens", 30, "Dolor enim rerum facere dolorem sint numquam.", 1000m, 2 },
                    { 31, "Enim beatae voluptatem dolor velit est.", 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chief", "Full-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Legacy Security Planner", "Morton Hagenes", 25, "Eos qui esse itaque.", 1000m, 3 },
                    { 36, "Et consectetur quae aut et dolorum at molestias.", 3, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Corporate", "Full-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senior Usability Manager", "Jazmyne Bogan", 21, "Cupiditate et nisi similique repudiandae nulla voluptates et reprehenderit.", 1000m, 3 },
                    { 40, "Nihil ratione in autem aut magni eius.", 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Internal", "Full-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Customer Markets Director", "Savanah Hagenes", 25, "Et aliquam placeat voluptatem praesentium ipsam.", 1000m, 2 },
                    { 37, "Magni delectus nemo aspernatur debitis est consectetur.", 3, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "National", "Part-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Future Markets Producer", "Casper Lubowitz", 25, "Quae est est suscipit.", 1000m, 2 },
                    { 39, "Aliquid repellendus ut.", 3, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dynamic", "Full-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forward Interactions Facilitator", "Dedric Stehr", 27, "Et quidem libero.", 1000m, 1 },
                    { 34, "Vel cum ea praesentium molestiae quae dolorem repellat.", 3, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lead", "Part-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Principal Directives Director", "Clyde Schinner", 28, "Quidem saepe accusamus impedit dolorum asperiores expedita tempore est.", 1000m, 1 }
                });

            migrationBuilder.InsertData(
                table: "FAVORITE_VACANCIES",
                columns: new[] { "ID", "USER_ID", "VACANCY_ID" },
                values: new object[,]
                {
                    { 85, 44, 34 },
                    { 87, 43, 34 },
                    { 86, 49, 32 },
                    { 88, 43, 39 },
                    { 89, 47, 39 },
                    { 91, 43, 39 },
                    { 84, 41, 36 },
                    { 83, 50, 31 },
                    { 92, 44, 31 },
                    { 90, 43, 40 }
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
