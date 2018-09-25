using JobList.Common.DTOS;
using JobList.Common.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Interfaces
{
    public interface IRecruitersService
    {
        Task<IEnumerable<RecruiterDTO>> GetAllEntitiesAsync();

        Task<RecruiterDTO> GetEntityByIdAsync(int id);

        Task<RecruiterDTO> CreateEntityAsync(RecruiterRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(RecruiterRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);
    }
}
