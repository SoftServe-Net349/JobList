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
                    { 10, "21847 Hickle Junctions, Braxtonport, Dominica", "Myrna", "Jennings.Moen17@hotmail.com", "Rerum consequatur aliquid.", null, null, "Company 123", "YbZOKh7DrL", "(74) 328 3440", null, 3, "illo", "http://selena.biz" },
                    { 8, "36432 Ashton Shoal, Amirshire, Mayotte", "Savanah", "Ariane25@hotmail.com", "Accusamus odit quos.", null, null, "Company 413", "AHQCVZvji7", "(753) 644 7118", null, 3, "consequatur", "https://megane.biz" },
                    { 7, "4123 Runolfsson Mills, Ellenfort, Puerto Rico", "Angie", "Xzavier39@hotmail.com", "Dolores aut occaecati.", null, null, "Company 88", "7fpQWtmBJv", "(245) 597 99", null, 3, "dignissimos", "http://ozella.info" },
                    { 6, "4632 Christiansen Turnpike, Jacobiberg, Samoa", "Ila", "Jalen_OHara29@yahoo.com", "Ea voluptates quia.", null, null, "Company 870", "KDrLOb5cWA", "(292) 104 8314", null, 3, "itaque", "http://madilyn.net" },
                    { 5, "515 Elvis Corners, Briceport, Bolivia", "Trinity", "Lela_Hegmann20@hotmail.com", "Et sequi temporibus.", null, null, "Company 367", "9MpfkJoP0y", "(802) 390 4740", null, 3, "alias", "http://clinton.org" },
                    { 4, "4344 Hegmann Port, Ryannbury, American Samoa", "Bill", "Marlen24@hotmail.com", "At excepturi provident.", null, null, "Company 737", "pu1IzSGXMQ", "(24) 17 1339", null, 3, "eius", "https://abbey.info" },
                    { 3, "879 Bradtke Avenue, South Luella, United Kingdom", "Jeffrey", "Hilton_Fadel@gmail.com", "Dolorum minima corporis.", null, null, "Company 866", "BLwOyfAD1W", "(521) 145 7492", null, 3, "eos", "https://ashton.com" },
                    { 2, "181 Carolina Orchard, South Amelie, Spain", "Rusty", "Oscar95@hotmail.com", "Doloremque ut eveniet.", null, null, "Company 349", "av4Bcf1Q8H", "(249) 181 4869", null, 3, "dolorum", "http://juanita.biz" },
                    { 1, "4024 Cicero Key, Port Murrayhaven, Argentina", "Darron", "Janie.Marquardt64@hotmail.com", "Est corporis maiores.", null, null, "Company 930", "lZm4R8SJRN", "(308) 497 2844", null, 3, "et", "http://houston.net" },
                    { 9, "71092 Manley Locks, Kuhlmanberg, France", "Barrett", "Adah.Osinski@hotmail.com", "Voluptatem minima rem.", null, null, "Company 373", "KnHGmjfaBc", "(8) 856 8865", null, 3, "laboriosam", "http://annabelle.name" }
                });

            migrationBuilder.InsertData(
                table: "EMPLOYEES",
                columns: new[] { "ID", "BIRTH_DATE", "CITY_ID", "EMAIL", "FIRST_NAME", "LAST_NAME", "PASSWORD", "PHONE", "PHOTO_DATA", "PHOTO_MIME_TYPE", "REFRESH_TOKEN", "ROLE_ID", "SEX" },
                values: new object[,]
                {
                    { 46, new DateTime(1995, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "andr@gmail.com", "Andrew", "Felton", "qwerty", "0502758765", null, null, null, 2, "M" },
                    { 39, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Aubree74@gmail.com", "Kade", "Rodriguez", "orXtZC9_V1", "(31) 805 133", null, null, null, 2, "f" },
                    { 38, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Hassan58@yahoo.com", "Brayan", "Oberbrunner", "Q9NdzKf6P5", "(180) 679 8164", null, null, null, 2, "f" },
                    { 37, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Donnie_Stoltenberg0@gmail.com", "Treva", "Powlowski", "xD7o4_FLSZ", "(363) 173 8801", null, null, null, 2, "f" },
                    { 36, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "Orval22@gmail.com", "Ernest", "Hodkiewicz", "rzzsO2eWK0", "(761) 135 9904", null, null, null, 2, "f" },
                    { 35, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Janiya_OConner@hotmail.com", "Pansy", "Dickinson", "ucqsJR8GQW", "(107) 4 6952", null, null, null, 2, "m" },
                    { 34, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "Duane_Lueilwitz@hotmail.com", "Vivien", "Emmerich", "YViXYm5XKu", "(33) 699 8801", null, null, null, 2, "m" },
                    { 33, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Alessia_Mosciski59@hotmail.com", "Yessenia", "Bednar", "QmHu3qb61w", "(90) 703 9954", null, null, null, 2, "m" },
                    { 32, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Montana_Strosin48@hotmail.com", "Marian", "Schultz", "9rZ5FCWesk", "(306) 886 5992", null, null, null, 2, "m" },
                    { 40, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, "Hardy50@hotmail.com", "Hubert", "Kiehn", "FsqrWYvHqT", "(306) 64 1222", null, null, null, 2, "f" },
                    { 31, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Mikayla.Reilly@yahoo.com", "Kelli", "Wisozk", "ynpLFdhyBE", "(356) 140 4841", null, null, null, 2, "f" }
                });

            migrationBuilder.InsertData(
                table: "RECRUITERS",
                columns: new[] { "ID", "COMPANY_ID", "EMAIL", "FIRST_NAME", "LAST_NAME", "PASSWORD", "PHONE", "PHOTO_DATA", "PHOTO_MIMETYPE", "REFRESH_TOKEN", "ROLE_ID" },
                values: new object[,]
                {
                    { 12, 3, "Tracy.Kshlerin@gmail.com", "Jodie", "Moore", "eThmdexJaC", "(550) 626 7102", null, null, null, 4 },
                    { 14, 3, "Americo.Greenfelder71@gmail.com", "Eugenia", "Pouros", "sFWB8ErnI4", "(421) 423 8892", null, null, null, 4 },
                    { 11, 4, "Kyla_MacGyver@hotmail.com", "Amanda", "Labadie", "t7SMrgns62", "(393) 220 8093", null, null, null, 4 },
                    { 16, 6, "Robin83@hotmail.com", "Joelle", "Hudson", "M6GRrJanIj", "(416) 981 7799", null, null, null, 4 },
                    { 18, 6, "Geoffrey.Osinski77@hotmail.com", "Adolf", "Jacobson", "OybBxMUcjK", "(519) 74 291", null, null, null, 4 },
                    { 19, 6, "Ericka_Zulauf74@hotmail.com", "Frieda", "Wehner", "tTowmgV81h", "(322) 203 1375", null, null, null, 4 },
                    { 13, 7, "Anabel26@gmail.com", "Mariano", "Langosh", "V2S_MPOLVq", "(592) 569 8486", null, null, null, 4 },
                    { 20, 7, "Immanuel.Heidenreich53@yahoo.com", "Isidro", "Pollich", "01UzMDlxr3", "(732) 946 5720", null, null, null, 4 },
                    { 15, 8, "Mike_Parisian@hotmail.com", "Jayson", "Mayert", "78AYQsp3vK", "(239) 638 9869", null, null, null, 4 },
                    { 17, 10, "Gregoria_Gottlieb87@yahoo.com", "Adelia", "Rodriguez", "Meub73HsBb", "(85) 503 9423", null, null, null, 4 }
                });

            migrationBuilder.InsertData(
                table: "RESUMES",
                columns: new[] { "ID", "COURSES", "CREATE_DATE", "FACEBOOK", "FAMILY_STATE", "GITHUB", "INSTAGRAM", "INTRODUCTION", "KEY_SKILLS", "LINKEDIN", "MOD_DATE", "POSITION", "SKYPE", "SOFT_SKILLS", "WORK_AREA_ID" },
                values: new object[,]
                {
                    { 32, "Voluptatem maxime modi.", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://lilliana.com", "Mollitia.", "http://ava.net", "https://llewellyn.org", "Ipsa praesentium.", "Rerum voluptate.", "https://alta.com", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sunt.", "http://baby.biz", "Et non.", 10 },
                    { 46, "Certification training", new DateTime(2018, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "www.facebook.com", "not married", null, null, "Hello!", "hardworking, persuasive", null, null, null, null, "plastic surgery", 3 }
                });

            migrationBuilder.InsertData(
                table: "EDUCATION_PERIODS",
                columns: new[] { "ID", "FACULTY_ID", "FINISH_DATE", "RESUME_ID", "SCHOOL_ID", "START_DATE" },
                values: new object[,]
                {
                    { 55, 6, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, 3, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, 5, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, 5, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, 10, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, 6, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, 8, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, 4, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, 4, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, 7, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, 6, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, 6, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, 8, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, 8, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, 6, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, 4, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 111, 4, new DateTime(2005, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 46, 8, new DateTime(2002, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 112, 2, new DateTime(2007, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 46, 5, new DateTime(2004, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "EXPERIENCES",
                columns: new[] { "ID", "COMPANY_NAME", "FINISH_DATE", "POSITION", "RESUME_ID", "START_DATE" },
                values: new object[,]
                {
                    { 65, "Triomed", new DateTime(2018, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Surgeon", 46, new DateTime(2008, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, "Austin Kozey", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reprehenderit nulla nulla nulla.", 32, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, "Quincy Champlin", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deleniti velit non amet.", 32, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, "Quinton Purdy", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dolor ut laborum.", 32, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, "Queenie Cremin", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ipsum aut magni aperiam voluptas excepturi reprehenderit.", 32, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, "Vilma Hansen", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maiores maiores ratione aperiam natus nihil sed perspiciatis debitis repudiandae.", 32, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, "Noel Stoltenberg", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consequuntur officia hic sint neque.", 32, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, "Ernie Gutmann", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Natus et delectus harum.", 32, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, "Joshuah Block", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ea eum nulla unde culpa fugiat corporis error.", 32, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, "Efren Lubowitz", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Commodi et fugiat cum laborum nulla perspiciatis sapiente.", 32, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, "Justen Hickle", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sint et optio vel nihil et odio.", 32, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "RESUME_LANGUAGES",
                columns: new[] { "ID", "LANGUAGE_ID", "RESUME_ID" },
                values: new object[,]
                {
                    { 76, 7, 32 },
                    { 113, 7, 46 },
                    { 112, 5, 46 },
                    { 111, 10, 46 },
                    { 75, 9, 32 },
                    { 69, 1, 32 },
                    { 73, 6, 32 },
                    { 72, 3, 32 },
                    { 71, 8, 32 },
                    { 70, 9, 32 },
                    { 68, 4, 32 },
                    { 67, 2, 32 },
                    { 74, 2, 32 }
                });

            migrationBuilder.InsertData(
                table: "VACANCIES",
                columns: new[] { "ID", "BE_PLUS", "CITY_ID", "CREATE_DATE", "DESCRIPTION", "FULL_PART_TIME", "IS_CHECKED", "MOD_DATE", "NAME", "OFFERING", "RECRUITER_ID", "REQUIREMENTS", "SALARY", "WORK_AREA_ID" },
                values: new object[,]
                {
                    { 28, "Alias aspernatur qui molestias ratione quia qui quos.", 10, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Internal", "Full-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product Usability Producer", "Laron Hessel", 16, "Accusantium repellat libero adipisci.", 1000m, 3 },
                    { 27, "Ut aliquid aliquam perspiciatis debitis occaecati nemo maxime est odit.", 4, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Principal", "Part-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Direct Program Associate", "Reba Jaskolski", 16, "Nesciunt error et aspernatur explicabo totam iste occaecati voluptatibus.", 1000m, 11 },
                    { 30, "Temporibus ut aliquid debitis cumque.", 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "International", "Part-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Global Factors Assistant", "Ryley McCullough", 14, "Cumque tempora dicta aut earum rerum.", 1000m, 8 },
                    { 29, "Nobis et ex officia ut veniam nesciunt.", 3, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Investor", "Part-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senior Program Assistant", "Alec Blick", 14, "Similique ratione est eius.", 1000m, 11 },
                    { 22, "Quidem quis tempore alias illo voluptatibus nostrum sit nesciunt.", 7, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chief", "Full-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Central Intranet Representative", "Tomas Ortiz", 14, "Incidunt occaecati eum cumque occaecati qui similique maxime.", 1000m, 8 },
                    { 23, "Ea corrupti blanditiis et et assumenda ut mollitia.", 7, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Corporate", "Full-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "International Quality Assistant", "Lewis Boyle", 14, "Accusamus vero consequatur temporibus.", 1000m, 4 },
                    { 21, "Et quia iusto.", 6, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senior", "Full-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Forward Data Assistant", "Seth Hackett", 12, "Eos deleniti suscipit.", 1000m, 5 },
                    { 26, "Iste et impedit voluptas.", 6, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chief", "Part-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Legacy Security Consultant", "Maryse Koch", 19, "Quo sequi incidunt pariatur.", 1000m, 6 },
                    { 25, "Similique aut praesentium ullam nisi illum.", 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chief", "Full-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dynamic Applications Orchestrator", "Joany Kub", 14, "Quasi officia sit dolores odit.", 1000m, 5 },
                    { 24, "Omnis sint rerum eum a ut recusandae nulla cumque consequatur.", 8, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Central", "Full-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Investor Data Consultant", "Owen Koss", 20, "Asperiores magni officiis explicabo necessitatibus recusandae.", 1000m, 3 }
                });

            migrationBuilder.InsertData(
                table: "FAVORITE_VACANCIES",
                columns: new[] { "ID", "EMPLOYEE_ID", "VACANCY_ID" },
                values: new object[,]
                {
                    { 85, 33, 24 },
                    { 84, 46, 25 },
                    { 86, 33, 25 },
                    { 87, 39, 26 },
                    { 83, 40, 29 },
                    { 89, 35, 29 },
                    { 80, 38, 30 },
                    { 81, 36, 24 },
                    { 88, 46, 28 },
                    { 82, 34, 28 }
                });

            migrationBuilder.InsertData(
                table: "INVITATIONS",
                columns: new[] { "ID", "EMPLOYEE_ID", "VACANCY_ID" },
                values: new object[,]
                {
                    { 98, 34, 26 },
                    { 91, 31, 26 },
                    { 92, 36, 30 },
                    { 94, 39, 27 },
                    { 90, 40, 27 },
                    { 95, 39, 25 },
                    { 97, 34, 22 },
                    { 99, 38, 21 },
                    { 96, 36, 27 },
                    { 93, 33, 21 }
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
