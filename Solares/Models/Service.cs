using System.ComponentModel.DataAnnotations;

namespace Solares.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string TypeIcon { get; set; }
        public string IdModal { get; set; }
        
        public string TitleDe { get; set; }
        
        public string DescriptionDe { get; set; }
    }
}
