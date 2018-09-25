using JobList.Common.DTOS;
using JobList.Common.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Interfaces
{
    public interface IFacultiesService
    {
        Task<IEnumerable<FacultyDTO>> GetAllEntitiesAsync();

        Task<FacultyDTO> GetEntityByIdAsync(int id);

        Task<FacultyDTO> CreateEntityAsync(FacultyRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(FacultyRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);
    }
}
