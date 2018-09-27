using AutoMapper;
using JobList.Common.DTOS;
using JobList.Common.Requests;
using JobList.DataAccess.Entities;

namespace JobList.BusinessLogic.MappingProfiles
{
    public class WorkAreaProfile : Profile
    {
        public WorkAreaProfile()
        {
            CreateMap<WorkArea, WorkArea>()
                .ForMember(d => d.Id, o => o.Ignore()); // Don't Map Id because It is useless for Ids when updating

            CreateMap<WorkArea, WorkAreaDTO>();

            CreateMap<WorkAreaDTO, WorkArea>();

            CreateMap<WorkAreaRequest, WorkArea>()
                .ForMember(d => d.Id, o => o.UseValue(0));

        }
    }
}
