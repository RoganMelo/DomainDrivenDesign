namespace DomainDrivenDesign.CrossCutting.Identity.Context.Interfaces
{
    public interface IUnitOfWorkIdentity
    {
        void BeginTransaction();
        void Commit();
    }
}
