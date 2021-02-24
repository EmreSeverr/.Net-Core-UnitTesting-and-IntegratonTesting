using System;

namespace TestExamples.API.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Descrption { get; set; }
        public String Barcode { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal StockAmount { get; set; }
        public decimal PurchasePrice { get; set; }
        public int UnitId { get; set; }
        public UnitDTO Unit { get; set; }
        public int ProductCategoryId { get; set; }
        public ProductCategoryDTO ProductCategory { get; set; }
    }
}
