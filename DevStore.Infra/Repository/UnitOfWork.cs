using DevStore.Domain.Interfaces;
using DevStore.Infra.DataContexts;
using Microsoft.Practices.ServiceLocation;
using System.Data.Entity;

namespace DevStore.Infra.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;
        
        public void Begin()
        {
            var contextMenager = ServiceLocator.Current.GetInstance<ContextMenager>();
            _context = (DevStoreDataContexts) contextMenager.Context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
