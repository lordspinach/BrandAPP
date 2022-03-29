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
            return _context.Sizes.Where(s => s.Id == id).FirstOrDefault();
        }

        public void Create(SizeDb size)
        {
            _context.Sizes.Add(size);
        }

        public void Update(int id, SizeDb size)
        {
            size.Id = id;
            _context.Entry(size).State = EntityState.Modified;
        }

        public IEnumerable<SizeDb> Find(Func<SizeDb, Boolean> predicate)
        {
            return _context.Sizes.Include(b => b.Brand).Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            var size = _context.Sizes.Find(id);
            if (size != null)
            {
                _context.Entry(size).State = EntityState.Deleted;
            }
                
        }

        public SizeDb FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool AnyId(int id)
        {
            return _context.Sizes.Any(s => s.Id == id);
        }
    }
}
