using AutoMapper;
using JobList.Common.DTOS;
using JobList.Common.Requests;
using JobList.DataAccess.Entities;

namespace JobList.BusinessLogic.MappingProfiles
{
    public class SchoolProfile : Profile
    {
        public SchoolProfile()
        {
            CreateMap<School, School>()
                .ForMember(d => d.Id, o => o.Ignore()); // Don't Map Id because It is useless for Ids when updating

            CreateMap<School, SchoolDTO>();

            CreateMap<SchoolDTO, School>();

            CreateMap<SchoolRequest, School>();

        }
    }
}
