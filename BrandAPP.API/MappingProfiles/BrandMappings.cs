using AutoMapper;
using BrandAPP.API.Models.Requests;
using BrandAPP.API.Models.Responses;
using BrandAPP.BLLayer.DTO;

namespace BrandAPP.API.MappingProfiles
{
    public class BrandMappings : Profile
    {
        public BrandMappings()
        {
            CreateMap<BrandDTO, BrandResponse>().ReverseMap(); 
            CreateMap<BrandCreateRequest, BrandDTO>().ReverseMap();
            CreateMap<BrandUpdateRequest, BrandDTO>().ReverseMap();
        }
    }
}
