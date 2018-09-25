using JobList.Common.DTOS;
using JobList.Common.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Interfaces
{
    public interface ISchoolsService
    {
        Task<IEnumerable<SchoolDTO>> GetAllEntitiesAsync();

        Task<SchoolDTO> GetEntityByIdAsync(int id);

        Task<SchoolDTO> CreateEntityAsync(SchoolRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(SchoolRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);
    }
}
