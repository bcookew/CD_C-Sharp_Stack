using System;
using System.ComponentModel.DataAnnotations;
namespace ChefsNDishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }
        
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        
        [Required]
        [Range(1,5)]
        public int Tastiness { get; set; }
        
        [Required]
        [Range(1,5000, ErrorMessage ="Must be in range: 1-5000")]
        public int Calories { get; set; }
        
        [Required]
        [MinLength(5, ErrorMessage = "Minimum 5 chars")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Chef")]
        public int? ChefId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public Chef Creator { get; set; }
    }
}