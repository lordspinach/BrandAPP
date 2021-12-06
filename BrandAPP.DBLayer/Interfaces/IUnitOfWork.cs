using BrandAPP.DBLayer.Entities;
using System;

namespace BrandAPP.DBLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<BrandDb> Brands { get; }
        IRepository<SizeDb> Sizes { get; }
        void Save();
    }
}
