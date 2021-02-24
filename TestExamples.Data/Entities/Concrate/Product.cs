using System;
using System.ComponentModel.DataAnnotations.Schema;
using TestExamples.Data.Entities.Abstract;

namespace TestExamples.Data.Entities.Concrate
{
    public class Product : BaseEntity
    {
        public String Name { get; set; }
        public String Descrption { get; set; }
        public String Barcode { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal StockAmount { get; set; }
        public decimal PurchasePrice { get; set; }

        [ForeignKey("Unit")]
        public int UnitId { get; set; }
        public virtual Unit Unit { get; set; }

        [ForeignKey("ProductCategory")]
        public int ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
