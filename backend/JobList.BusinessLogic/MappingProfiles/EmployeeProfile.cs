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

            CreateMap<Employee, EmployeeDTO>();

            CreateMap<EmployeeDTO, Employee>();

            CreateMap<EmployeeRequest, Employee>()
                .ForMember(d => d.Id, o => o.UseValue(0));

            CreateMap<EmployeeUpdateRequest, Employee>()
                .ForMember(d => d.Id, o => o.UseValue(0));
        }
    }
}
