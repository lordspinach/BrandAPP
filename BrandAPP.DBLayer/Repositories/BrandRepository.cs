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
            return _context.Brands.Include(s => s.Sizes).ToList();
        }

        public BrandDb Get(int id)
        {
            return _context.Brands.Include(s => s.Sizes).Where(s => s.Id == id).FirstOrDefault();
        }

        public void Create(BrandDb brand)
        {
            _context.Brands.Add(brand);
        }

        public void Update(BrandDb brand)
        {
            _context.Entry(brand).State = EntityState.Modified;
        }

        public IEnumerable<BrandDb> Find(Func<BrandDb, Boolean> predicate)
        {
            return _context.Brands.Include(i => i.Sizes).Where(predicate).ToList();
        }

        public BrandDb FindByName(string name)
        {
            return _context.Brands.Include(i => i.Sizes).FirstOrDefault(x => x.Name == name);
        }

        public void Delete(int id)
        {
            BrandDb brand = _context.Brands.Find(id);
            if(brand != null)
                _context.Brands.Remove(brand);
        }
    }
}
