using System.Collections.Generic;

namespace DomainDrivenDesign.Application.Interfaces
{
    public interface IAppService<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Save(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);
        void Dispose();
    }
}
