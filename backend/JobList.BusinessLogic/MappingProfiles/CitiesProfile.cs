using AutoMapper;
using JobList.Common.DTOS;
using JobList.Common.Requests;
using JobList.DataAccess.Entities;
using System;

namespace JobList.BusinessLogic.MappingProfiles
{
    public class CitiesProfile : Profile
    {
        public CitiesProfile()
        {
            CreateMap<City, City>()
                .ForMember(d => d.Id, o => o.Ignore()); // Don't Map Id because It is useless for Ids when updating

            CreateMap<City, CityDTO>()
                .ForMember(d => d.PhotoData, o => o.MapFrom<string>(c => MapPhotoData(c.PhotoData)));

            CreateMap<CityDTO, City>()
                .ForMember(d => d.PhotoData, o => o.MapFrom<byte[]>(c => MapPhotoData(c.PhotoData)));

            CreateMap<CityRequest, City>()
                .ForMember(d => d.PhotoData, o => o.MapFrom<byte[]>(c => MapPhotoData(c.PhotoData)));
        }

        private byte[] MapPhotoData(string photoData) => Convert.FromBase64String(photoData);

        private string MapPhotoData(byte[] photoData) => Convert.ToBase64String(photoData);

    }
}
