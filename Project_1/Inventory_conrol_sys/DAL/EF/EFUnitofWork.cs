using System;
using DAL.Entities;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using DAL.Unit_of_work;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class EFUnitOfWork
        : IUnitOfWork
    {
        private SysteamContext db;
        private SysteamRepository systeamRepository;
        private ShopRepository shopRepository;

        public EFUnitOfWork(SysteamContext context)
        {
            db = context;
        }
        public ISysteamRepository Systeams
        {
            get
            {
                if (systeamRepository == null)
                    systeamRepository = new SysteamRepository(db);
                return systeamRepository;
            }
        }

        public IShopRepository Shops
        {
            get
            {
                if (shopRepository == null)
                    shopRepository = new ShopRepository(db);
                return shopRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
