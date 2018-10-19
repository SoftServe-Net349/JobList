using AutoMapper;
using JobList.Common.DTOS;
using JobList.Common.Requests;
using JobList.DataAccess.Entities;

namespace JobList.BusinessLogic.MappingProfiles
{
    public class RecruiterProfile : Profile
    {
        public RecruiterProfile()
        {
            CreateMap<Recruiter, Recruiter>()
                .ForMember(d => d.Password, o => o.Ignore())
                .ForMember(d => d.Id, o => o.Ignore()); // Don't Map Id because It is useless for Ids when updating

            CreateMap<Recruiter, RecruiterDTO>();

            CreateMap<RecruiterDTO, Recruiter>();

            CreateMap<RecruiterRequest, Recruiter>()
                .ForMember(d => d.Id, o => o.UseValue(0));

            CreateMap<RecruiterUpdateRequest, Recruiter>()
                .ForMember(d => d.Id, o => o.UseValue(0));
        }
    }
}
