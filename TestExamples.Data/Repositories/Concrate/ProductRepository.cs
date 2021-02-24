using TestExamples.Data.Entities.Concrate;
using TestExamples.Data.Repositories.Abstract;

namespace TestExamples.Data.Repositories.Concrate
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(TestExampleContext testExampleContext) : base(testExampleContext)
        {

        }
    }
}
