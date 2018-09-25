using JobList.Common.DTOS;
using JobList.Common.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Interfaces
{
    public interface IResumesService
    {
        Task<IEnumerable<ResumeDTO>> GetAllEntitiesAsync();

        Task<ResumeDTO> GetEntityByIdAsync(int id);

        Task<ResumeDTO> CreateEntityAsync(ResumeRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(ResumeRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);
    }
}
