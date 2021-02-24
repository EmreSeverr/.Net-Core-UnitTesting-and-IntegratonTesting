using System;
using System.Collections.Generic;
using System.Text;

namespace TestExamples.Data.Entities.Abstract
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        DateTime InsertedDate { get; set; }
    }
}
