namespace DomainDrivenDesign.Infra.Data.Context.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
    }
}
