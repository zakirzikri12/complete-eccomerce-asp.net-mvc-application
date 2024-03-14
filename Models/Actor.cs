using System.ComponentModel.DataAnnotations;

namespace eTikects.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }

        public string? ProfilePictureURL { get; set; }
        public string? Fullname { get; set; }
        public string? Bio { get; set; }

        public List<Actor_Movie>? Actor_Movies { get; set; }
    }
}
