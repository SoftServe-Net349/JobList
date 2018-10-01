using AutoMapper;
using JobList.Common.DTOS;
using JobList.Common.Requests;
using JobList.DataAccess.Entities;

namespace JobList.BusinessLogic.MappingProfiles
{
    public class EducationPeriodProfile : Profile
    {
        public EducationPeriodProfile()
        {
            CreateMap<EducationPeriod, EducationPeriod>()
                .ForMember(d => d.Id, o => o.Ignore()); // Don't Map Id because It is useless for Ids when updating

            CreateMap<EducationPeriod, EducationPeriodDTO>();

            CreateMap<EducationPeriodDTO, EducationPeriod>();

            CreateMap<EducationPeriodRequest, EducationPeriod>()
                .ForMember(d => d.Id, o => o.UseValue(0));

        }
    }
}
