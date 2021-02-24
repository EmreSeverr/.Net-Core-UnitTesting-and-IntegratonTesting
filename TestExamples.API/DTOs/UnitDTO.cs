using System;
using System.Collections.Generic;

namespace TestExamples.API.DTOs
{
    public class UnitDTO
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public virtual List<ProductDTO> Products { get; set; }
    }
}
