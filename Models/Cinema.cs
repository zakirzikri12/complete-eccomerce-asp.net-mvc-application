﻿using eTikects.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTikects.Models
{
    public class Cinema :IEntityBase
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "required")]
        [Display(Name = "Cinema Logo")]
        public string? Logo { get; set; }


        [Required(ErrorMessage = "required")]
        [Display(Name = "Cinema Name")]
        public string? Name { get; set; }


        [Required(ErrorMessage = "required")]
        [Display(Name = "Cinema Description")]
        public string? Description { get; set; }
    }
}
