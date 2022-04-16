using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProductsAndCategories
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MinLength(3, ErrorMessage ="Min Length 3 Chars")]
        public string Name { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<Tag> AllProducts { get; set; }
    }
}