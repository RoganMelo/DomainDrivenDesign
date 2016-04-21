using System.Collections.Generic;
using DomainDrivenDesign.Domain.Interfaces.Repositories;
using NHibernate;
using NHibernate.Linq;
using DomainDrivenDesign.Infra.Data.Context.Interfaces;
using DomainDrivenDesign.Infra.Data.Context;

namespace DomainDrivenDesign.Infra.Data.Repository.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private UnitOfWork unitOfWork;

        public Repository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = (UnitOfWork)unitOfWork;
        }

        protected ISession Session { get { return unitOfWork.Session; } }

        public IEnumerable<TEntity> GetAll()
        {
            return Session.Query<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return Session.Get<TEntity>(id);
        }

        public void Save(TEntity obj)
        {
            Session.SaveOrUpdate(obj);
        }

        public void Update(TEntity obj)
        {
            Session.Update(obj);
        }

        public void Delete(TEntity obj)
        {
            Session.Delete(obj);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
