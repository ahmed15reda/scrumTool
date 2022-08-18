using Core.Dto;
using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.IServices
{
    public interface IAbsenceTypesService
    {
        Task<List<AbsenceTypesDto>> GetAll();
        Task<AbsenceTypesDto> GetAbsentTypeById(int id);
        Task<int> AddAbsentType(AbsenceTypes absentTypes);
        Task<int> UpdateAbsentType(AbsenceTypes absentTypes);
        Task<int> DeleteAbsentType(int id);
    }
}
