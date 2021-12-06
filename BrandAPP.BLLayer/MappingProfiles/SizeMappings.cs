using AutoMapper;
using BrandAPP.BLLayer.DTO;
using BrandAPP.DBLayer.Entities;

namespace BrandAPP.BLLayer.MappingProfiles
{
    public class SizeMappings : Profile
    {
        public SizeMappings()
        {
            CreateMap<SizeDTO, SizeDb>()
                .ForPath(s => s.Brand.Id, opt => opt.MapFrom(dst => dst.BrandId))
                .ReverseMap();
        }
    }
}
