using AutoMapper;
using JobList.Common.DTOS;
using JobList.Common.Requests;
using JobList.DataAccess.Entities;

namespace JobList.BusinessLogic.MappingProfiles
{
    public class ExperienceProfile : Profile
    {
        public ExperienceProfile()
        {
            CreateMap<Experience, Experience>()
                .ForMember(d => d.Id, o => o.Ignore()); // Don't Map Id because It is useless for Ids when updating

            CreateMap<Experience, ExperienceDTO>();

            CreateMap<ExperienceDTO, Experience>();

            CreateMap<ExperienceRequest, Experience>()
                .ForMember(d => d.Id, o => o.UseValue(0));

        }
    }
}
