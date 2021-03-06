﻿using DevStore.Domain.Interfaces;
using DevStore.Infra.DataContexts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DevStore.Infra.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {

        public RepositoryBase()
        {
            //var contextMenager = ServiceLocator.Current.GetInstance<ContextMenager>();

            //Context = contextMenager.Context;
           
        }

        public void Add(TEntity obj)
        {
            using ( var Context = new DevStoreDataContexts())
            {
                Context.Set<TEntity>().Add(obj);
                Context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var Context = new DevStoreDataContexts())
            {
                var obj = Context.Set<TEntity>().Find(id);

                Context.Set<TEntity>().Remove(obj);
                Context.SaveChanges();
            }
        }

        public void Delete(TEntity obj)
        {
            using (var Context = new DevStoreDataContexts())
            {
                Context.Set<TEntity>().Remove(obj);
                Context.SaveChanges();
            }
        }

        public IEnumerable<TEntity> Get()
        {
            using (var Context = new DevStoreDataContexts())
            {
                return Context.Set<TEntity>().ToList();
            }
        }

        public TEntity Get(int id)
        {
            using (var Context = new DevStoreDataContexts())
            {
                return Context.Set<TEntity>().Find(id);
            }
        }

        public void Update(TEntity obj)
        {
            using (var Context = new DevStoreDataContexts())
            {
                Context.Entry(obj).State = EntityState.Modified;
                Context.SaveChanges();
            }
        }
    }
}
