using AutoMapper;
using JobList.Common.DTOS;
using JobList.Common.Requests;
using JobList.DataAccess.Entities;

namespace JobList.BusinessLogic.MappingProfiles
{
    public class ResumeLanguageProfile : Profile
    {
        public ResumeLanguageProfile()
        {
            CreateMap<ResumeLanguage, ResumeLanguage>()
                .ForMember(d => d.Id, o => o.Ignore()); // Don't Map Id because It is useless for Ids when updating

            CreateMap<ResumeLanguage, ResumeLanguageDTO>();

            CreateMap<ResumeLanguageDTO, ResumeLanguage>();

            CreateMap<ResumeLanguageRequest, ResumeLanguage>()
                .ForMember(d => d.Id, o => o.UseValue(0));

        }
    }
}
