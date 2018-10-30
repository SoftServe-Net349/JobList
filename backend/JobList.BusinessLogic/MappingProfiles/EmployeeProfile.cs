using AutoMapper;
using JobList.Common.DTOS;
using JobList.Common.Requests;
using JobList.DataAccess.Entities;
using System;

namespace JobList.BusinessLogic.MappingProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, Employee>()
                .ForMember(d => d.Id, o => o.Ignore())// Don't Map Id because It is useless for Ids when updating
                .ForMember(d => d.Password, o => o.Ignore())
                .ForMember(d => d.RefreshToken, o => o.Ignore()); 

            CreateMap<Employee, EmployeeDTO>()
                 .ForMember(d => d.PhotoData, o => o.MapFrom<string>(c => MapLogoData(c.PhotoData)));

            CreateMap<EmployeeDTO, Employee>();
                

            CreateMap<EmployeeRequest, Employee>()
                .ForMember(d => d.Id, o => o.UseValue(0));

            CreateMap<EmployeeUpdateRequest, Employee>()
                .ForMember(d => d.Id, o => o.UseValue(0))
                .ForMember(d => d.PhotoData, o => o.MapFrom<byte[]>(cr => MapLogoData(cr.PhotoData))); 
           
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
