using System.Collections.Generic;

namespace ProductsAndCategories
{
    public class ProductPage
    {
        // ====================== Models to render info
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }

        // ====================== Model for form
        public Tag Tag { get; set; }
    }
}