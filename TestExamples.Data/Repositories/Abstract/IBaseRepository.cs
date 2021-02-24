using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestExamples.Data.Entities.Abstract;

namespace TestExamples.Data.Repositories.Abstract
{
    public interface IBaseRepository<Tentity> where Tentity : class, IBaseEntity
    {
        Task<IEnumerable<Tentity>> GetAllAsync(Expression<Func<Tentity, bool>> expression);
        Task<IEnumerable<Tentity>> GetAllAsync();
        Task<Tentity> GetByIdAsync(int id);
        Task AddAsync(Tentity tentity);
        Task DeleteByIdAsync(int id);
        Task Update(Tentity tentity);
    }
}
