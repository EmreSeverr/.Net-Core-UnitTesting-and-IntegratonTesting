using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestExamples.API.DTOs;
using TestExamples.API.Services.Abstract;
using TestExamples.Data.Repositories.Abstract;

namespace TestExamples.API.Services.Concrate
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public Task AddProductCategoryAsync(ProductCategoryDTO productCategoryDTO)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdProductCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductCategoryDTO>> GetAllProductCategoryAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductCategoryDTO> GetByIdProductCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductCategoryAsync(ProductCategoryDTO productCategoryDTO)
        {
            throw new NotImplementedException();
        }
    }
}
