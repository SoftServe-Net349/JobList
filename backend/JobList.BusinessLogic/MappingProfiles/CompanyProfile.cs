using AutoMapper;
using JobList.Common.DTOS;
using JobList.Common.Requests;
using JobList.DataAccess.Entities;
using System;

namespace JobList.BusinessLogic.MappingProfiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, Company>()
                .ForMember(d => d.Id, o => o.Ignore()) // Don't Map Id because It is useless for Ids when updating
                .ForMember(d => d.Password, o => o.Ignore()) // Don't Map Password because it updates without autoMapper
                .ForMember(d => d.RefreshToken, o => o.Ignore()); // Don't Map RefreshToken because it updates without autoMapper

            CreateMap<Company, CompanyDTO>()
                .ForMember(d => d.LogoData, o => o.MapFrom<string>(c => MapLogoData(c.LogoData)));

            CreateMap<CompanyDTO, Company>()
                .ForMember(d => d.LogoData, o => o.MapFrom<byte[]>(cr => MapLogoData(cr.LogoData)));

            CreateMap<CompanyRequest, Company>()
                .ForMember(d => d.Id, o => o.UseValue(0))
                .ForMember(d => d.LogoData, o => o.MapFrom<byte[]>(cr => MapLogoData(cr.LogoData)));

            CreateMap<CompanyUpdateRequest, Company>()
                .ForMember(d => d.Id, o => o.UseValue(0))
                .ForMember(d => d.LogoData, o => o.MapFrom<byte[]>(cr => MapLogoData(cr.LogoData)));
        }

        private byte[] MapLogoData(string logoData)
        {
            return Convert.FromBase64String(logoData);
        }

        private string MapLogoData(byte[] logoData)
        {
            return Convert.ToBase64String(logoData);
        }
    }
}
