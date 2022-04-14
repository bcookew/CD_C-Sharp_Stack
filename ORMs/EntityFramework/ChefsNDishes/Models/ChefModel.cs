using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ChefsNDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId { get; set; }
        
        [Required]
        [MinLength(3, ErrorMessage = "Min 3 Chars")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        
        [Required]
        [MinLength(3, ErrorMessage = "Min 3 Chars")]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Date of Birth")]
        [AgeRequirement(ErrorMessage = "Must be 18 Years of age")]
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public List<Dish> CreatedDishes {get;set;}
    }
    public class AgeRequirement : ValidationAttribute
    {
        public override bool IsValid(object InputDate)
        {
            DateTime date = (DateTime)InputDate;
            return (DateTime.Now.Subtract(date).Days/365) > 18;
        }
    }
}