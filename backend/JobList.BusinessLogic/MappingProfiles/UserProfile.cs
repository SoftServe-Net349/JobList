using AutoMapper;
using JobList.Common.DTOS;
using JobList.Common.Requests;
using JobList.DataAccess.Entities;

namespace JobList.BusinessLogic.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, User>()
                .ForMember(d => d.Id, o => o.Ignore()); // Don't Map Id because It is useless for Ids when updating

            CreateMap<User, UserDTO>();

            CreateMap<UserDTO, User>();

            CreateMap<UserRequest, User>()
                .ForMember(d => d.Id, o => o.UseValue(0));

        }
    }
}
