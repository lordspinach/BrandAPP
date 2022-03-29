using BrandAPP.BLLayer.DTO;
using System.Collections.Generic;

namespace BrandAPP.BLLayer.Interfaces
{
    public interface IBrandService
    {
        IEnumerable<BrandDTO> GetBrands();
        void CreateBrand(BrandDTO brandDTO);
        void UpdateBrand(int id, BrandDTO brand);
        BrandDTO GetBrand(int id);
        BrandDTO GetBrandByName(string name);
        void AddSize(int brandId, SizeDTO sizeDTO);
        void UpdateSize(int sizeId, SizeDTO sizeDto);
        ICollection<SizeDTO> GetBrandSizes(int brandId);
        void DeleteBrand(int brandId);
        void DeleteSize(int sizeId);
        void Dispose();
    }
}
