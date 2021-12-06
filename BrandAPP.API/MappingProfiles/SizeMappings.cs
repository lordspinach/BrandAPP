using AutoMapper;
using BrandAPP.API.Models.Requests;
using BrandAPP.API.Models.Responses;
using BrandAPP.BLLayer.DTO;

namespace BrandAPP.API.MappingProfiles
{
    public class SizeMappings : Profile
    {
        public SizeMappings()
        {
            CreateMap<SizeDTO, SizeResponse>().ReverseMap();
            CreateMap<SizeDTO, SizeCreateRequest>().ReverseMap();
        }
    }
}
