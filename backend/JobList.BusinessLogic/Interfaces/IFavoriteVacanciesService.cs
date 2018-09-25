using JobList.Common.DTOS;
using JobList.Common.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace JobList.BusinessLogic.Interfaces
{
    public interface IFavoriteVacanciesService
    {
        Task<IEnumerable<FavoriteVacancyDTO>> GetAllEntitiesAsync();

        Task<FavoriteVacancyDTO> GetEntityByIdAsync(int id);

        Task<FavoriteVacancyDTO> CreateEntityAsync(FavoriteVacancyRequest modelRequest);

        Task<bool> UpdateEntityByIdAsync(FavoriteVacancyRequest modelRequest, int id);

        Task<bool> DeleteEntityByIdAsync(int id);
    }
}
