using eTikects.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTikects.Models
{
    public class Producer : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "required")]
        [Display(Name = "Profile Picture")]
        public string? ProfilePictureURL { get; set; }

        [Required(ErrorMessage = "required")]
        [Display(Name = "Full Name")]
        public string? Fullname { get; set; }

        [Required(ErrorMessage = "required")]
        [Display(Name = "Biography")]
        public string? Bio { get; set; }

        //Relationships
        public List<Movie>? Movies { get; set; }
    }
}
