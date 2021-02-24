using System;
using System.Collections.Generic;
using TestExamples.Data.Entities.Abstract;

namespace TestExamples.Data.Entities.Concrate
{
    public class ProductCategory : BaseEntity
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
