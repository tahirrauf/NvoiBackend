using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;
using Nvoi.Backen.API.DAL;

namespace Nvoi.Backen.API.Repositories
{
    public class MerchantRepository : IRepository<Merchant>
    {
        private MerchantEntity entities = null;

        public MerchantRepository(MerchantEntity _entity)
        {
            entities = _entity;
        }

        public IEnumerable<Merchant> GetAll(Func<Merchant, bool> predicate = null)
        {
            if (predicate != null)
            {
                if (predicate != null)
                {
                    return entities.Merchants.Where(predicate);
                }
            }
 
            return entities.Merchants;
        }

        public Merchant Get(Func<Merchant, bool> predicate)
        {
            return entities.Merchants.FirstOrDefault(predicate);
        }

        public int Add(Merchant entity)
        {
            Merchant added = entities.Merchants.Add(entity);
            return added.Id;   
        }

        public void Attach(Merchant entity)
        {
            entities.Merchants.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Merchant entity)
        {
            entities.Entry(entity).State = EntityState.Deleted;
            entities.SaveChanges();
        }
 
        public void SaveChanges()
        {
            entities.SaveChanges();
        }
    };
}