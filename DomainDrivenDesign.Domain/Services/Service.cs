using DomainDrivenDesign.Domain.Interfaces.Repositories;
using DomainDrivenDesign.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace DomainDrivenDesign.Domain.Services
{
    public class Service<TEntity> : IDisposable, IService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> repository;

        public Service(IRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Save(TEntity obj)
        {
            repository.Save(obj);
        }

        public void Update(TEntity obj)
        {
            repository.Update(obj);
        }

        public void Delete(TEntity obj)
        {
            repository.Delete(obj);
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
