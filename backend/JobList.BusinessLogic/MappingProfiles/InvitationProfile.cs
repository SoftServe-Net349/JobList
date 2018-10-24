using AutoMapper;
using JobList.Common.DTOS;
using JobList.Common.Requests;
using JobList.DataAccess.Entities;

namespace JobList.BusinessLogic.MappingProfiles
{
    public class InvitationProfile : Profile
    {
        public InvitationProfile()
        {
            CreateMap<Invitation, Invitation>()
                .ForMember(d => d.Id, o => o.Ignore()); // Don't Map Id because It is useless for Ids when updating

            CreateMap<Invitation, InvitationDTO>();

            CreateMap<FavoriteVacancyDTO, Invitation>();

            CreateMap<InvitationRequest, Invitation>()
                .ForMember(d => d.Id, o => o.UseValue(0));

        }
    }
}
