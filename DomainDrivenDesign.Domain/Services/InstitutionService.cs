using DomainDrivenDesign.Domain.Interfaces.Repositories;
using DomainDrivenDesign.Domain.Interfaces.Services;
using DomainDrivenDesign.Domain.Models;

namespace DomainDrivenDesign.Domain.Services
{
    public class InstitutionService : Service<InstitutionModel>, IInstitutionService
    {
        private readonly IInstitutionRepository institutionRepository;

        public InstitutionService(IInstitutionRepository institutionRepository)
            : base(institutionRepository)
        {
            this.institutionRepository = institutionRepository;
        }
    }
}
