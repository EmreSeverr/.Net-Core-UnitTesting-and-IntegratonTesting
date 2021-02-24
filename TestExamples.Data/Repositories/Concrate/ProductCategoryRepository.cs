using TestExamples.Data.Entities.Concrate;
using TestExamples.Data.Repositories.Abstract;

namespace TestExamples.Data.Repositories.Concrate
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(TestExampleContext testExampleContext) : base(testExampleContext)
        {
        }
    }
}
