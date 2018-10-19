using AutoMapper;
using JobList.Common.DTOS;
using JobList.Common.Requests;
using JobList.DataAccess.Entities;

namespace JobList.BusinessLogic.MappingProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, Employee>()
                .ForMember(d => d.Id, o => o.Ignore()); // Don't Map Id because It is useless for Ids when updating

            CreateMap<Employee, EmployeeDTO>();

            CreateMap<EmployeeDTO, Employee>();

            CreateMap<EmployeeRequest, Employee>()
                .ForMember(d => d.Id, o => o.UseValue(0));

        }
    }
}
