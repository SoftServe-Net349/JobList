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
                    NAME = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    PHOTO_DATA = table.Column<byte[]>(nullable: true),
                    PHOTO_MIMETYPE = table.Column<string>(unicode: false, maxLength: 5, nullable: true)
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
                    PHOTO_MIMETYPE = table.Column<string>(unicode: false, maxLength: 5, nullable: true)
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
                    SHORT_DESCRIPTION = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    ADDRESS = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    PHONE = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    LOGO_DATA = table.Column<byte[]>(nullable: true),
                    LOGO_MIMETYPE = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    SITE = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    EMAIL = table.Column<string>(unicode: false, maxLength: 254, nullable: false),
                    PASSWORD = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    ROLE_ID = table.Column<int>(nullable: false),
                    REFRESH_TOKEN = table.Column<string>(unicode: false, maxLength: 70, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPANIES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_COMPANIES_TO_ROLES",
                        column: x => x.ROLE_ID,
                        principalTable: "ROLES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYEES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FIRST_NAME = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    LAST_NAME = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    PHONE = table.Column<string>(unicode: false, maxLength: 15, nullable: true),
                    PHOTO_DATA = table.Column<byte[]>(nullable: true),
                    PHOTO_MIME_TYPE = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    SEX = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    BIRTH_DATE = table.Column<DateTime>(type: "date", nullable: false),
                    EMAIL = table.Column<string>(unicode: false, maxLength: 254, nullable: false),
                    PASSWORD = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    ROLE_ID = table.Column<int>(nullable: false),
                    CITY_ID = table.Column<int>(nullable: false),
                    REFRESH_TOKEN = table.Column<string>(unicode: false, maxLength: 70, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYEES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EMPLOYEES_TO_CITIES",
                        column: x => x.CITY_ID,
                        principalTable: "CITIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EMPLOYEES_TO_ROLES",
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
                    PHOTO_DATA = table.Column<byte[]>(nullable: true),
                    PHOTO_MIMETYPE = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    EMAIL = table.Column<string>(unicode: false, maxLength: 254, nullable: false),
                    PASSWORD = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    COMPANY_ID = table.Column<int>(nullable: false),
                    ROLE_ID = table.Column<int>(nullable: false),
                    REFRESH_TOKEN = table.Column<string>(unicode: false, maxLength: 70, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RECRUITERS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RECRUITERS_TO_COMPANIES",
                        column: x => x.COMPANY_ID,
                        principalTable: "COMPANIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
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
                    INTRODUCTION = table.Column<string>(unicode: false, maxLength: 300, nullable: false),
                    POSITION = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
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
                        name: "FK_RESUMES_TO_EMPLOYEES",
                        column: x => x.ID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PK_EDUCATION_PERIODS_TO_RESUMES",
                        column: x => x.RESUME_ID,
                        principalTable: "RESUMES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PK_EDUCATION_PERIODS_TO_SCHOOLS",
                        column: x => x.SCHOOL_ID,
                        principalTable: "SCHOOLS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FAVORITE_VACANCIES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VACANCY_ID = table.Column<int>(nullable: false),
                    EMPLOYEE_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAVORITE_VACANCIES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FAVORITE_VACANCIES_TO_EMPLOYEES",
                        column: x => x.EMPLOYEE_ID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FAVORITE_VACANCIES_TO_VACANCIES",
                        column: x => x.VACANCY_ID,
                        principalTable: "VACANCIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CITIES",
                columns: new[] { "ID", "NAME", "PHOTO_DATA", "PHOTO_MIMETYPE" },
                values: new object[,]
                {
                    { 1, "New York", null, null },
                    { 12, "Chicago", null, null },
                    { 11, "San Francisco", null, null },
                    { 10, "Phoneix", null, null },
                    { 8, "Washington DC", null, null },
                    { 7, "Seattle", null, null },
                    { 9, "Las Vegas", null, null },
                    { 5, "Boston", null, null },
                    { 4, "Los Angeles", null, null },
                    { 3, "Atlanta", null, null },
                    { 2, "Jersey", null, null },
                    { 6, "Philadephia", null, null }
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
                    { 2, "employee" },
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
                columns: new[] { "ID", "ADDRESS", "BOSS_NAME", "EMAIL", "FULL_DESCRIPTION", "LOGO_DATA", "LOGO_MIMETYPE", "NAME", "PASSWORD", "PHONE", "REFRESH_TOKEN", "ROLE_ID", "SHORT_DESCRIPTION", "SITE" },
                values: new object[,]
                {
                    { 10, "301 Heathcote Trafficway, New Stan, Jersey", "Greyson", "Ceasar_West52@gmail.com", "Tempore ad sit.", null, null, "Company 73", "gycoh_rv4g", "(67) 970 6276", null, 3, "voluptatem", "https://marquis.net" },
                    { 8, "4641 Kiana Motorway, Trystanland, Belarus", "Maximo", "Lucienne3@hotmail.com", "Et et magnam.", null, null, "Company 844", "MDWM2RyecF", "(380) 981 533", null, 3, "voluptates", "http://malinda.net" },
                    { 7, "76618 Luther Bypass, West Ricoside, Congo", "Valentine", "Efren_Marks@gmail.com", "Accusantium officia est.", null, null, "Company 285", "ZPAH2LzQCZ", "(553) 431 5956", null, 3, "velit", "http://arnoldo.net" },
                    { 6, "261 Alta Lakes, South Delphia, Marshall Islands", "Alysa", "Summer.Nicolas@gmail.com", "Totam cumque doloremque.", null, null, "Company 697", "xDhvXFZB7O", "(616) 394 4053", null, 3, "in", "https://reece.name" },
                    { 5, "977 Dare Pine, South Siennaview, Guinea-Bissau", "Bettie", "Victoria_Kub@yahoo.com", "Possimus sed qui.", null, null, "Company 715", "UF_52LXE9X", "(228) 998 4617", null, 3, "animi", "http://willa.info" },
                    { 4, "4233 Hamill Squares, East Julien, Tokelau", "Kathlyn", "Presley.Leannon@gmail.com", "Ullam non doloribus.", null, null, "Company 489", "srSI1zXOyM", "(604) 61 4335", null, 3, "autem", "http://timmothy.com" },
                    { 3, "7284 Brandyn Highway, Lake Ayden, Namibia", "Chandler", "Lessie.Huel@yahoo.com", "Cumque omnis doloremque.", null, null, "Company 283", "d_pvCdmOe3", "(19) 381 1570", null, 3, "est", "http://johnnie.net" },
                    { 2, "95873 Josie Village, Hartmannberg, Finland", "Zane", "Arielle_McGlynn@yahoo.com", "Quam labore rerum.", null, null, "Company 249", "k0R5FdngtX", "(121) 882 2622", null, 3, "vel", "http://janelle.com" },
                    { 1, "233 Eladio Expressway, Dibbertmouth, Virgin Islands, U.S.", "Barry", "Antonette.Nolan@gmail.com", "Sapiente omnis hic.", null, null, "Company 353", "A5HdONDZmA", "(463) 196 8327", null, 3, "nihil", "http://haylie.net" },
                    { 9, "544 Cartwright Streets, Violachester, Cuba", "Sally", "Tressa_Bayer49@yahoo.com", "Soluta mollitia doloremque.", null, null, "Company 292", "6if7kj8gSz", "(354) 67 4191", null, 3, "fugiat", "https://juana.com" }
                });

            migrationBuilder.InsertData(
                table: "EMPLOYEES",
                columns: new[] { "ID", "BIRTH_DATE", "CITY_ID", "EMAIL", "FIRST_NAME", "LAST_NAME", "PASSWORD", "PHONE", "PHOTO_DATA", "PHOTO_MIME_TYPE", "REFRESH_TOKEN", "ROLE_ID", "SEX" },
                values: new object[,]
                {
                    { 46, new DateTime(1995, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "andr@gmail.com", "Andrew", "Felton", "qwerty", "0502758765", null, null, null, 2, "M" },
                    { 39, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Kailey.Daugherty@gmail.com", "Odie", "Bechtelar", "kzNGzZaY8_", "(306) 478 5979", null, null, null, 2, "m" },
                    { 38, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Tyler_Borer20@hotmail.com", "Delaney", "Daugherty", "R6yHjKCjna", "(65) 708 1229", null, null, null, 2, "m" },
                    { 37, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, "Micah27@yahoo.com", "Verla", "Moore", "XW91n1UfXK", "(50) 73 2737", null, null, null, 2, "m" },
                    { 36, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Karelle_Bayer62@yahoo.com", "Brian", "Rogahn", "Ulazz19WBr", "(893) 859 2553", null, null, null, 2, "m" },
                    { 35, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Athena_Herzog52@gmail.com", "Naomi", "Fay", "OS8v8izf0r", "(284) 107 1493", null, null, null, 2, "f" },
                    { 34, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Sage99@gmail.com", "Nakia", "Hayes", "d_Gwya53MR", "(225) 949 3862", null, null, null, 2, "m" },
                    { 33, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Skylar80@yahoo.com", "Charlie", "White", "orvNuJtoqD", "(5) 563 8287", null, null, null, 2, "m" },
                    { 32, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Colleen.Luettgen@yahoo.com", "Claud", "Turner", "oPoGnnzPlk", "(899) 415 914", null, null, null, 2, "m" },
                    { 40, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Lourdes36@hotmail.com", "Schuyler", "Huel", "eAbh_pnmAp", "(94) 876 4349", null, null, null, 2, "f" },
                    { 31, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Skylar_Kilback68@yahoo.com", "Anabelle", "Wyman", "JSttYd8aNU", "(346) 880 7753", null, null, null, 2, "m" }
                });

            migrationBuilder.InsertData(
                table: "RECRUITERS",
                columns: new[] { "ID", "COMPANY_ID", "EMAIL", "FIRST_NAME", "LAST_NAME", "PASSWORD", "PHONE", "PHOTO_DATA", "PHOTO_MIMETYPE", "REFRESH_TOKEN", "ROLE_ID" },
                values: new object[,]
                {
                    { 18, 1, "Garnett_Emard@hotmail.com", "Ottilie", "Greenfelder", "mB6NOHijXu", "(545) 461 6690", null, null, null, 4 },
                    { 20, 1, "Matilda.Koelpin32@yahoo.com", "Chesley", "Funk", "UCFk1SqarA", "(870) 768 7096", null, null, null, 4 },
                    { 14, 2, "Casper31@yahoo.com", "Estella", "Conroy", "4vnuefbFNn", "(611) 101 9380", null, null, null, 4 },
                    { 15, 3, "Melba22@yahoo.com", "Myron", "Adams", "MvVb1KtV0N", "(558) 225 638", null, null, null, 4 },
                    { 11, 4, "Kiara59@yahoo.com", "Krystina", "Grady", "JNUtpFjmEB", "(896) 404 1662", null, null, null, 4 },
                    { 17, 4, "Roxane.Gottlieb@gmail.com", "Betty", "Yost", "NBX8p7QOn7", "(47) 569 6037", null, null, null, 4 },
                    { 12, 5, "Aileen.Murazik12@hotmail.com", "Margarita", "Auer", "RXDfH9g9mR", "(236) 581 1592", null, null, null, 4 },
                    { 13, 5, "Josephine56@yahoo.com", "Oscar", "Anderson", "r29ilFEzHV", "(803) 313 6781", null, null, null, 4 },
                    { 16, 7, "Frank.Waters@yahoo.com", "Mason", "Huels", "1cZMYEJcqf", "(889) 997 8461", null, null, null, 4 },
                    { 19, 10, "Annamarie_Yost82@hotmail.com", "Samantha", "Bahringer", "7SvHJSteFU", "(522) 71 7744", null, null, null, 4 }
                });

            migrationBuilder.InsertData(
                table: "RESUMES",
                columns: new[] { "ID", "COURSES", "CREATE_DATE", "FACEBOOK", "FAMILY_STATE", "GITHUB", "INSTAGRAM", "INTRODUCTION", "KEY_SKILLS", "LINKEDIN", "MOD_DATE", "POSITION", "SKYPE", "SOFT_SKILLS", "WORK_AREA_ID" },
                values: new object[,]
                {
                    { 39, "Rem beatae reiciendis quam consequatur autem rem numquam.", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://delphia.info", "Earum.", "https://miles.name", "http://alanna.net", "Iste soluta.", "Sequi magni.", "http://nikko.name", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ab.", "https://oliver.net", "Omnis repellendus.", 7 },
                    { 46, "Certification training", new DateTime(2018, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "www.facebook.com", "not married", null, null, "Hello!", "hardworking, persuasive", null, null, null, null, "plastic surgery", 3 }
                });

            migrationBuilder.InsertData(
                table: "EDUCATION_PERIODS",
                columns: new[] { "ID", "FACULTY_ID", "FINISH_DATE", "RESUME_ID", "SCHOOL_ID", "START_DATE" },
                values: new object[,]
                {
                    { 55, 9, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 39, 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 39, 3, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, 9, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 39, 8, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, 6, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 39, 8, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 39, 5, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 39, 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, 4, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 39, 7, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, 3, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 39, 10, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, 4, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 39, 4, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, 4, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 39, 8, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 111, 4, new DateTime(2005, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 46, 8, new DateTime(2002, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 112, 2, new DateTime(2007, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 46, 5, new DateTime(2004, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "EXPERIENCES",
                columns: new[] { "ID", "COMPANY_NAME", "FINISH_DATE", "POSITION", "RESUME_ID", "START_DATE" },
                values: new object[,]
                {
                    { 65, "Triomed", new DateTime(2018, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Surgeon", 46, new DateTime(2008, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, "Ubaldo Walker", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ab architecto et explicabo eos itaque qui.", 39, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, "Joanie Haley", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ut non in.", 39, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, "Abigale Medhurst", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Possimus suscipit delectus laudantium.", 39, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, "Therese Leffler", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Repudiandae ut dolorum consectetur voluptas voluptas corrupti labore.", 39, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, "Bradford Hyatt", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aut perferendis qui aliquam eos reprehenderit aspernatur sed et cumque.", 39, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, "Rhea Volkman", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Magni sed labore incidunt ex deleniti.", 39, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, "Mina Kunde", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Est qui magnam consequatur deserunt delectus maxime perspiciatis ea.", 39, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, "Randal Mueller", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aut aut aut voluptas eos.", 39, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, "Lexi Farrell", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Natus voluptatem molestias nulla aut eos facilis.", 39, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, "Irving Wisoky", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nihil libero vitae.", 39, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "RESUME_LANGUAGES",
                columns: new[] { "ID", "LANGUAGE_ID", "RESUME_ID" },
                values: new object[,]
                {
                    { 76, 3, 39 },
                    { 113, 7, 46 },
                    { 112, 5, 46 },
                    { 111, 10, 46 },
                    { 75, 4, 39 },
                    { 69, 3, 39 },
                    { 73, 3, 39 },
                    { 72, 3, 39 },
                    { 71, 9, 39 },
                    { 70, 4, 39 },
                    { 68, 9, 39 },
                    { 67, 8, 39 },
                    { 74, 5, 39 }
                });

            migrationBuilder.InsertData(
                table: "VACANCIES",
                columns: new[] { "ID", "BE_PLUS", "CITY_ID", "CREATE_DATE", "DESCRIPTION", "FULL_PART_TIME", "IS_CHECKED", "MOD_DATE", "NAME", "OFFERING", "RECRUITER_ID", "REQUIREMENTS", "SALARY", "WORK_AREA_ID" },
                values: new object[,]
                {
                    { 23, "Modi adipisci deserunt ipsam.", 9, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Future", "Part-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Customer Applications Representative", "Linnea Kunze", 13, "Voluptatem necessitatibus impedit assumenda libero consectetur odit facilis nulla.", 1000m, 7 },
                    { 22, "Voluptates atque sunt dolorem ut dolorum est hic.", 11, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Direct", "Full-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Investor Quality Specialist", "Geovanny Kemmer", 13, "Quisquam esse est ut veritatis velit.", 1000m, 2 },
                    { 21, "Mollitia iste voluptate id et enim tempora.", 4, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senior", "Full-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Principal Response Analyst", "Reyna Bednar", 13, "Dolores velit architecto aut in.", 1000m, 3 },
                    { 25, "Ea id quia reprehenderit ut.", 3, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Investor", "Part-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lead Response Assistant", "Weldon Batz", 12, "Qui repellat et in incidunt enim quod.", 1000m, 1 },
                    { 30, "Iure alias quas est laborum et voluptate illo.", 3, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forward", "Part-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product Usability Executive", "Eden Murray", 20, "Earum et saepe laborum sed autem quisquam.", 1000m, 9 },
                    { 28, "Et id consequatur illo tempore atque sunt sint.", 4, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Internal", "Full-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Direct Directives Liaison", "Christelle Keeling", 14, "Beatae omnis dicta atque architecto nisi sed ut distinctio neque.", 1000m, 10 },
                    { 27, "Cumque rerum quaerat voluptatem quod quia quae quia et tempora.", 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Regional", "Full-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Direct Applications Developer", "Pattie Kunze", 18, "In animi aliquid aut eveniet est.", 1000m, 9 },
                    { 29, "Veritatis beatae nobis laborum rerum ex saepe.", 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Customer", "Part-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Future Security Consultant", "Rosamond Haag", 13, "Quidem rerum dolorum odit ipsum nam libero reiciendis.", 1000m, 11 },
                    { 26, "Et rerum omnis nihil natus necessitatibus aut molestiae mollitia id.", 10, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Legacy", "Full-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Human Markets Developer", "Jaqueline Kris", 15, "Officia tenetur deleniti aut natus.", 1000m, 8 },
                    { 24, "Veniam temporibus velit porro ut harum et.", 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "International", "Full-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dynamic Markets Supervisor", "Bartholome Weissnat", 19, "Nulla quis odit quas.", 1000m, 3 }
                });

            migrationBuilder.InsertData(
                table: "FAVORITE_VACANCIES",
                columns: new[] { "ID", "EMPLOYEE_ID", "VACANCY_ID" },
                values: new object[,]
                {
                    { 81, 33, 30 },
                    { 84, 36, 30 },
                    { 86, 31, 28 },
                    { 87, 32, 28 },
                    { 88, 36, 28 },
                    { 82, 31, 21 },
                    { 83, 38, 21 },
                    { 85, 39, 22 },
                    { 80, 36, 29 },
                    { 89, 31, 24 }
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
                name: "UQ_COMPANIES_REFRESH_TOKEN",
                table: "COMPANIES",
                column: "REFRESH_TOKEN",
                unique: true,
                filter: "[REFRESH_TOKEN] IS NOT NULL");

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
                name: "IX_EMPLOYEES_CITY_ID",
                table: "EMPLOYEES",
                column: "CITY_ID");

            migrationBuilder.CreateIndex(
                name: "UQ_EMPLOYEES_EMAIL",
                table: "EMPLOYEES",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ_EMPLOYEES_PHONE",
                table: "EMPLOYEES",
                column: "PHONE",
                unique: true,
                filter: "[PHONE] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ_EMPLOYEES_REFRESH_TOKEN",
                table: "EMPLOYEES",
                column: "REFRESH_TOKEN",
                unique: true,
                filter: "[REFRESH_TOKEN] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYEES_ROLE_ID",
                table: "EMPLOYEES",
                column: "ROLE_ID");

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
                name: "IX_FAVORITE_VACANCIES_EMPLOYEE_ID",
                table: "FAVORITE_VACANCIES",
                column: "EMPLOYEE_ID");

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
                name: "UQ_RECRUITERS_REFRESH_TOKEN",
                table: "RECRUITERS",
                column: "REFRESH_TOKEN",
                unique: true,
                filter: "[REFRESH_TOKEN] IS NOT NULL");

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
                name: "EMPLOYEES");

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
