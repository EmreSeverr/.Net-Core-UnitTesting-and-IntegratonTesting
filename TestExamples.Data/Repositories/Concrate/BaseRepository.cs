using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestExamples.Data.Entities.Abstract;
using TestExamples.Data.Repositories.Abstract;
using TestExamples.Exceptions;

namespace TestExamples.Data.Repositories.Concrate
{
    public class BaseRepository<Tentity> : IBaseRepository<Tentity> where Tentity : class, IBaseEntity
    {
        public TestExampleContext _testExampleContext { get; set; }
        private readonly DbSet<Tentity> _dbSet;

        public BaseRepository(TestExampleContext testExampleContext)
        {
            _testExampleContext = testExampleContext;
            _dbSet = testExampleContext.Set<Tentity>();
        }

        public async Task AddAsync(Tentity tentity)
        {
            await _dbSet.AddAsync(tentity).ConfigureAwait(false);

            await _testExampleContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id).ConfigureAwait(false);
            if (entity == null) throw new TestExamplesException("Silinecek data bulunamadı");

            _dbSet.Remove(entity);

            await _testExampleContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<Tentity>> GetAllAsync(Expression<Func<Tentity, bool>> expression)
        {
            var entities = await _dbSet.Where(expression).ToListAsync().ConfigureAwait(false);
            return entities;
        }

        public async Task<IEnumerable<Tentity>> GetAllAsync()
        {
            var entities = await _dbSet.ToListAsync().ConfigureAwait(false);
            return entities;
        }

        public async Task<Tentity> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id).ConfigureAwait(false);
            return entity;
        }

        public async Task Update(Tentity tentity)
        {
            _dbSet.Update(tentity);

            await _testExampleContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
