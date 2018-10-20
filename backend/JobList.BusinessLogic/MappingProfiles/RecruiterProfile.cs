using AutoMapper;
using JobList.Common.DTOS;
using JobList.Common.Requests;
using JobList.DataAccess.Entities;
using System;

namespace JobList.BusinessLogic.MappingProfiles
{
    public class RecruiterProfile : Profile
    {
        public RecruiterProfile()
        {
            CreateMap<Recruiter, Recruiter>()
                .ForMember(d => d.Id, o => o.Ignore()) // Don't Map Id because It is useless for Ids when updating
                .ForMember(d => d.Password, o => o.Ignore()) // Don't Map Password because it updates without autoMapper
                .ForMember(d => d.RefreshToken, o => o.Ignore()); // Don't Map RefreshToken because it updates without autoMapper

            CreateMap<Recruiter, RecruiterDTO>()
                .ForMember(d => d.PhotoData, o => o.MapFrom<string>(r => MapPhotoData(r.PhotoData)));

            CreateMap<RecruiterDTO, Recruiter>()
                .ForMember(d => d.PhotoData, o => o.MapFrom<byte[]>(r => MapPhotoData(r.PhotoData)));

            CreateMap<RecruiterRequest, Recruiter>()
                .ForMember(d => d.Id, o => o.UseValue(0))
                .ForMember(d => d.PhotoData, o => o.MapFrom<byte[]>(r => MapPhotoData(r.PhotoData)));

            CreateMap<RecruiterUpdateRequest, Recruiter>()
                .ForMember(d => d.Id, o => o.UseValue(0))
                .ForMember(d => d.PhotoData, o => o.MapFrom<byte[]>(r => MapPhotoData(r.PhotoData)));
        }

        private byte[] MapPhotoData(string photoData)
        {
            return Convert.FromBase64String(photoData);
        }

        private string MapPhotoData(byte[] photoData)
        {
            return Convert.ToBase64String(photoData);
        }

    }
}
