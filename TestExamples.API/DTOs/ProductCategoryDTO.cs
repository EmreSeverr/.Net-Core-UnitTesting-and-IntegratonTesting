using System;
using System.Collections.Generic;

namespace TestExamples.API.DTOs
{
    public class ProductCategoryDTO
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public virtual List<ProductDTO> Products { get; set; }
    }
}
