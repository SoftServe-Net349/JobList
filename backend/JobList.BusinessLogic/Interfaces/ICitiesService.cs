using JobList.Common.DTOS;
using JobList.Common.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Interfaces
{
    public interface ICitiesService
    {
        Task<IEnumerable<CityDTO>> GetAllEntitiesAsync();

        Task<CityDTO> GetEntityByIdAsync(int id);

        Task<CityDTO> CreateEntityAsync(CityRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(CityRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);
    }
}
