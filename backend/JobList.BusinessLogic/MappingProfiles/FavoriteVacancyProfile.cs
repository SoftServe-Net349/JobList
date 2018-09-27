using AutoMapper;
using JobList.Common.DTOS;
using JobList.Common.Requests;
using JobList.DataAccess.Entities;

namespace JobList.BusinessLogic.MappingProfiles
{
    public class FavoriteVacancyProfile :Profile
    {
        public FavoriteVacancyProfile()
        {
            CreateMap<FavoriteVacancy, FavoriteVacancy>()
                .ForMember(d => d.Id, o => o.Ignore()); // Don't Map Id because It is useless for Ids when updating

            CreateMap<FavoriteVacancy, FavoriteVacancyDTO>();

            CreateMap<FavoriteVacancyDTO, FavoriteVacancy>();

            CreateMap<FavoriteVacancyRequest, FavoriteVacancy>()
                .ForMember(d => d.Id, o => o.UseValue(0));


        }
    }
}
