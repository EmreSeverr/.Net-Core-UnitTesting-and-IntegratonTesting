using System.Collections.Generic;
using System.Threading.Tasks;
using TestExamples.API.DTOs;

namespace TestExamples.API.Services.Abstract
{
    public interface IUnitService
    {
        Task<List<UnitDTO>> GetAllUnitAsync();
        Task<UnitDTO> GetByIdUnitAsync(int id);
        Task AddUnitAsync(UnitDTO unitDTO);
        Task UpdateUnitAsync(UnitDTO unitDTO);
        Task DeleteByIdUnit(int id);
    }
}
