using BrandAPP.DBLayer.EF;
using BrandAPP.DBLayer.Entities;
using BrandAPP.DBLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BrandAPP.DBLayer.Repositories
{
    public class SizeRepository : IRepository<SizeDb>
    {
        private readonly ApplicationContext _context;

        public SizeRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<SizeDb> GetAll()
        {
            return _context.Sizes;
        }

        public SizeDb Get(int id)
        {
            return _context.Sizes.Find(id);
        }

        public void Create(SizeDb size)
        {
            _context.Sizes.Add(size);
        }

        public void Update(SizeDb size)
        {
            _context.Entry(size).State = EntityState.Modified;
        }

        public IEnumerable<SizeDb> Find(Func<SizeDb, Boolean> predicate)
        {
            return _context.Sizes.Include(b => b.Brand).Where(predicate).ToList();
        }

        public SizeDb FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            SizeDb size = _context.Sizes.Find(id);
            if (size != null)
                _context.Sizes.Remove(size);
        }
    }
}
