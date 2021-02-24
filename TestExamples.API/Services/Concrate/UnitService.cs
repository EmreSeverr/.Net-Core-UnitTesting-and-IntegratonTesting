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
    public class UnitService : IUnitService
    {
        private readonly IUnitRepository _unitRepository;

        public UnitService(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        public async Task AddUnitAsync(UnitDTO unitDTO)
        {
            if (unitDTO == null) throw new TestExamplesException("Eklenecek birim boş olamaz.");

            var unit = new Unit
            {
                Description = unitDTO.Description,
                Name = unitDTO.Name
            };

            await _unitRepository.AddAsync(unit).ConfigureAwait(false);
        }

        public async Task DeleteByIdUnit(int id)
        {
            var unit = await _unitRepository.GetByIdAsync(id).ConfigureAwait(false);

            if (unit == null) throw new TestExamplesException("Silinecek birim bulunamadı tekrar deneyiniz.");

            await _unitRepository.DeleteByIdAsync(id).ConfigureAwait(false);
        }

        public async Task<List<UnitDTO>> GetAllUnitAsync()
        {
            var units = await _unitRepository.GetAllAsync().ConfigureAwait(false);

            var unitDTOs = units != null ?
                           (from u in units
                            select new UnitDTO
                            {
                                Description = u.Description,
                                Name = u.Name
                            }).ToList() : null;

            return unitDTOs;
        }

        public async Task<UnitDTO> GetByIdUnitAsync(int id)
        {
            var unit = await _unitRepository.GetByIdAsync(id).ConfigureAwait(false);

            if (unit == null) throw new TestExamplesException("Silinecek birim bulunamadı tekrar deneyiniz.");

            var unitDTO = new UnitDTO
            {
                Description = unit.Description,
                Name = unit.Name
            };

            return unitDTO;
        }

        public async Task UpdateUnitAsync(UnitDTO unitDTO)
        {
            var unit = await _unitRepository.GetByIdAsync(unitDTO.Id).ConfigureAwait(false);

            if (unit == null) throw new TestExamplesException("Güncellenecek veri bulunamadı.");

            unit.Name = unitDTO.Name;
            unit.Description = unitDTO.Description;

            await _unitRepository.Update(unit).ConfigureAwait(false);
        }
    }
}
