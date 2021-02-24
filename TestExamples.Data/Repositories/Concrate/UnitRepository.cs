using TestExamples.Data.Entities.Concrate;
using TestExamples.Data.Repositories.Abstract;

namespace TestExamples.Data.Repositories.Concrate
{
    public class UnitRepository : BaseRepository<Unit>, IUnitRepository
    {
        public UnitRepository(TestExampleContext testExampleContext) : base(testExampleContext)
        {
        }
    }
}
