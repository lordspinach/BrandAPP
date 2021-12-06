using AutoMapper;
using BrandAPP.BLLayer.DTO;
using BrandAPP.DBLayer.Entities;

namespace BrandAPP.BLLayer.MappingProfiles
{
    public class BrandMappings : Profile
    {
        public BrandMappings()
        {
            CreateMap<BrandDTO, BrandDb>().ReverseMap();
        }
    }
}
