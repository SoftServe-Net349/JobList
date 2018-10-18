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
                    BIRTH_DATA = table.Column<DateTime>(type: "date", nullable: true),
                    EMAIL = table.Column<string>(unicode: false, maxLength: 150, nullable: false),
                    PASSWORD = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    ROLE_ID = table.Column<int>(nullable: false),
                    CITY_ID = table.Column<int>(nullable: true),
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
                columns: new[] { "ID", "ADDRESS", "BOSS_NAME", "EMAIL", "FULL_DESCRIPTION", "LOGO_DATA", "LOGO_MIMETYPE", "NAME", "PASSWORD", "PHONE", "REFRESH_TOKEN", "ROLE_ID", "SHORT_DESCRIPTION", "SITE" },
                values: new object[,]
                {
                    { 1, "095 Blanche Parks, Cartwrightchester, Cyprus", "Royal", "Vicente_Kassulke32@gmail.com", "Voluptatem aut et et ut dolorum distinctio consequuntur animi.", null, null, "Company № 724", "jxSAffMJye", "(364) 880 3364", null, 1, "veritatis", "http://arielle.info" },
                    { 5, "7714 Volkman Well, South Adellefort, Saudi Arabia", "Porter", "Cara_Harvey@yahoo.com", "Consequuntur mollitia alias rerum voluptate.", null, null, "Company № 698", "GN9r1gXR13", "(79) 152 7089", null, 4, "ipsa", "http://dominic.info" },
                    { 10, "414 Bayer Mountains, New Domingoton, United States Minor Outlying Islands", "Van", "Abdul28@gmail.com", "Atque alias qui possimus voluptate sunt deserunt ipsum.", null, null, "Company № 579", "YshCd7QYSM", "(520) 26 3834", null, 3, "voluptatem", "https://franco.info" },
                    { 9, "19961 Boyer Brooks, Boyerland, Azerbaijan", "Deshaun", "Jasen_Pfannerstill40@yahoo.com", "Est vel et est et tenetur labore eum.", null, null, "Company № 295", "yqFbxHM7_9", "(969) 986 5804", null, 3, "aut", "https://litzy.name" },
                    { 3, "2159 Vilma Plains, North Lowell, Croatia", "Tremayne", "Lemuel.Schroeder29@gmail.com", "Soluta et delectus.", null, null, "Company № 681", "US65Dqyygr", "(270) 433 7547", null, 3, "quos", "https://monserrate.org" },
                    { 8, "385 Macejkovic Green, Ratketon, Botswana", "Antwan", "Rozella_Schultz46@hotmail.com", "Nisi quod qui rerum distinctio quam autem ex in sit.", null, null, "Company № 998", "94uXXijeK0", "(131) 70 7399", null, 2, "dolorem", "http://guido.com" },
                    { 6, "164 Hyatt Station, East Deshawn, Antarctica (the territory South of 60 deg S)", "Efrain", "Demond_Toy@gmail.com", "Facere culpa est exercitationem.", null, null, "Company № 631", "kOL0Fg_PDL", "(654) 290 7024", null, 2, "perferendis", "http://dixie.biz" },
                    { 2, "134 Phyllis Spur, Nyahstad, Brunei Darussalam", "Katheryn", "Rebekah87@yahoo.com", "Natus dolor qui est similique.", null, null, "Company № 795", "RD7UiBQ530", "(37) 143 3297", null, 3, "aut", "https://hobart.biz" },
                    { 7, "636 Jaydon Junction, Eloisashire, Lithuania", "Amalia", "Lyric8@hotmail.com", "Qui rerum dolor reiciendis excepturi officia voluptatibus omnis ipsam.", null, null, "Company № 612", "URzO2pISWg", "(285) 359 6012", null, 1, "nihil", "http://pietro.net" },
                    { 4, "39514 Kozey Station, Lake Haleighfort, Indonesia", "Kale", "Santa_Russel@gmail.com", "Velit et sit ut dolor excepturi.", null, null, "Company № 943", "rAe8lAPMZm", "(488) 775 8569", null, 1, "ut", "https://gabrielle.info" }
                });

            migrationBuilder.InsertData(
                table: "USERS",
                columns: new[] { "ID", "BIRTH_DATA", "CITY_ID", "EMAIL", "FIRST_NAME", "LAST_NAME", "PASSWORD", "PHONE", "PHOTO_DATA", "PHOTO_MIME_TYPE", "REFRESH_TOKEN", "ROLE_ID", "SEX" },
                values: new object[,]
                {
                    { 38, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "Otilia_Schowalter22@yahoo.com", "Virgie", "Greenholt", "4WUGAjBqO3", "(970) 966 6139", null, null, null, 1, "m" },
                    { 46, new DateTime(1995, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "andr@gmail.com", "Andrew", "Felton", "qwerty", "0502758765", null, null, null, 2, "M" },
                    { 35, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Carrie_Murphy@gmail.com", "Monte", "Erdman", "AwFRLjSUHE", "(706) 292 6405", null, null, null, 4, "m" },
                    { 32, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Jermain_Schmeler@hotmail.com", "Anais", "Davis", "7qmN6ULYp_", "(519) 173 277", null, null, null, 1, "m" },
                    { 31, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Cathryn_Bosco@gmail.com", "Sally", "Miller", "FM0irs32Tw", "(935) 152 2163", null, null, null, 1, "m" },
                    { 33, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Humberto.Pfannerstill18@hotmail.com", "Alexandrine", "Abernathy", "dbZ5eI7mZr", "(547) 834 5730", null, null, null, 3, "m" },
                    { 37, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Leon58@hotmail.com", "Presley", "Cruickshank", "riyluq0jLr", "(789) 311 3448", null, null, null, 3, "m" },
                    { 40, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Robbie_Bogan35@hotmail.com", "Keyon", "Medhurst", "3xik5ZcaZj", "(390) 769 1179", null, null, null, 3, "f" },
                    { 34, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Mazie_Schumm@yahoo.com", "Reina", "Frami", "gV81Lgv5oV", "(571) 823 7456", null, null, null, 4, "f" },
                    { 39, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "Brooks98@gmail.com", "Thaddeus", "Schimmel", "_ryW5Q51xA", "(318) 158 1253", null, null, null, 1, "f" },
                    { 36, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Webster_Metz11@yahoo.com", "Lavon", "Jacobson", "C0UswTISrA", "(504) 484 4208", null, null, null, 4, "f" }
                });

            migrationBuilder.InsertData(
                table: "RECRUITERS",
                columns: new[] { "ID", "COMPANY_ID", "EMAIL", "FIRST_NAME", "LAST_NAME", "LOGO_DATA", "LOGO_MIMETYPE", "PASSWORD", "PHONE", "REFRESH_TOKEN", "ROLE_ID" },
                values: new object[,]
                {
                    { 17, 1, "Clotilde.Dare13@gmail.com", "Letitia", "Howe", null, null, "VlEHFPnRW7", "(446) 190 3578", null, 1 },
                    { 18, 1, "Arlo_Mueller35@yahoo.com", "Merle", "Harris", null, null, "MoBxW2bMWZ", "(104) 324 7770", null, 1 },
                    { 20, 1, "Lottie29@gmail.com", "Andres", "Hodkiewicz", null, null, "iyrcR2OgCK", "(554) 563 7446", null, 3 },
                    { 15, 4, "Meagan_Ruecker@hotmail.com", "Yazmin", "Miller", null, null, "qRevgOF3hT", "(351) 977 5772", null, 1 },
                    { 11, 6, "Birdie_Waters83@yahoo.com", "Gaetano", "Conn", null, null, "WGAVRdd96M", "(239) 229 7520", null, 2 },
                    { 14, 6, "Juston.Pacocha@yahoo.com", "Benny", "Effertz", null, null, "iGVE1L6jza", "(30) 226 3867", null, 3 },
                    { 19, 6, "Guy.Kulas40@gmail.com", "Natalie", "Greenfelder", null, null, "D22diZQY_L", "(788) 854 8649", null, 1 },
                    { 12, 3, "Shana_Altenwerth@gmail.com", "Marisa", "Bergstrom", null, null, "XBN2mMgQyE", "(158) 426 5041", null, 1 },
                    { 13, 9, "Arely_Strosin8@yahoo.com", "Josephine", "Lang", null, null, "v0ceRRvgDk", "(478) 731 9579", null, 2 },
                    { 16, 9, "Pierre.MacGyver69@hotmail.com", "Erick", "Mayert", null, null, "8cURf9SVMj", "(347) 320 2580", null, 4 }
                });

            migrationBuilder.InsertData(
                table: "RESUMES",
                columns: new[] { "ID", "COURSES", "CREATE_DATE", "FACEBOOK", "FAMILY_STATE", "GITHUB", "INSTAGRAM", "KEY_SKILLS", "LINKEDIN", "MOD_DATE", "SKYPE", "SOFT_SKILLS", "WORK_AREA_ID" },
                values: new object[,]
                {
                    { 46, "Certification training", new DateTime(2018, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "www.facebook.com", "not married", null, null, "hardworking, persuasive", null, null, null, "plastic surgery", 3 },
                    { 40, "Quod qui sunt harum eos aut.", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://sim.biz", "Numquam.", "http://chadd.name", "http://skylar.name", "Minima voluptatem culpa.", "https://wilhelmine.info", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "http://tiffany.name", "Ipsam unde id dolorem quibusdam atque molestiae.", 3 }
                });

            migrationBuilder.InsertData(
                table: "EDUCATION_PERIODS",
                columns: new[] { "ID", "FACULTY_ID", "FINISH_DATE", "RESUME_ID", "SCHOOL_ID", "START_DATE" },
                values: new object[,]
                {
                    { 61, 4, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, 4, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 5, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, 7, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 9, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 111, 4, new DateTime(2005, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 46, 8, new DateTime(2002, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 112, 2, new DateTime(2007, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 46, 5, new DateTime(2004, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, 7, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 7, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, 8, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, 10, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 10, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 4, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, 8, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 7, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 9, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "EXPERIENCES",
                columns: new[] { "ID", "COMPANY_NAME", "FINISH_DATE", "POSITION", "RESUME_ID", "START_DATE" },
                values: new object[,]
                {
                    { 46, "Houston Tromp", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quo recusandae esse ut.", 40, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, "Esteban Sauer", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Similique voluptatibus soluta rerum nam dolorem occaecati deleniti aut ut.", 40, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, "Camryn Stanton", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Consequatur occaecati veritatis corporis ullam dolor dolores quod ut.", 40, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, "Colt D'Amore", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Accusamus in natus.", 40, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, "Rachael Luettgen", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Officia numquam vel quia hic.", 40, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, "Hassan Will", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Accusamus rerum sunt nihil labore.", 40, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, "Floy Ward", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Illo eius non esse ut incidunt.", 40, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, "Ryder Braun", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nemo sapiente modi temporibus nesciunt vel dolorem ex.", 40, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65, "Triomed", new DateTime(2018, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Surgeon", 46, new DateTime(2008, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, "Kenna Langworth", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doloremque dolor provident impedit occaecati est.", 40, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, "Mertie Nolan", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sunt ut nostrum veniam aut velit omnis voluptas sit.", 40, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "RESUME_LANGUAGES",
                columns: new[] { "ID", "LANGUAGE_ID", "RESUME_ID" },
                values: new object[,]
                {
                    { 67, 4, 40 },
                    { 68, 1, 40 },
                    { 69, 4, 40 },
                    { 70, 4, 40 },
                    { 71, 2, 40 },
                    { 72, 10, 40 },
                    { 73, 2, 40 },
                    { 74, 9, 40 },
                    { 76, 8, 40 },
                    { 113, 7, 46 },
                    { 112, 5, 46 },
                    { 111, 10, 46 },
                    { 75, 2, 40 }
                });

            migrationBuilder.InsertData(
                table: "VACANCIES",
                columns: new[] { "ID", "BE_PLUS", "CITY_ID", "CREATE_DATE", "DESCRIPTION", "FULL_PART_TIME", "IS_CHECKED", "MOD_DATE", "NAME", "OFFERING", "RECRUITER_ID", "REQUIREMENTS", "SALARY", "WORK_AREA_ID" },
                values: new object[,]
                {
                    { 26, "Velit et totam omnis.", 9, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chief", "Part-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lead Mobility Orchestrator", "Ibrahim Miller", 13, "Repellat alias quis mollitia voluptatum sit fugiat laboriosam.", 1000m, 2 },
                    { 21, "Libero quis maiores.", 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Future", "Part-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Direct Communications Specialist", "Berry Kemmer", 12, "Aut et at molestiae quia culpa ratione facere alias.", 1000m, 10 },
                    { 25, "Aspernatur dolorum neque error magni soluta.", 3, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Internal", "Full-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "International Accountability Manager", "Maureen Langworth", 14, "Architecto expedita dolores est minus ut culpa repudiandae rerum nobis.", 1000m, 8 },
                    { 22, "At nihil vel.", 5, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dynamic", "Full-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senior Accountability Consultant", "Casimir Stokes", 14, "Aperiam et voluptatem veritatis totam aut excepturi vitae maiores.", 1000m, 4 },
                    { 28, "Aut placeat pariatur iste nemo quod aut magnam.", 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Regional", "Part-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Internal Division Architect", "Devyn Krajcik", 11, "Consequatur ut mollitia.", 1000m, 11 },
                    { 23, "Praesentium quos officia corporis qui tenetur natus nulla.", 6, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Global", "Full-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Corporate Program Assistant", "Mortimer Weissnat", 11, "Dolores amet illo vel accusantium illo id aliquid unde et.", 1000m, 6 },
                    { 27, "Quibusdam dolorum odio sit.", 10, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "International", "Full-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Legacy Operations Developer", "Martina Powlowski", 20, "Sit minima doloremque optio quibusdam ut delectus dolores.", 1000m, 9 },
                    { 30, "Nam eius accusantium repudiandae asperiores facere autem porro id.", 12, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Future", "Part-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Product Branding Coordinator", "Annetta MacGyver", 18, "Ea in provident.", 1000m, 5 },
                    { 29, "Sunt enim cumque id qui ut molestiae eius praesentium.", 11, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chief", "Part-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lead Data Coordinator", "Zella Kreiger", 18, "Ducimus voluptas necessitatibus.", 1000m, 12 },
                    { 24, "Aut quia et sequi.", 11, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dynamic", "Full-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Internal Applications Facilitator", "Alden D'Amore", 18, "Unde unde quo voluptas.", 1000m, 11 }
                });

            migrationBuilder.InsertData(
                table: "FAVORITE_VACANCIES",
                columns: new[] { "ID", "USER_ID", "VACANCY_ID" },
                values: new object[,]
                {
                    { 84, 31, 24 },
                    { 89, 38, 29 },
                    { 82, 38, 30 },
                    { 80, 39, 27 },
                    { 81, 34, 23 },
                    { 83, 32, 22 },
                    { 86, 46, 22 },
                    { 88, 38, 22 },
                    { 85, 31, 25 },
                    { 87, 32, 21 }
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
