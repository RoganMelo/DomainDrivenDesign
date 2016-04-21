using DomainDrivenDesign.Application.Interfaces;
using DomainDrivenDesign.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace DomainDrivenDesign.Application
{
    public class AppService<TEntity> : IDisposable, IAppService<TEntity> where TEntity : class
    {
        private readonly IService<TEntity> service;

        public AppService(IService<TEntity> service)
        {
            this.service = service;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return service.GetAll();
        }

        public TEntity GetById(int id)
        {
            return service.GetById(id);
        }

        public void Save(TEntity obj)
        {
            service.Save(obj);
        }

        public void Update(TEntity obj)
        {
            service.Update(obj);
        }

        public void Delete(TEntity obj)
        {
            service.Delete(obj);
        }

        public void Dispose()
        {
            service.Dispose();
        }
    }
}
