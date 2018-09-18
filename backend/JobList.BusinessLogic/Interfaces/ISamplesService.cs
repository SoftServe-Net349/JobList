using JobList.Common.DTOS;
using JobList.Common.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Interfaces
{
    public interface ISamplesService
    {
        Task<IEnumerable<SampleDTO>> GetAllEntitiesAsync();

        Task<SampleDTO> GetEntityByIdAsync(int id);

        Task<SampleDTO> CreateEntityAsync(SampleRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(SampleRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);
    }
}
