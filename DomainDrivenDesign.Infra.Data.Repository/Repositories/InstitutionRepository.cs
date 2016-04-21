using DomainDrivenDesign.Domain.Interfaces.Repositories;
using DomainDrivenDesign.Domain.Models;
using DomainDrivenDesign.Infra.Data.Context.Interfaces;

namespace DomainDrivenDesign.Infra.Data.Repository.Repositories
{
    public class InstitutionRepository : Repository<InstitutionModel>, IInstitutionRepository
    {
        public InstitutionRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}
