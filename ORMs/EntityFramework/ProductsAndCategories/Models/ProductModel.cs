using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProductsAndCategories
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [MinLength(3, ErrorMessage ="Min Length 3 Chars")]
        public string Name { get; set; }

        [Required]
        [MinLength(10, ErrorMessage ="Min Length 10 Chars")]
        public string Description { get; set; }
        
        [Required]
        [Display(Name = "Price $")]
        [Range(0.01, 100000.00, ErrorMessage ="Value must be greater than $0.00")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<Tag> AllCategories { get; set; }
    }
}