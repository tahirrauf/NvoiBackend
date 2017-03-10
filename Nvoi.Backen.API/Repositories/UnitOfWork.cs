using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nvoi.Backen.API.DAL;

namespace Nvoi.Backen.API.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private MerchantEntity entities = null;

        public UnitOfWork()
        {
            entities = new MerchantEntity();
        }
        
        IRepository<Merchant> merchantRepository = null;

        public IRepository<Merchant> MerchantRepository
        {
            get
            {
                if (merchantRepository == null)
                {
                    merchantRepository = new MerchantRepository(entities);
                }
                return merchantRepository;
            }
        }

        public void SaveChanges()
        {
            merchantRepository.SaveChanges();
        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    entities.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}