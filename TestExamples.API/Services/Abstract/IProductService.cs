using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestExamples.API.DTOs;

namespace TestExamples.API.Services.Abstract
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAllProductAsync();
        Task<ProductDTO> GetByIdProductAsync(int id);
        Task AddProductAsync(ProductDTO productDTO);
        Task UpdateProductAsync(ProductDTO productDTO);
        Task DeleteByIdProductAsync(int id);
    }
}
