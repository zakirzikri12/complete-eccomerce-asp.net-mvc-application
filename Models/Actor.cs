using eTikects.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTikects.Models
{
    public class Actor :IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string? ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name Picture is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 2 and 50 characters")]

        public string? Fullname { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")]
        public string? Bio { get; set; }

        public List<Actor_Movie>? Actor_Movies { get; set; }
    }
}
