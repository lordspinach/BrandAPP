using BrandAPP.BLLayer.DTO;
using System.Collections.Generic;

namespace BrandAPP.BLLayer.Interfaces
{
    public interface IBrandService
    {
        IEnumerable<BrandDTO> GetBrands();
        void CreateBrand(BrandDTO brandDTO);
        BrandDTO GetBrand(int id);
        BrandDTO GetBrandByName(string name);
        bool AddSize(int brandId, SizeDTO sizeDTO);
        ICollection<SizeDTO> GetBrandSizes(int brandId);
        void Dispose();
    }
}
