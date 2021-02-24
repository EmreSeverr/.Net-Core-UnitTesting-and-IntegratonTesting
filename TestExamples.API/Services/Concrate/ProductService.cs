using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestExamples.API.DTOs;
using TestExamples.API.Services.Abstract;
using TestExamples.Data.Entities.Concrate;
using TestExamples.Data.Repositories.Abstract;
using TestExamples.Exceptions;

namespace TestExamples.API.Services.Concrate
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddProductAsync(ProductDTO productDTO)
        {
            if (productDTO == null) throw new TestExamplesException("Eklenecek ürün boş olamaz.");

            var product = new Product
            {
                Barcode = productDTO.Barcode,
                Descrption = productDTO.Descrption,
                Name = productDTO.Name,
                ProductCategoryId = productDTO.ProductCategoryId,
                PurchasePrice = productDTO.PurchasePrice,
                UnitId = productDTO.UnitId,
                UnitPrice = productDTO.UnitPrice,
                InsertedDate = DateTime.Now,
                StockAmount = productDTO.StockAmount
            };

            await _productRepository.AddAsync(product).ConfigureAwait(false);
        }

        public async Task DeleteByIdProductAsync(int id)
        {
            if (id <= 0) throw new TestExamplesException("Id 0 dan kucuk olamaz.");

            await _productRepository.DeleteByIdAsync(id).ConfigureAwait(false);
        }

        public async Task<List<ProductDTO>> GetAllProductAsync()
        {
            var products = await _productRepository.GetAllAsync().ConfigureAwait(false);

            var productDTOs = products != null ?
                              (from p in products
                               select new ProductDTO
                               {
                                   Barcode = p.Barcode,
                                   Descrption = p.Descrption,
                                   Name = p.Name,
                                   ProductCategoryId = p.ProductCategoryId,
                                   PurchasePrice = p.PurchasePrice,
                                   UnitId = p.UnitId,
                                   UnitPrice = p.UnitPrice,
                                   StockAmount = p.StockAmount,
                                   Id = p.Id
                               }).ToList() : null;

            return productDTOs;
        }

        public async Task<ProductDTO> GetByIdProductAsync(int id)
        {
            if (id <= 0) throw new TestExamplesException("Id 0 dan kucuk olamaz.");

            var product = await _productRepository.GetByIdAsync(id).ConfigureAwait(false);

            if (product == null) throw new TestExamplesException("Aranan veri bulunaamıştır.");

            var productDTO = new ProductDTO
            {
                Barcode = product.Barcode,
                Descrption = product.Descrption,
                Name = product.Name,
                ProductCategoryId = product.ProductCategoryId,
                PurchasePrice = product.PurchasePrice,
                UnitId = product.UnitId,
                UnitPrice = product.UnitPrice,
                StockAmount = product.StockAmount,
                Id = product.Id
            };

            return productDTO;
        }

        public async Task UpdateProductAsync(ProductDTO productDTO)
        {
            var updatedProduct = await _productRepository.GetByIdAsync(productDTO.Id).ConfigureAwait(false);

            if (updatedProduct == null) throw new TestExamplesException("Güncellenecek veri bulunamamıştır.");

            var product = new Product
            {
                Barcode = productDTO.Barcode,
                Descrption = productDTO.Descrption,
                Name = productDTO.Name,
                ProductCategoryId = productDTO.ProductCategoryId,
                PurchasePrice = productDTO.PurchasePrice,
                UnitId = productDTO.UnitId,
                UnitPrice = productDTO.UnitPrice,
                StockAmount = productDTO.StockAmount,
                Id = productDTO.Id
            };

            await _productRepository.Update(product).ConfigureAwait(false);
        }
    }
}
