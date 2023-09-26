using System.ComponentModel.DataAnnotations;

namespace Solares.Models
{
    public class OurServiceItem
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string TitleDe { get; set; }
        [Required]
        public string DescriptionDe { get; set; }
        public string TypeIcon { get; set; }
    }
}
