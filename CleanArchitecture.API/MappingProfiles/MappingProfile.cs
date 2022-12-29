using AutoMapper;
using CleanArchitecture.API.DTOs;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.API.MappingProfiles
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            this.CreateMap<Albums, AlbumDTO>().ReverseMap();
            this.CreateMap<Artists, ArtistDTO>().ReverseMap();
        }

    }
}
