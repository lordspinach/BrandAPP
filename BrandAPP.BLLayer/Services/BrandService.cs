using AutoMapper;
using BrandAPP.BLLayer.DTO;
using BrandAPP.BLLayer.Infrastructure;
using BrandAPP.BLLayer.Interfaces;
using BrandAPP.DBLayer.Entities;
using BrandAPP.DBLayer.Interfaces;
using System.Collections.Generic;

namespace BrandAPP.BLLayer.Services
{
    public class BrandService : IBrandService
    {
        private IUnitOfWork _database { get; set; }
        private IMapper _mapper;

        public BrandService(IUnitOfWork uow, IMapper mapper)
        {
            _database = uow;
            _mapper = mapper;
        }

        public IEnumerable<BrandDTO> GetBrands()
        {
            return _mapper.Map<IList<BrandDTO>>(_database.Brands.GetAll());
        }

        public void CreateBrand(BrandDTO brand)
        {
            _database.Brands.Create(_mapper.Map<BrandDb>(brand));
            _database.Save();
        }

        public BrandDTO GetBrand(int id)
        {
            var brand = _mapper.Map<BrandDTO>(_database.Brands.Get(id));
            if (brand == null)
            {
                throw new ValidationException($"There is no brand with ID = {id}", "");
            }
            return brand;
        }

        public BrandDTO GetBrandByName(string name)
        {
            var brandDb = _database.Brands.FindByName(name);
            if(brandDb == null)
                throw new ValidationException($"There is no brand with Name = {name}", "");

            return _mapper.Map<BrandDTO>(brandDb);
        }

        public bool AddSize(int brandId, SizeDTO sizeDto)
        {
            var brand = _database.Brands.Get(brandId);
            if(brand == null)
            {
                throw new ValidationException($"There is no brand with ID = {sizeDto.BrandId}", "");
            }
                
            var size = _mapper.Map<SizeDb>(sizeDto);
            size.Brand = brand;

            _database.Sizes.Create(size);
            _database.Save();
            return true;
        }

        public ICollection<SizeDTO> GetBrandSizes(int brandId)
        {
            var brand = GetBrand(brandId);
            if (brand.Sizes.Count > 0)
            {
                var sizes = _mapper.Map<ICollection<SizeDTO>>(brand.Sizes);
                return sizes;
            }
            else
            {
                throw new ValidationException($"Brand with ID = {brandId} have no sizes", "");
            }
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}
