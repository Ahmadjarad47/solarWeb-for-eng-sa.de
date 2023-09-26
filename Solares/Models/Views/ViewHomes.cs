using Solares.Data;

namespace Solares.Models.Views
{
    public class ViewHomes
    {
        public virtual IEnumerable<Home> Homes { get; set; }
        public virtual IEnumerable<Service> services { get; set; }
        public virtual IEnumerable<ServiceTitle> serviceTitles { get; set; }
        public virtual Localization localization { get; set; }
        public virtual IEnumerable<WhyUs> whyUs { get; set; }
        public virtual IEnumerable<WhyUsDesc> whyUsDes { get; set; }
        public virtual IEnumerable<OurServiceItem> OurServiceItems { get; set; }

        public virtual IEnumerable<OurServiceTitle>OurServiceTitles { get; set; }
    }
}
