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
                    NAME = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
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

            migrationBuilder.CreateTable(
                name: "INVITATIONS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EMPLOYEE_ID = table.Column<int>(nullable: false),
                    VACANCY_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVITATIONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_INVITATIONS_TO_EMPLOYEES",
                        column: x => x.EMPLOYEE_ID,
                        principalTable: "EMPLOYEES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_INVITATIONS_TO_VACANCIES",
                        column: x => x.VACANCY_ID,
                        principalTable: "VACANCIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CITIES",
                columns: new[] { "ID", "NAME" },
                values: new object[,]
                {
                    { 1, "New York" },
                    { 12, "Chicago" },
                    { 11, "San Francisco" },
                    { 10, "Phoneix" },
                    { 8, "Washington DC" },
                    { 7, "Seattle" },
                    { 9, "Las Vegas" },
                    { 5, "Boston" },
                    { 4, "Los Angeles" },
                    { 3, "Atlanta" },
                    { 2, "Jersey" },
                    { 6, "Philadelphia" }
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
                columns: new[] { "ID", "NAME" },
                values: new object[,]
                {
                    { 10, "Real Estate" },
                    { 9, "Insurance" },
                    { 8, "Arts" },
                    { 7, "Tourism" },
                    { 6, "Science" },
                    { 4, "Marketing and Advertising" },
                    { 3, "Medicine" },
                    { 2, "Sales" },
                    { 1, "IT" },
                    { 11, "Finances" },
                    { 5, "Law and Politics" },
                    { 12, "Media" }
                });

            migrationBuilder.InsertData(
                table: "COMPANIES",
                columns: new[] { "ID", "ADDRESS", "BOSS_NAME", "EMAIL", "FULL_DESCRIPTION", "LOGO_DATA", "LOGO_MIMETYPE", "NAME", "PASSWORD", "PHONE", "REFRESH_TOKEN", "ROLE_ID", "SHORT_DESCRIPTION", "SITE" },
                values: new object[,]
                {
                    { 10, "717 Lakin Trace, Lake Jeffery, Heard Island and McDonald Islands", "Tyrique", "Gudrun18@gmail.com", "Libero sequi et.", null, null, "Company 969", "Qstedti1UY", "(843) 11 9737", null, 3, "perspiciatis", "http://crystal.com" },
                    { 8, "15845 O'Keefe Corners, New Ozella, French Polynesia", "Sincere", "Fermin_Koepp58@gmail.com", "Consequatur et omnis.", null, null, "Company 365", "L9HOHG2Sv1", "(569) 270 7863", null, 3, "perspiciatis", "http://harold.name" },
                    { 7, "8661 Rozella Corners, Ryannville, Latvia", "Luigi", "Jennie.McGlynn76@gmail.com", "Eligendi ut cumque.", null, null, "Company 218", "3sBVMA4rfO", "(465) 674 5884", null, 3, "veniam", "https://kristofer.name" },
                    { 6, "12513 Lottie Drive, Cleveborough, Albania", "Stephen", "Fabiola30@gmail.com", "Quia aut vero.", null, null, "Company 536", "hLhGgFPrg6", "(252) 2 4496", null, 3, "sit", "http://nikita.info" },
                    { 5, "14896 Kozey Land, Port Collin, Kenya", "Kattie", "Sheridan8@yahoo.com", "Ab eos ut.", null, null, "Company 695", "1sOw6gBtVc", "(680) 501 9168", null, 3, "sunt", "https://eleazar.com" },
                    { 4, "2528 Lehner Hill, Dimitriside, Cuba", "Alice", "Vita.Abbott87@gmail.com", "Iste enim et.", null, null, "Company 496", "VBssphPpR4", "(645) 683 1266", null, 3, "alias", "http://selena.net" },
                    { 3, "8288 Parisian Views, New Rodrigo, Namibia", "Susana", "Floyd.Turner@hotmail.com", "Aut perspiciatis qui.", null, null, "Company 185", "TzLnwIlPes", "(455) 590 9597", null, 3, "quasi", "http://dustin.name" },
                    { 2, "9437 Haag Shoals, Robertsshire, Italy", "Vada", "Rae34@hotmail.com", "Porro necessitatibus recusandae.", null, null, "Company 480", "dOosNoACyc", "(497) 656 6488", null, 3, "et", "https://ismael.info" },
                    { 1, "87564 Destini Pines, West Oda, Namibia", "Frederique", "Cordell16@hotmail.com", "In vero accusantium.", null, null, "Company 88", "BqSyzllqdI", "(744) 415 624", null, 3, "illo", "https://leslie.net" },
                    { 9, "926 Mitchel Locks, South Friedrich, Bosnia and Herzegovina", "Peyton", "Mozell.Swaniawski@hotmail.com", "Maiores odit itaque.", null, null, "Company 957", "cMRuERiJli", "(67) 255 4503", null, 3, "corrupti", "http://rosie.info" }
                });

            migrationBuilder.InsertData(
                table: "EMPLOYEES",
                columns: new[] { "ID", "BIRTH_DATE", "CITY_ID", "EMAIL", "FIRST_NAME", "LAST_NAME", "PASSWORD", "PHONE", "PHOTO_DATA", "PHOTO_MIME_TYPE", "REFRESH_TOKEN", "ROLE_ID", "SEX" },
                values: new object[,]
                {
                    { 46, new DateTime(1995, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "andr@gmail.com", "Andrew", "Felton", "qwerty", "0502758765", null, null, null, 2, "M" },
                    { 39, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Ada13@yahoo.com", "Eryn", "Klein", "0DZazXLRcP", "(135) 290 8252", null, null, null, 2, "f" },
                    { 38, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, "Roxane.Leffler@gmail.com", "Letitia", "Berge", "yEbEjmoD8U", "(766) 241 1973", null, null, null, 2, "f" },
                    { 37, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Jaqueline_Rolfson@gmail.com", "Tremayne", "Rice", "kR7tjbTdFf", "(106) 254 2935", null, null, null, 2, "m" },
                    { 36, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Giuseppe_Considine@yahoo.com", "Demond", "Morissette", "DGjJAVU5MG", "(536) 179 7813", null, null, null, 2, "f" },
                    { 35, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Jadon37@gmail.com", "Alice", "Murray", "dBti0TOPht", "(961) 627 9041", null, null, null, 2, "f" },
                    { 34, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, "Myrtis12@hotmail.com", "Dominique", "Nitzsche", "F8Y6lghJ5f", "(394) 357 8433", null, null, null, 2, "f" },
                    { 33, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Carolyn.Conroy31@hotmail.com", "Catharine", "Yost", "LtLczGpvNh", "(168) 397 6706", null, null, null, 2, "f" },
                    { 32, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, "Athena40@gmail.com", "Chasity", "Romaguera", "nk392KsdY2", "(145) 872 9540", null, null, null, 2, "m" },
                    { 40, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "Octavia_Yost@hotmail.com", "Britney", "Jakubowski", "lVraJJh_TG", "(817) 120 4817", null, null, null, 2, "f" },
                    { 31, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Eloisa_Armstrong@hotmail.com", "Osborne", "Brakus", "McdDRgZA7C", "(521) 648 438", null, null, null, 2, "f" }
                });

            migrationBuilder.InsertData(
                table: "RECRUITERS",
                columns: new[] { "ID", "COMPANY_ID", "EMAIL", "FIRST_NAME", "LAST_NAME", "PASSWORD", "PHONE", "PHOTO_DATA", "PHOTO_MIMETYPE", "REFRESH_TOKEN", "ROLE_ID" },
                values: new object[,]
                {
                    { 15, 1, "Garnett_Flatley@yahoo.com", "Kyra", "Ritchie", "KV9GF4Ns70", "(313) 394 2486", null, null, null, 4 },
                    { 16, 2, "Isabel70@gmail.com", "Ora", "Bayer", "l3914xVXOK", "(880) 197 7568", null, null, null, 4 },
                    { 19, 5, "Blake_Jacobs35@hotmail.com", "Eugenia", "Strosin", "08OEz2p71k", "(614) 581 5330", null, null, null, 4 },
                    { 14, 6, "Leone.Koss50@yahoo.com", "Gaetano", "Barton", "kSylAXSOo_", "(381) 85 1508", null, null, null, 4 },
                    { 17, 6, "Zion_Kuhic@yahoo.com", "Helena", "Boyer", "6mcycFwtz_", "(263) 925 5077", null, null, null, 4 },
                    { 11, 7, "Kirstin_Bernhard99@gmail.com", "Giovanni", "Legros", "XKHzfPI8pQ", "(599) 209 2277", null, null, null, 4 },
                    { 12, 7, "Marshall.Koch30@hotmail.com", "Ole", "Kulas", "9ZxTQtmYZK", "(71) 832 4092", null, null, null, 4 },
                    { 18, 7, "Bonnie_Wehner@hotmail.com", "Haven", "Gottlieb", "b_9RyHjPL8", "(590) 702 7765", null, null, null, 4 },
                    { 20, 8, "Agnes_Corkery@gmail.com", "Arianna", "Feeney", "Fd0W_7LgTy", "(522) 972 5075", null, null, null, 4 },
                    { 13, 10, "Gayle80@hotmail.com", "Damaris", "Weimann", "VuxW9hJAVk", "(865) 885 1841", null, null, null, 4 }
                });

            migrationBuilder.InsertData(
                table: "RESUMES",
                columns: new[] { "ID", "COURSES", "CREATE_DATE", "FACEBOOK", "FAMILY_STATE", "GITHUB", "INSTAGRAM", "INTRODUCTION", "KEY_SKILLS", "LINKEDIN", "MOD_DATE", "POSITION", "SKYPE", "SOFT_SKILLS", "WORK_AREA_ID" },
                values: new object[,]
                {
                    { 33, "Earum labore amet quos alias nihil necessitatibus id dolores sit.", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://shany.org", "Ipsa.", "http://ara.biz", "https://neil.name", "Earum harum.", "Quo dolor.", "http://gregorio.info", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Occaecati.", "https://koby.info", "Ab et.", 4 },
                    { 46, "Certification training", new DateTime(2018, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "www.facebook.com", "not married", null, null, "Hello!", "hardworking, persuasive", null, null, null, null, "plastic surgery", 3 }
                });

            migrationBuilder.InsertData(
                table: "EDUCATION_PERIODS",
                columns: new[] { "ID", "FACULTY_ID", "FINISH_DATE", "RESUME_ID", "SCHOOL_ID", "START_DATE" },
                values: new object[,]
                {
                    { 55, 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, 3, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, 5, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, 5, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, 10, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, 6, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, 4, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, 5, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, 4, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, 3, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, 7, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, 7, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, 8, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, 9, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, 9, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, 4, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 111, 4, new DateTime(2005, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 46, 8, new DateTime(2002, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 112, 2, new DateTime(2007, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 46, 5, new DateTime(2004, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "EXPERIENCES",
                columns: new[] { "ID", "COMPANY_NAME", "FINISH_DATE", "POSITION", "RESUME_ID", "START_DATE" },
                values: new object[,]
                {
                    { 65, "Triomed", new DateTime(2018, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Surgeon", 46, new DateTime(2008, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, "Jimmy Rosenbaum", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aut repellendus dolores blanditiis quisquam ut.", 33, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, "Ryley Grant", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vitae error laborum magni minus facere sed eum.", 33, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, "Rachelle Volkman", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nesciunt autem voluptas illum qui eos tenetur.", 33, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, "Tessie DuBuque", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Unde necessitatibus at exercitationem saepe.", 33, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, "Marjory Dibbert", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amet quisquam qui ut sed dignissimos.", 33, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, "Damian Reynolds", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nam magni officia dolorem non deleniti sit.", 33, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, "Katlynn Hirthe", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Modi qui aut voluptatem natus saepe repellat.", 33, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, "Jensen King", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Et totam blanditiis nobis et.", 33, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, "Austin Ankunding", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maiores iste atque repellat corrupti illo possimus.", 33, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, "Ian Metz", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Earum repellendus quis.", 33, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "RESUME_LANGUAGES",
                columns: new[] { "ID", "LANGUAGE_ID", "RESUME_ID" },
                values: new object[,]
                {
                    { 76, 6, 33 },
                    { 113, 7, 46 },
                    { 112, 5, 46 },
                    { 111, 10, 46 },
                    { 75, 5, 33 },
                    { 69, 10, 33 },
                    { 73, 6, 33 },
                    { 72, 7, 33 },
                    { 71, 8, 33 },
                    { 70, 8, 33 },
                    { 68, 1, 33 },
                    { 67, 4, 33 },
                    { 74, 7, 33 }
                });

            migrationBuilder.InsertData(
                table: "VACANCIES",
                columns: new[] { "ID", "BE_PLUS", "CITY_ID", "CREATE_DATE", "DESCRIPTION", "FULL_PART_TIME", "IS_CHECKED", "MOD_DATE", "NAME", "OFFERING", "RECRUITER_ID", "REQUIREMENTS", "SALARY", "WORK_AREA_ID" },
                values: new object[,]
                {
                    { 24, "Qui sit vitae repellendus qui aspernatur deleniti.", 12, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Human", "Full-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chief Data Facilitator", "Cali Turner", 17, "Non porro expedita quia velit nihil.", 1000m, 9 },
                    { 29, "Nostrum illo et quo exercitationem.", 4, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Regional", "Full-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Internal Marketing Engineer", "Brett Feil", 14, "Et voluptas cumque non tempore vitae sed saepe debitis et.", 1000m, 1 },
                    { 23, "Vitae molestiae officia.", 4, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senior", "Part-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Principal Mobility Executive", "Roma Cruickshank", 14, "Sed et possimus incidunt totam illo rem expedita nisi.", 1000m, 9 },
                    { 30, "Iste vero molestias veniam delectus aut aut ea ratione.", 12, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Central", "Part-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Central Mobility Director", "Stan Kling", 19, "Eos quibusdam cupiditate qui autem consectetur nisi.", 1000m, 4 },
                    { 28, "Voluptatibus odio rerum veritatis ea nesciunt qui.", 10, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "International", "Part-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dynamic Operations Designer", "Mathew Denesik", 15, "Fugiat commodi possimus eius facilis est itaque assumenda aut optio.", 1000m, 1 },
                    { 21, "Temporibus doloribus enim est ut rem rerum consequuntur.", 10, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senior", "Part-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dynamic Markets Developer", "Bailey Buckridge", 19, "Voluptas et laborum corporis quo sit et et quo.", 1000m, 10 },
                    { 25, "Blanditiis eveniet dolor vero assumenda sunt qui voluptatibus.", 9, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Principal", "Full-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "National Quality Liaison", "Abagail Auer", 15, "Vel sunt laborum voluptatem saepe suscipit ipsa cupiditate facere.", 1000m, 6 },
                    { 22, "Officiis similique dolores voluptas delectus.", 11, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dynamic", "Full-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "District Intranet Architect", "Oren Haley", 12, "Praesentium quis rerum dolorem modi est aut rerum.", 1000m, 10 },
                    { 27, "Sed error consequatur ut non delectus.", 9, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "District", "Full-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Human Directives Planner", "Alfredo Spencer", 19, "Natus eligendi commodi.", 1000m, 12 },
                    { 26, "Deleniti atque earum quisquam voluptas voluptas.", 4, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Regional", "Full-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product Applications Assistant", "Eleanora Heathcote", 20, "Quia eius sint suscipit vel a iste quia placeat maxime.", 1000m, 8 }
                });

            migrationBuilder.InsertData(
                table: "FAVORITE_VACANCIES",
                columns: new[] { "ID", "EMPLOYEE_ID", "VACANCY_ID" },
                values: new object[,]
                {
                    { 81, 34, 25 },
                    { 87, 39, 25 },
                    { 82, 35, 21 },
                    { 84, 31, 21 },
                    { 89, 33, 24 },
                    { 85, 37, 27 },
                    { 88, 33, 30 },
                    { 80, 32, 26 },
                    { 86, 34, 24 },
                    { 83, 34, 29 }
                });

            migrationBuilder.InsertData(
                table: "INVITATIONS",
                columns: new[] { "ID", "EMPLOYEE_ID", "VACANCY_ID" },
                values: new object[,]
                {
                    { 98, 35, 24 },
                    { 97, 32, 24 },
                    { 93, 39, 29 },
                    { 94, 39, 30 },
                    { 95, 37, 30 },
                    { 92, 36, 21 },
                    { 99, 39, 28 },
                    { 91, 36, 25 },
                    { 96, 46, 30 },
                    { 90, 38, 26 }
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
                name: "IX_INVITATIONS_EMPLOYEE_ID",
                table: "INVITATIONS",
                column: "EMPLOYEE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INVITATIONS_VACANCY_ID",
                table: "INVITATIONS",
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
                name: "INVITATIONS");

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
