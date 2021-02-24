using System;
using System.ComponentModel.DataAnnotations;

namespace TestExamples.Data.Entities.Abstract
{
    public class BaseEntity : IBaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime InsertedDate { get; set; }
    }
}
