using System.Collections.Generic;

namespace ProductsAndCategories
{
    public class CategoryPage
    {
        // ====================== Models for Info Rendering
        public Category Category { get; set; }
        public List<Product> Products { get; set; }

        // ====================== Model for form
        public Tag Tag { get; set; }
    }
}