﻿using System.ComponentModel.DataAnnotations;

namespace eTikects.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture")]
        public string? ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        public string? Fullname { get; set; }

        [Display(Name = "Biography")]
        public string? Bio { get; set; }

        public List<Actor_Movie>? Actor_Movies { get; set; }
    }
}
