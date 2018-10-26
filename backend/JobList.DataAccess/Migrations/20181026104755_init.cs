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
                    { 11111, "2D Sadova Street Lviv", "Taras Kytsmey", "company@gmail.com", "At SoftServe, we strive to make the world a better place. Our Corporate Social Responsibility program ensures a sustainable future for our associates, our company, and the communities in which we live and work across the globe. The key to fulfilling this mission is our responsibility towards customers, associates, and society. We are committed to addressing various economic, social, and environmental issues.", null, null, "SoftServe", "CdMwWKQ0n40R4dK/zsjIx0XhXdgxXCcyJfbbuViFMJC2mVik", "0322409090", null, 3, "Build you career here", "https://softserveinc.com/en-us/" },
                    { 9, "34096 Krajcik Streets, Port Randalberg, Zimbabwe", "Edward", "Malvina76@yahoo.com", "Dolor optio occaecati.", null, null, "Company 365", "7A6jTHvsWO", "(501) 15 7611", null, 3, "pariatur", "http://isadore.biz" },
                    { 8, "0287 Hegmann Mountain, Belleland, New Zealand", "Maryse", "Marcia.Leannon62@yahoo.com", "Fugiat dolorum ut.", null, null, "Company 263", "u7PM0xB4en", "(373) 184 4726", null, 3, "dicta", "http://orland.name" },
                    { 7, "68058 Kunze Gateway, New Camrenmouth, Bhutan", "Lorna", "Jessica_Friesen@hotmail.com", "Sapiente odio fugiat.", null, null, "Company 933", "J8Mcfm8ml5", "(591) 664 8740", null, 3, "debitis", "http://deon.com" },
                    { 6, "97819 Bruen Circle, West Jaytown, Myanmar", "Bruce", "Arvilla31@gmail.com", "Nemo cum enim.", null, null, "Company 485", "TEVSfAB5xI", "(414) 833 7242", null, 3, "quae", "http://frederik.biz" },
                    { 5, "824 Dolly Freeway, North Barneybury, Nigeria", "Meghan", "Cierra85@hotmail.com", "Inventore nesciunt maxime.", null, null, "Company 634", "koYwA3rCwp", "(355) 383 9547", null, 3, "omnis", "https://cecilia.com" },
                    { 4, "47723 Hirthe Estate, East Saulmouth, Cape Verde", "Murphy", "Scotty9@yahoo.com", "Et consequatur possimus.", null, null, "Company 933", "Gu1bb6iabO", "(330) 37 213", null, 3, "sit", "http://ethan.biz" },
                    { 3, "94379 Carter Shores, Sonyastad, Cayman Islands", "Victoria", "Rosella_Kling16@yahoo.com", "Quis ab nihil.", null, null, "Company 527", "8czF9wuy5N", "(503) 815 5857", null, 3, "voluptas", "https://zander.com" },
                    { 2, "7954 Tess Branch, Tremblayshire, Grenada", "Madilyn", "Melyssa21@hotmail.com", "Porro et eligendi.", null, null, "Company 33", "oAjEAMMQkZ", "(87) 113 3233", null, 3, "velit", "https://mariah.net" },
                    { 1, "08100 Abshire Courts, East Christine, India", "Weldon", "Jovanny21@hotmail.com", "Facilis nesciunt quia.", null, null, "Company 64", "TtbI_PZu1x", "(864) 845 5647", null, 3, "omnis", "http://carter.com" },
                    { 10, "4004 Rebeka Garden, Millsshire, Ghana", "Skye", "Germaine91@hotmail.com", "Repellat in ut.", null, null, "Company 98", "8RhT3Eo2sR", "(793) 615 2203", null, 3, "nemo", "https://sandy.name" }
                });

            migrationBuilder.InsertData(
                table: "EMPLOYEES",
                columns: new[] { "ID", "BIRTH_DATE", "CITY_ID", "EMAIL", "FIRST_NAME", "LAST_NAME", "PASSWORD", "PHONE", "PHOTO_DATA", "PHOTO_MIME_TYPE", "REFRESH_TOKEN", "ROLE_ID", "SEX" },
                values: new object[,]
                {
                    { 46, new DateTime(1995, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "employee@gmail.com", "Andrew", "Felton", "CdMwWKQ0n40R4dK/zsjIx0XhXdgxXCcyJfbbuViFMJC2mVik", "0502758765", null, null, null, 2, "m" },
                    { 43, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Jennie_Trantow@yahoo.com", "Hilario", "Muller", "HqTcBzu_eg", "(662) 342 1372", null, null, null, 2, "f" },
                    { 42, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "Davin68@gmail.com", "Alphonso", "Cormier", "fuQD0cIcbB", "(464) 146 6071", null, null, null, 2, "f" },
                    { 41, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Fletcher.Leffler@yahoo.com", "Aurelie", "Bahringer", "3JfliYLBpI", "(627) 982 6531", null, null, null, 2, "f" },
                    { 40, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Cecelia_Harvey95@yahoo.com", "Enrico", "Nolan", "sVy3rV2qO3", "(740) 800 9628", null, null, null, 2, "m" },
                    { 39, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Marilyne82@hotmail.com", "Ida", "Wilderman", "QKtvc3x5i6", "(858) 30 9590", null, null, null, 2, "f" },
                    { 38, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "Merle29@gmail.com", "Eleonore", "Stoltenberg", "3uTvTf7hoG", "(903) 362 897", null, null, null, 2, "f" },
                    { 37, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Derrick.Shanahan77@gmail.com", "Anna", "Kihn", "Jso0HYgTuM", "(170) 298 3397", null, null, null, 2, "m" },
                    { 36, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, "Eduardo_Flatley@gmail.com", "Enos", "Crist", "DoTdE52nH5", "(774) 225 8689", null, null, null, 2, "m" },
                    { 44, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Jamal_Beatty@yahoo.com", "Horacio", "Heaney", "6n_IgEWVVs", "(450) 247 5", null, null, null, 2, "f" },
                    { 35, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, "Kennedi.Kunze37@gmail.com", "Terrance", "Steuber", "uekvHpNQlG", "(35) 285 450", null, null, null, 2, "m" }
                });

            migrationBuilder.InsertData(
                table: "RECRUITERS",
                columns: new[] { "ID", "COMPANY_ID", "EMAIL", "FIRST_NAME", "LAST_NAME", "PASSWORD", "PHONE", "PHOTO_DATA", "PHOTO_MIMETYPE", "REFRESH_TOKEN", "ROLE_ID" },
                values: new object[,]
                {
                    { 18, 2, "Harold88@gmail.com", "Wilfredo", "Hintz", "8FdmSJAlfZ", "(972) 632 7052", null, null, null, 4 },
                    { 19, 3, "Arthur_Leannon76@yahoo.com", "Lacy", "Gaylord", "wsB49h6oWp", "(758) 148 2434", null, null, null, 4 },
                    { 14, 4, "Kaleb_Hartmann79@yahoo.com", "Luigi", "McCullough", "w86Pp44xVZ", "(64) 76 9938", null, null, null, 4 },
                    { 12, 6, "Corine.Wilderman36@hotmail.com", "Marcia", "Harvey", "a5K_h0tFVY", "(604) 988 6298", null, null, null, 4 },
                    { 15, 6, "Emilio96@yahoo.com", "Jeffry", "Koelpin", "PdfcHjK0n_", "(478) 684 6368", null, null, null, 4 },
                    { 13, 8, "Hilario.Quitzon@gmail.com", "Zack", "Labadie", "1POJVI4YLj", "(716) 106 9272", null, null, null, 4 },
                    { 16, 9, "Garrison.Hagenes85@yahoo.com", "Vicenta", "Weber", "xYLYazWLzO", "(451) 425 9247", null, null, null, 4 },
                    { 17, 9, "Derek_Bergnaum13@hotmail.com", "Casey", "Cremin", "Li_N1U9rxk", "(528) 629 8099", null, null, null, 4 },
                    { 20, 11111, "Marcelino3@yahoo.com", "Amina", "Casper", "UauCu2CiQ7", "(485) 670 4533", null, null, null, 4 },
                    { 21, 11111, "Aleen75@hotmail.com", "Kurtis", "Kreiger", "3vts_t3RCq", "(540) 770 7762", null, null, null, 4 },
                    { 11111, 11111, "recruiter@gmail.com", "Kate", "Janner", "CdMwWKQ0n40R4dK/zsjIx0XhXdgxXCcyJfbbuViFMJC2mVik", "0934561223", null, null, null, 4 }
                });

            migrationBuilder.InsertData(
                table: "RESUMES",
                columns: new[] { "ID", "COURSES", "CREATE_DATE", "FACEBOOK", "FAMILY_STATE", "GITHUB", "INSTAGRAM", "INTRODUCTION", "KEY_SKILLS", "LINKEDIN", "MOD_DATE", "POSITION", "SKYPE", "SOFT_SKILLS", "WORK_AREA_ID" },
                values: new object[,]
                {
                    { 43, "Ut cumque reiciendis unde voluptatem quasi mollitia.", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://wilson.name", "Occaecati.", "https://dangelo.com", "https://monica.biz", "Architecto sint.", "Aperiam ea.", "https://bill.info", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saepe.", "https://olga.com", "Reprehenderit rerum.", 9 },
                    { 46, "Certification training", new DateTime(2018, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "www.facebook.com", "not married", "https://www.github.com/", "https://www.instagram.com/", "Persuasive person with strong desire to work", "Hardworking, persuasive", "https://www.linkedin.com/", null, "Surgeon", "https://www.skype.com/", "Plastic surgery", 3 }
                });

            migrationBuilder.InsertData(
                table: "EDUCATION_PERIODS",
                columns: new[] { "ID", "FACULTY_ID", "FINISH_DATE", "RESUME_ID", "SCHOOL_ID", "START_DATE" },
                values: new object[,]
                {
                    { 61, 4, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 43, 10, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 111, 4, new DateTime(2005, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 46, 8, new DateTime(2002, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 112, 2, new DateTime(2007, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 46, 5, new DateTime(2004, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 70, 3, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 43, 4, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 68, 10, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 43, 7, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 67, 3, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 43, 8, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 69, 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 43, 8, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65, 9, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 43, 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, 4, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 43, 2, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, 10, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 43, 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, 5, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 43, 8, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 66, 9, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 43, 3, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "EXPERIENCES",
                columns: new[] { "ID", "COMPANY_NAME", "FINISH_DATE", "POSITION", "RESUME_ID", "START_DATE" },
                values: new object[,]
                {
                    { 57, "Electa Rowe", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delectus esse quia ea est reiciendis.", 43, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65, "Triomed", new DateTime(2016, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Surgeon", 46, new DateTime(2008, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 66, "Medis", new DateTime(2018, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Surgeon", 46, new DateTime(2016, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 67, "Synevo", new DateTime(2018, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Surgeon", 46, new DateTime(2018, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, "Lurline Rolfson", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Occaecati ut et sed.", 43, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, "Polly Steuber", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Qui ipsa velit ullam.", 43, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 54, "Ines Herzog", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Optio voluptatem atque perspiciatis reprehenderit aliquam nihil.", 43, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, "Roberto Mosciski", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Velit aut cumque sunt dolores.", 43, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, "Myriam Littel", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rerum ipsum illo unde minus aut vitae dolores.", 43, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, "Bettie Torphy", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Commodi voluptas nobis a incidunt quibusdam deserunt illum deserunt.", 43, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, "Patience Fisher", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Suscipit nostrum modi modi dicta aspernatur eveniet mollitia optio error.", 43, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, "Eldon Parker", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aut asperiores amet voluptatum minus sequi dolore et perspiciatis est.", 43, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, "Adrian Ullrich", new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Et laboriosam modi eaque eum.", 43, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "RESUME_LANGUAGES",
                columns: new[] { "ID", "LANGUAGE_ID", "RESUME_ID" },
                values: new object[,]
                {
                    { 113, 7, 46 },
                    { 112, 5, 46 },
                    { 111, 10, 46 },
                    { 82, 3, 43 },
                    { 77, 4, 43 },
                    { 80, 2, 43 },
                    { 79, 9, 43 },
                    { 78, 6, 43 },
                    { 76, 10, 43 },
                    { 75, 5, 43 },
                    { 74, 9, 43 },
                    { 73, 9, 43 },
                    { 81, 6, 43 }
                });

            migrationBuilder.InsertData(
                table: "VACANCIES",
                columns: new[] { "ID", "BE_PLUS", "CITY_ID", "CREATE_DATE", "DESCRIPTION", "FULL_PART_TIME", "IS_CHECKED", "MOD_DATE", "NAME", "OFFERING", "RECRUITER_ID", "REQUIREMENTS", "SALARY", "WORK_AREA_ID" },
                values: new object[,]
                {
                    { 29, "Repellat autem nulla.", 4, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Global", "Part-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Corporate Optimization Assistant", "Valentin Ortiz", 11111, "Illo deserunt et fugiat ea quibusdam culpa sed rerum eligendi.", 1000m, 1 },
                    { 23, "Delectus cum temporibus repellendus.", 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senior", "Part-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Investor Factors Consultant", "Esperanza Boehm", 21, "Quam voluptates quo.", 1000m, 5 },
                    { 30, "Qui et aliquam aut facilis a.", 5, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chief", "Part-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lead Marketing Specialist", "Merl Corkery", 13, "Mollitia placeat sunt eos iste nam aut tempore incidunt occaecati.", 1000m, 12 },
                    { 28, "Neque blanditiis eveniet libero.", 4, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Regional", "Full-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Legacy Integration Orchestrator", "Karine Lakin", 15, "Porro est dolorem voluptatem.", 1000m, 1 },
                    { 27, "Aperiam repudiandae eos porro a.", 4, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senior", "Part-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Regional Accounts Technician", "Lexi Zieme", 15, "Corporis aut voluptas ipsam accusamus eum est.", 1000m, 12 },
                    { 31, "Nemo voluptas natus.", 5, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Principal", "Full-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Direct Infrastructure Technician", "Kaya Huels", 14, "Deleniti provident velit vel maiores temporibus unde.", 1000m, 5 },
                    { 34, "In omnis molestiae fugiat quos.", 6, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dynamic", "Part-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Human Response Facilitator", "Arno Reilly", 12, "Autem quia explicabo fuga dolore reprehenderit autem impedit.", 1000m, 9 },
                    { 24, "Libero provident ab impedit earum deleniti.", 3, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Global", "Part-time", true, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "District Applications Associate", "Delfina Hayes", 12, "Labore est aperiam at ut corrupti enim.", 1000m, 2 },
                    { 26, "Omnis asperiores voluptates et dolorem voluptatem rerum sit dignissimos.", 1, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Human", "Part-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "International Directives Executive", "Eloise O'Reilly", 18, "Minus odit occaecati nemo ratione.", 1000m, 4 },
                    { 11111, "Experience with Angular JS. Experience in setting up CI / CD. English: intermediate or higher.", 5, new DateTime(2018, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Client: is a European company, one of the industry leaders in transport and traffic solutions. It develops innovative systems for parking automation, traffic lights navigation, public transport management and data streams for autonomous vehicles.If you want to take part in developing solutions which power the transport of the future — it’s a good project for you.", "Part-time", true, null, ".Net Developer", "Working in friendly successful team. Ability to grow in professional area.", 11111, "Minimal 3 year experience in .NET web/API development (preferably .NET core). Good knowledge of SQL(MySQL / PostgreSQL). Being capable to do some front-end tasks. ", 5000m, 1 },
                    { 25, "Et deleniti id soluta.", 11, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Customer", "Full-time", false, new DateTime(2017, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Regional Identity Executive", "Leif Daugherty", 15, "In placeat quia praesentium est sint.", 1000m, 10 },
                    { 11112, "Project Management Professional(PMP) / PRINCE II certification ", 5, new DateTime(2018, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Project Manager manages key client projects. Project management responsibilities include the coordination and completion of projects on time within budget and within scope.Prepare reports for upper management regarding status of project.", "Full-time", false, null, " Project Manager", "Working in friendly successful team. Ability to grow in professional area.", 11111, "Proven working experience in project management. Excellent client - facing and internal communication skill. Strong working knowledge of Microsoft Office.", 1000m, 1 }
                });

            migrationBuilder.InsertData(
                table: "FAVORITE_VACANCIES",
                columns: new[] { "ID", "EMPLOYEE_ID", "VACANCY_ID" },
                values: new object[,]
                {
                    { 91, 44, 31 },
                    { 94, 38, 11112 },
                    { 90, 37, 29 },
                    { 89, 39, 28 },
                    { 86, 42, 27 },
                    { 93, 41, 34 },
                    { 88, 46, 27 },
                    { 95, 39, 24 },
                    { 87, 44, 24 },
                    { 92, 43, 31 }
                });

            migrationBuilder.InsertData(
                table: "INVITATIONS",
                columns: new[] { "ID", "EMPLOYEE_ID", "VACANCY_ID" },
                values: new object[,]
                {
                    { 96, 37, 34 },
                    { 97, 44, 11112 },
                    { 102, 41, 27 },
                    { 98, 39, 23 },
                    { 105, 36, 23 },
                    { 99, 35, 31 },
                    { 101, 43, 11111 },
                    { 104, 37, 11111 },
                    { 103, 35, 24 },
                    { 100, 38, 11112 }
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
