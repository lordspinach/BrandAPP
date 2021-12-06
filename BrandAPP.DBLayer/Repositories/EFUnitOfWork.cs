using BrandAPP.DBLayer.EF;
using BrandAPP.DBLayer.Entities;
using BrandAPP.DBLayer.Interfaces;
using System;

namespace BrandAPP.DBLayer.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        private BrandRepository _brandRepository;
        private SizeRepository _sizeRepository;

        public EFUnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public IRepository<BrandDb> Brands
        {
            get
            {
                if(_brandRepository == null)
                    _brandRepository = new BrandRepository(_context);
                return _brandRepository;
            }
        }

        public IRepository<SizeDb> Sizes
        {
            get
            {
                if(_sizeRepository == null)
                    _sizeRepository = new SizeRepository(_context);
                return (_sizeRepository);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if(disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
