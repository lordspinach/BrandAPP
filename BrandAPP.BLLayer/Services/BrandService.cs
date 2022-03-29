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

        public void UpdateBrand(int id, BrandDTO brand)
        {
            if (_database.Brands.AnyId(id))
            {
                _database.Brands.Update(id, _mapper.Map<BrandDb>(brand));
                _database.Save();
            }
            else
            {
                throw new ValidationException($"There is no brand with ID = {id}");
            }
        }

        public BrandDTO GetBrand(int id)
        {
            var brand = _mapper.Map<BrandDTO>(_database.Brands.Get(id));
            if (brand == null)
            {
                throw new ValidationException($"There is no brand with ID = {id}");
            }
            return brand;
        }

        public BrandDTO GetBrandByName(string name)
        {
            var brandDb = _database.Brands.FindByName(name);
            if(brandDb == null)
                throw new ValidationException($"There is no brand with Name = {name}");

            return _mapper.Map<BrandDTO>(brandDb);
        }

        public void AddSize(int brandId, SizeDTO sizeDto)
        {
            var brand = _database.Brands.Get(brandId);
            if(brand == null)
            {
                throw new ValidationException($"There is no brand with ID = {brandId}");
            }
            foreach(var brandSize in brand.Sizes)
            {
                if (brandSize.RFSize == sizeDto.RFSize)
                {
                    throw new ValidationException($"This RFSize = {sizeDto.RFSize} already exist in the brand");
                }
            }
                
            var size = _mapper.Map<SizeDb>(sizeDto);
            size.Brand = brand;

            _database.Sizes.Create(size);
            _database.Save();
        }

        public void UpdateSize(int id, SizeDTO sizeDto)
        {
            if (_database.Sizes.AnyId(id))
            {
                _database.Sizes.Update(id, _mapper.Map<SizeDb>(sizeDto));
                _database.Save();
            }
            else
            {
                throw new ValidationException($"There is no size with ID = {id}");
            }
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
                throw new ValidationException($"Brand with ID = {brandId} have no sizes");
            }
        }

        public void DeleteBrand(int brandId)
        {
            var brand = GetBrand(brandId);
            if(brand != null)
            {
                _database.Brands.Delete(brandId);
                _database.Save();
            }
            else
            {
                throw new ValidationException($"There is no brand with ID = {brandId}");
            }
        }

        public void DeleteSize(int sizeId)
        {
            var size = _database.Sizes.Get(sizeId);
            if (size != null)
            {
                _database.Sizes.Delete(sizeId);
                _database.Save();
            }
            else
            {
                throw new ValidationException($"There is no size with ID = {sizeId}");
            }
        }

        public void Dispose()
        {
            _database.Dispose();
        }
    }
}
