using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ProductsAndCategories
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        [Required]
        [Display(Name ="Product")]
        [Range(1, int.MaxValue, ErrorMessage ="You must Select a product")]
        public int ProductId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage ="You must Select a category")]
        [Display(Name ="Category")]
        public int CategoryId { get; set; }
        public Product Product { get; set; }
        public Category Category { get; set; }
    }
}