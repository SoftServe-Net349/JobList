using AutoMapper;
using JobList.Common.DTOS;
using JobList.Common.Requests;
using JobList.DataAccess.Entities;

namespace JobList.BusinessLogic.MappingProfiles
{
    public class ResumeProfile : Profile
    {
        public ResumeProfile()
        {
            CreateMap<Resume, Resume>()
            .ForMember(d => d.Id, o => o.Ignore()); // Don't Map Id because It is useless for Ids when updating

            CreateMap<Resume, ResumeDTO>();

            CreateMap<ResumeDTO, Resume>();

            CreateMap<ResumeRequest, Resume>();
        }
    }
}
