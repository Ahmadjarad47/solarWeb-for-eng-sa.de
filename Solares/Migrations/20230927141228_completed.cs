using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Solares.Migrations
{
    /// <inheritdoc />
    public partial class completed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cookie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cookie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataShoot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataShoot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeSendEmail = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Home",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Home", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IMP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMP", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Localization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OurServiceItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeIcon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurServiceItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OurServiceTitle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurServiceTitle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeIcon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdModal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionDe = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTitle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionDe = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTitle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WhyUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhyUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WhyUsDesc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeIcon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhyUsDesc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DataShoot",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Als Diensteanbieter sind wir gemäß § 7 Abs.1 TMG für eigene Inhalte auf diesen Seiten nach den\r\nallgemeinen Gesetzen verantwortlich. Nach §§ 8 bis 10 TMG sind wir als Diensteanbieter jedoch nicht\r\nverpflichtet, übermittelte oder gespeicherte fremde Informationen zu überwachen oder nach\r\nUmständen zu forschen, die auf eine rechtswidrige Tätigkeit hinweisen.\r\nVerpflichtungen zur Entfernung oder Sperrung der Nutzung von Informationen nach den allgemeinen\r\nGesetzen bleiben hiervon unberührt. Eine diesbezügliche Haftung ist jedoch erst ab dem Zeitpunkt\r\nder Kenntnis einer konkreten Rechtsverletzung möglich. Bei Bekanntwerden von entsprechenden.\r\nRechtsverletzungen werden wir diese Inhalte umgehend entfernen.", "Haftung für Inhalte" },
                    { 2, "Unser Angebot enthält Links zu externen Webseiten Dritter, auf deren Inhalte wir keinen Einfluss\r\nhaben. Deshalb können wir für diese fremden Inhalte auch keine Gewähr übernehmen. Für die\r\nInhalte der verlinkten Seiten ist stets der jeweilige Anbieter oder Betreiber der Seiten verantwortlich.\r\nDie verlinkten Seiten wurden zum Zeitpunkt der Verlinkung auf mögliche Rechtsverstöße überprüft.\r\nRechtswidrige Inhalte waren zum Zeitpunkt der Verlinkung nicht erkennbar. Eine permanente\r\ninhaltliche Kontrolle der verlinkten Seiten ist jedoch ohne konkrete Anhaltspunkte einer\r\nRechtsverletzung nicht zumutbar. Bei Bekanntwerden von Rechtsverletzungen werden wir derartige\r\nLinks umgehend entfernen.", "Haftung für Links" },
                    { 3, "Die durch die Seitenbetreiber erstellten Inhalte und Werke auf diesen Seiten unterliegen dem\r\ndeutschen Urheberrecht. Die Vervielfältigung, Bearbeitung, Verbreitung und jede Art der Verwertung\r\naußerhalb der Grenzen des Urheberrechtes bedürfen der schriftlichen Zustimmung des jeweiligen\r\nAutors bzw. Erstellers. Downloads und Kopien dieser Seite sind nur für den privaten, nicht\r\nkommerziellen Gebrauch gestattet.\r\nSoweit die Inhalte auf dieser Seite nicht vom Betreiber erstellt wurden, werden die Urheberrechte\r\nDritter beachtet. Insbesondere werden Inhalte Dritter als solche gekennzeichnet. Sollten Sie\r\ntrotzdem auf eine Urheberrechtsverletzung aufmerksam werden, bitten wir um einen\r\nentsprechenden Hinweis. Bei Bekanntwerden von Rechtsverletzungen werden wir derartige Inhalte\r\numgehend entfernen.\r\n\r\n\r\n\r\n Quelle: https://www.e-recht24.de/impressum-generator.html", "Urheberrecht" },
                    { 4, "Der Betreiber dieser Seiten nimmt den Schutz Ihrer persönlichen Daten sehr ernst. Wir behandeln\r\nIhre personenbezogenen Daten vertraulich und entsprechend der gesetzlichen\r\nDatenschutzvorschriften sowie dieser Datenschutzerklärung          \r\n\r\n\r\n    Die Nutzung unserer Webseite ist in der Regel ohne Angabe personenbezogener Daten möglich.\r\nSoweit auf unseren Seiten personenbezogene Daten (beispielsweise Name, Anschrift oder E-MailAdressen) erhoben werden, erfolgt dies, soweit möglich, stets auf freiwilliger Basis. Diese Daten\r\nwerden ohne Ihre ausdrückliche Zustimmung nicht an Dritte weitergegeben.\r\nWir weisen darauf hin, dass die Datenübertragung im Internet (z.B. bei der Kommunikation per EMail) Sicherheitslücken aufweisen kann. Ein lückenloser Schutz der Daten vor dem Zugriff durch\r\nDritte ist nicht möglich.", "DATENSCHUTZERKLÄRUNG" },
                    { 5, "Der Nutzung von im Rahmen der Impressumspflicht veröffentlichten Kontaktdaten zur Übersendung\r\nvon nicht ausdrücklich angeforderter Werbung und Informationsmaterialien wird hiermit\r\nwidersprochen. Die Betreiber der Seiten behalten sich ausdrücklich rechtliche Schritte im Falle der\r\nunverlangten Zusendung von Werbeinformationen, etwa durch Spam-E-Mails, vor.", "WIDERSPRUCH WERBE-MAILS" },
                    { 6, "Sie haben jederzeit das Recht auf unentgeltliche Auskunft über Ihre gespeicherten\r\npersonenbezogenen Daten, deren Herkunft und Empfänger und den Zweck der Datenverarbeitung\r\nsowie ein Recht auf Berichtigung, Sperrung oder Löschung dieser Daten. Hierzu sowie zu weiteren\r\nFragen zum Thema personenbezogene Daten können Sie sich jederzeit unter der im Impressum\r\nangegebenen Adresse an uns wenden.", "AUSKUNFT, LÖSCHUNG, SPERRUNG" },
                    { 7, "Die Internetseiten verwenden teilweise so genannte Cookies. Cookies richten auf Ihrem Rechner\r\nkeinen Schaden an und enthalten keine Viren. Cookies dienen dazu, unser Angebot\r\nnutzerfreundlicher, effektiver und sicherer zu machen. Cookies sind kleine Textdateien, die auf Ihrem\r\nRechner abgelegt werden und die Ihr Browser speichert.\r\nDie meisten der von uns verwendeten Cookies sind so genannte „Session-Cookies“. Sie werden nach\r\nEnde Ihres Besuchs automatisch gelöscht. Andere Cookies bleiben auf Ihrem Endgerät gespeichert,\r\nbis Sie diese löschen. Diese Cookies ermöglichen es uns, Ihren Browser beim nächsten Besuch\r\nwiederzuerkennen.\r\nSie können Ihren Browser so einstellen, dass Sie über das Setzen von Cookies informiert werden und\r\nCookies nur im Einzelfall erlauben, die Annahme von Cookies für bestimmte Fälle oder generell\r\nausschließen sowie das automatische Löschen der Cookies beim Schließen des Browsers aktivieren.\r\nBei der Deaktivierung von Cookies kann die Funktionalität dieser Website eingeschränkt sein.", "COOKIES" },
                    { 8, "Der Provider der Seiten erhebt und speichert automatisch Informationen in so genannten Server-Log\r\nFiles, die Ihr Browser automatisch an uns übermittelt. Dies sind:\r\n    - Browsertyp/ Browserversion\r\n    - verwendetes Betriebssystem\r\n    - Referrer URL\r\n    - Hostname des zugreifenden Rechners\r\n    - Uhrzeit der Serveranfrage\r\n\r\nDiese Daten sind nicht bestimmten Personen zuordenbar. Eine Zusammenführung dieser Daten mit\r\nanderen Datenquellen wird nicht vorgenommen. Wir behalten uns vor, diese Daten nachträglich zu\r\nprüfen, wenn uns konkrete Anhaltspunkte für eine rechtswidrige Nutzung bekannt werden.", "SERVER-LOG-FILES" },
                    { 9, "Wenn Sie uns per Informationen über E-Mail via der Kontaktaufnahmefunktion zukommen lassen,\r\nwerden Ihre Angaben aus dem Anfrageformular inklusive der von Ihnen dort angegebenen\r\nKontaktdaten zwecks Bearbeitung der Anfrage und für den Fall von Anschlussfragen bei uns\r\ngespeichert. Diese Daten geben wir nicht ohne Ihre Einwilligung weiter.", "KONTAKTAUFNAHME" },
                    { 10, "Herrn M.Sc. Marcus Schmidt, Geschäftsführer\r\n\r\nHerrn M.Sc. Omar Almatar Aljarad, Geschäftsführer", "Geschäftsführung" }
                });

            migrationBuilder.InsertData(
                table: "IMP",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Ingenieurbüro Schmidt & Aljarad\r\nSoldier Str 32\r\nD-13359 Berlin", "Adresse" },
                    { 2, "Herr Marcus Schmidt\r\nHerr Omar Almatar Aljarad", "Vertreten durch:" },
                    { 3, "Herr Marcus Schmidt\r\nE-Mail: m.schmidt@eng-sa.de\r\nHandynummer: +49 1577 3606583\r\n\r\nHerr Omar Almatar Aljarad\r\nE-Mail: o.aljarad@eng-sa.de\r\nHandynummer:  +49 177 1413741\r\n\r\nEmail für :\r\n1. allgemeine Anfragen: info@eng-sa.de\r\n2. Medienvertretende: presse@eng-sa.de\r\n3. Rechnung: invoice@eng-sa.de", "Kontaktdaten" },
                    { 4, "23/513/00364", "Steuernummer\r\n" }
                });

            migrationBuilder.InsertData(
                table: "Localization",
                columns: new[] { "Id", "active" },
                values: new object[] { 1, true });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Cookie");

            migrationBuilder.DropTable(
                name: "DataShoot");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "Home");

            migrationBuilder.DropTable(
                name: "IMP");

            migrationBuilder.DropTable(
                name: "Localization");

            migrationBuilder.DropTable(
                name: "OurServiceItem");

            migrationBuilder.DropTable(
                name: "OurServiceTitle");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "ServiceTitle");

            migrationBuilder.DropTable(
                name: "WhyUs");

            migrationBuilder.DropTable(
                name: "WhyUsDesc");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
