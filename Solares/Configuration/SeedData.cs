using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solares.Models;

namespace Solares.Configuration
{
    public class SeedData : IEntityTypeConfiguration<DataShoot>
    {
        public void Configure(EntityTypeBuilder<DataShoot> builder)
        {
            builder.HasData(new DataShoot
            {
                Title = "Haftung für Inhalte",
                Description = "Als Diensteanbieter sind wir gemäß § 7 Abs.1 TMG für eigene Inhalte auf diesen Seiten nach den\r\nallgemeinen Gesetzen verantwortlich. Nach §§ 8 bis 10 TMG sind wir als Diensteanbieter jedoch nicht\r\nverpflichtet, übermittelte oder gespeicherte fremde Informationen zu überwachen oder nach\r\nUmständen zu forschen, die auf eine rechtswidrige Tätigkeit hinweisen.\r\nVerpflichtungen zur Entfernung oder Sperrung der Nutzung von Informationen nach den allgemeinen\r\nGesetzen bleiben hiervon unberührt. Eine diesbezügliche Haftung ist jedoch erst ab dem Zeitpunkt\r\nder Kenntnis einer konkreten Rechtsverletzung möglich. Bei Bekanntwerden von entsprechenden.\r\nRechtsverletzungen werden wir diese Inhalte umgehend entfernen.",
                Id = 1,
            },new DataShoot
            {
                Title= "Haftung für Links",
                Id= 2,
                Description= "Unser Angebot enthält Links zu externen Webseiten Dritter, auf deren Inhalte wir keinen Einfluss\r\nhaben. Deshalb können wir für diese fremden Inhalte auch keine Gewähr übernehmen. Für die\r\nInhalte der verlinkten Seiten ist stets der jeweilige Anbieter oder Betreiber der Seiten verantwortlich.\r\nDie verlinkten Seiten wurden zum Zeitpunkt der Verlinkung auf mögliche Rechtsverstöße überprüft.\r\nRechtswidrige Inhalte waren zum Zeitpunkt der Verlinkung nicht erkennbar. Eine permanente\r\ninhaltliche Kontrolle der verlinkten Seiten ist jedoch ohne konkrete Anhaltspunkte einer\r\nRechtsverletzung nicht zumutbar. Bei Bekanntwerden von Rechtsverletzungen werden wir derartige\r\nLinks umgehend entfernen.",

            },new DataShoot
            {
                Title= "Urheberrecht",
                Description= "Die durch die Seitenbetreiber erstellten Inhalte und Werke auf diesen Seiten unterliegen dem\r\ndeutschen Urheberrecht. Die Vervielfältigung, Bearbeitung, Verbreitung und jede Art der Verwertung\r\naußerhalb der Grenzen des Urheberrechtes bedürfen der schriftlichen Zustimmung des jeweiligen\r\nAutors bzw. Erstellers. Downloads und Kopien dieser Seite sind nur für den privaten, nicht\r\nkommerziellen Gebrauch gestattet.\r\nSoweit die Inhalte auf dieser Seite nicht vom Betreiber erstellt wurden, werden die Urheberrechte\r\nDritter beachtet. Insbesondere werden Inhalte Dritter als solche gekennzeichnet. Sollten Sie\r\ntrotzdem auf eine Urheberrechtsverletzung aufmerksam werden, bitten wir um einen\r\nentsprechenden Hinweis. Bei Bekanntwerden von Rechtsverletzungen werden wir derartige Inhalte\r\numgehend entfernen.\r\n\r\n\r\n\r\n Quelle: https://www.e-recht24.de/impressum-generator.html"
                ,Id= 3,
            },new DataShoot
            {
                Title= "DATENSCHUTZERKLÄRUNG",
                Description= "Der Betreiber dieser Seiten nimmt den Schutz Ihrer persönlichen Daten sehr ernst. Wir behandeln\r\nIhre personenbezogenen Daten vertraulich und entsprechend der gesetzlichen\r\nDatenschutzvorschriften sowie dieser Datenschutzerklärung          \r\n\r\n\r\n    Die Nutzung unserer Webseite ist in der Regel ohne Angabe personenbezogener Daten möglich.\r\nSoweit auf unseren Seiten personenbezogene Daten (beispielsweise Name, Anschrift oder E-MailAdressen) erhoben werden, erfolgt dies, soweit möglich, stets auf freiwilliger Basis. Diese Daten\r\nwerden ohne Ihre ausdrückliche Zustimmung nicht an Dritte weitergegeben.\r\nWir weisen darauf hin, dass die Datenübertragung im Internet (z.B. bei der Kommunikation per EMail) Sicherheitslücken aufweisen kann. Ein lückenloser Schutz der Daten vor dem Zugriff durch\r\nDritte ist nicht möglich.",
                Id= 4,
            },new DataShoot
            {
                Id= 5,
                Title= "WIDERSPRUCH WERBE-MAILS",
                Description= "Der Nutzung von im Rahmen der Impressumspflicht veröffentlichten Kontaktdaten zur Übersendung\r\nvon nicht ausdrücklich angeforderter Werbung und Informationsmaterialien wird hiermit\r\nwidersprochen. Die Betreiber der Seiten behalten sich ausdrücklich rechtliche Schritte im Falle der\r\nunverlangten Zusendung von Werbeinformationen, etwa durch Spam-E-Mails, vor.",

            },new DataShoot
            {
                Title= "AUSKUNFT, LÖSCHUNG, SPERRUNG",
                Id=6,
                Description= "Sie haben jederzeit das Recht auf unentgeltliche Auskunft über Ihre gespeicherten\r\npersonenbezogenen Daten, deren Herkunft und Empfänger und den Zweck der Datenverarbeitung\r\nsowie ein Recht auf Berichtigung, Sperrung oder Löschung dieser Daten. Hierzu sowie zu weiteren\r\nFragen zum Thema personenbezogene Daten können Sie sich jederzeit unter der im Impressum\r\nangegebenen Adresse an uns wenden."
            },new DataShoot
            {
                Title= "COOKIES",
                Description= "Die Internetseiten verwenden teilweise so genannte Cookies. Cookies richten auf Ihrem Rechner\r\nkeinen Schaden an und enthalten keine Viren. Cookies dienen dazu, unser Angebot\r\nnutzerfreundlicher, effektiver und sicherer zu machen. Cookies sind kleine Textdateien, die auf Ihrem\r\nRechner abgelegt werden und die Ihr Browser speichert.\r\nDie meisten der von uns verwendeten Cookies sind so genannte „Session-Cookies“. Sie werden nach\r\nEnde Ihres Besuchs automatisch gelöscht. Andere Cookies bleiben auf Ihrem Endgerät gespeichert,\r\nbis Sie diese löschen. Diese Cookies ermöglichen es uns, Ihren Browser beim nächsten Besuch\r\nwiederzuerkennen.\r\nSie können Ihren Browser so einstellen, dass Sie über das Setzen von Cookies informiert werden und\r\nCookies nur im Einzelfall erlauben, die Annahme von Cookies für bestimmte Fälle oder generell\r\nausschließen sowie das automatische Löschen der Cookies beim Schließen des Browsers aktivieren.\r\nBei der Deaktivierung von Cookies kann die Funktionalität dieser Website eingeschränkt sein.",
                Id= 7,
            },new DataShoot
            {
                Title= "SERVER-LOG-FILES",
                Description= "Der Provider der Seiten erhebt und speichert automatisch Informationen in so genannten Server-Log\r\nFiles, die Ihr Browser automatisch an uns übermittelt. Dies sind:\r\n    - Browsertyp/ Browserversion\r\n    - verwendetes Betriebssystem\r\n    - Referrer URL\r\n    - Hostname des zugreifenden Rechners\r\n    - Uhrzeit der Serveranfrage\r\n\r\nDiese Daten sind nicht bestimmten Personen zuordenbar. Eine Zusammenführung dieser Daten mit\r\nanderen Datenquellen wird nicht vorgenommen. Wir behalten uns vor, diese Daten nachträglich zu\r\nprüfen, wenn uns konkrete Anhaltspunkte für eine rechtswidrige Nutzung bekannt werden.",
                Id= 8,
            },new DataShoot
            {
                Title= "KONTAKTAUFNAHME",
                Description= "Wenn Sie uns per Informationen über E-Mail via der Kontaktaufnahmefunktion zukommen lassen,\r\nwerden Ihre Angaben aus dem Anfrageformular inklusive der von Ihnen dort angegebenen\r\nKontaktdaten zwecks Bearbeitung der Anfrage und für den Fall von Anschlussfragen bei uns\r\ngespeichert. Diese Daten geben wir nicht ohne Ihre Einwilligung weiter.",
                Id= 9,
            }, new DataShoot
            {
                Title= "Geschäftsführung",
                Description= "Herrn M.Sc. Marcus Schmidt, Geschäftsführer\r\n\r\nHerrn M.Sc. Omar Almatar Aljarad, Geschäftsführer",
                Id=10,
            });
        }
    }
}
