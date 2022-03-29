using BrandAPP.DBLayer.EF;
using BrandAPP.DBLayer.Entities;
using BrandAPP.DBLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BrandAPP.DBLayer.Repositories
{
    public class BrandRepository : IRepository<BrandDb>
    {
        private readonly ApplicationContext _context;

        public BrandRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<BrandDb> GetAll()
        {
            return _context.Brands.Where(s => s.IsDeleted == false).Include(s => s.Sizes).ToList();
        }

        public BrandDb Get(int id)
        {
            return _context.Brands.Include(s => s.Sizes).Where(s => s.IsDeleted == false).Where(s => s.Id == id).FirstOrDefault();
        }

        public void Create(BrandDb brand)
        {
            _context.Brands.Add(brand);
        }

        public void Update(int id, BrandDb brand)
        {
            brand.Id = id;
            _context.Entry(brand).State = EntityState.Modified;
            
        }

        public IEnumerable<BrandDb> Find(Func<BrandDb, Boolean> predicate)
        {
            return _context.Brands.Include(i => i.Sizes).Where(predicate).ToList();
        }

        public BrandDb FindByName(string name)
        {
            return _context.Brands.Where(s => s.IsDeleted == false).Include(i => i.Sizes).FirstOrDefault(x => x.Name == name);
        }

        public void Delete(int id)
        {
            var brand = _context.Brands.Where(s => s.IsDeleted == false).Where(s => s.Id == id).FirstOrDefault();
            if(brand != null)
            {
                _context.Entry(brand).State = EntityState.Deleted;
            }
        }

        public bool AnyId(int id)
        {
            return _context.Brands.Any(s => s.Id == id);
        }
    }
}
