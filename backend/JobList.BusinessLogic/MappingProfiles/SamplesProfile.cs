using AutoMapper;
using JobList.Common.DTOS;
using JobList.Common.Requests;
using JobList.DataAccess.Entities;

namespace JobList.BusinessLogic.MappingProfiles
{
    public class SamplesProfile : Profile
    {
        public SamplesProfile()
        {
            CreateMap<Sample, Sample>()
                .ForMember(d => d.Id, o => o.Ignore()); // Don't Map Id because It is useless for Ids when updating

            CreateMap<Sample, SampleDTO>()
                .ForMember(d => d.DateOfCreation, o => o.MapFrom(s => s.CreationDate));

            CreateMap<SampleRequest, Sample>()
                .ForMember(d => d.Id, o => o.UseValue(0))
                .ForMember(d => d.CreationDate, o => o.MapFrom(s => s.DateOfCreation));
        }
    }
}
