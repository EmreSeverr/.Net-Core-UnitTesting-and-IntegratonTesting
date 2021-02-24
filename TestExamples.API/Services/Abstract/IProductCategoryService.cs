using System.Collections.Generic;
using System.Threading.Tasks;
using TestExamples.API.DTOs;

namespace TestExamples.API.Services.Abstract
{
    public interface IProductCategoryService
    {
        Task<List<ProductCategoryDTO>> GetAllProductCategoryAsync();
        Task<ProductCategoryDTO> GetByIdProductCategoryAsync(int id);
        Task AddProductCategoryAsync(ProductCategoryDTO productCategoryDTO);
        Task UpdateProductCategoryAsync(ProductCategoryDTO productCategoryDTO);
        Task DeleteByIdProductCategory(int id);
    }
}
