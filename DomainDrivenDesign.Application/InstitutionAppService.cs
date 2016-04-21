using DomainDrivenDesign.Application.Interfaces;
using DomainDrivenDesign.Domain.Interfaces.Services;
using DomainDrivenDesign.Domain.Models;

namespace DomainDrivenDesign.Application
{
    public class InstitutionAppService : AppService<InstitutionModel>, IInstitutionAppService
    {
        private readonly IInstitutionService institutionService;

        public InstitutionAppService(IInstitutionService institutionService)
            : base(institutionService)
        {
            this.institutionService = institutionService;
        }
    }
}
