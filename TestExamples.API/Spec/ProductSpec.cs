using System;
using System.Collections.Generic;
using System.Linq;
using TestExamples.Data.Entities.Concrate;
using TestExamples.Exceptions;

namespace TestExamples.API.Spec
{
    public class ProductSpec
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public String Barcode { get; set; }
        public int? UnitId { get; set; }
        public int? ProductCategoryId { get; set; }
        public decimal? LowUnitPrice { get; set; }
        public decimal? TopUnitPrice { get; set; }

        public List<Product> GetfilteredProducts(List<Product> products)
        {
            if (products == null) throw new TestExamplesException("filtrelenecek ürünler boş olamaz");

            var filteredProducts = new List<Product>();

            if (!string.IsNullOrEmpty(Name)) filteredProducts.AddRange(products.Where(p => p.Name.Contains(Name)));
            if (!string.IsNullOrEmpty(Description)) filteredProducts.AddRange(products.Where(p => p.Descrption.Contains(Description)));
            if (!string.IsNullOrEmpty(Barcode)) filteredProducts.AddRange(products.Where(p => p.Barcode.Contains(Barcode)));
            if (UnitId.HasValue) filteredProducts.AddRange(products.Where(p => p.UnitId == UnitId));
            if (ProductCategoryId.HasValue) filteredProducts.AddRange(products.Where(p => p.ProductCategoryId == ProductCategoryId));
            if (LowUnitPrice.HasValue && TopUnitPrice.HasValue) filteredProducts.AddRange(products.Where(p => p.UnitPrice > LowUnitPrice && p.UnitPrice < TopUnitPrice));

            return filteredProducts;
        }
    }
}
