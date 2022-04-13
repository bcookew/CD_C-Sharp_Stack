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
        public string FirstName { get; set; }
        
        [Required]
        [MinLength(3, ErrorMessage = "Min 3 Chars")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public List<Dish> CreatedDishes {get;set;}
    }
}