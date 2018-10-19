using AutoMapper;
using JobList.Common.DTOS;
using JobList.Common.Requests;
using JobList.DataAccess.Entities;

namespace JobList.BusinessLogic.MappingProfiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, Company>()
            .ForMember(d => d.Id, o => o.Ignore())// Don't Map Id because It is useless for Ids when updating
            .ForMember(d => d.Password, o => o.Ignore()); 

            CreateMap<Company, CompanyDTO>();

            CreateMap<CompanyDTO, Company>();

            CreateMap<CompanyRequest, Company>()
                .ForMember(d => d.Id, o => o.UseValue(0));

            CreateMap<CompanyUpdateRequest, Company>()
                .ForMember(d => d.Id, o => o.UseValue(0))
                .ForMember(d => d.Password, o => o.Ignore());

        }
    }
}
