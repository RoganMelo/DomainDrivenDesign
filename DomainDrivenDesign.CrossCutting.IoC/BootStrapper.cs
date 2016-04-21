using Microsoft.AspNet.Identity;
using DomainDrivenDesign.Application;
using DomainDrivenDesign.Application.Interfaces;
using DomainDrivenDesign.CrossCutting.Identity.Configuration;
using DomainDrivenDesign.CrossCutting.Identity.Context;
using DomainDrivenDesign.CrossCutting.Identity.Models;
using DomainDrivenDesign.Domain.Interfaces.Repositories;
using DomainDrivenDesign.Domain.Interfaces.Services;
using DomainDrivenDesign.Domain.Services;
using DomainDrivenDesign.Infra.Data.Context;
using DomainDrivenDesign.Infra.Data.Context.Interfaces;
using DomainDrivenDesign.Infra.Data.Repository.Repositories;
using SimpleInjector;
using DomainDrivenDesign.CrossCutting.Identity.Context.Interfaces;

namespace DomainDrivenDesign.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            //Identity
            container.Register<UnitOfWorkIdentity>(Lifestyle.Scoped);
            container.Register<IUnitOfWorkIdentity, UnitOfWorkIdentity>(Lifestyle.Scoped);
            container.RegisterPerWebRequest<IUserStore<IdentityUser>>(() => new UserStore<IdentityUser>(new UnitOfWorkIdentity()));

            container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            container.Register<ApplicationSignInManager>(Lifestyle.Scoped);

            //ApplicationServices
            container.Register(typeof(IAppService<>), typeof(AppService<>), Lifestyle.Scoped);

            container.Register<IInstitutionAppService, InstitutionAppService>(Lifestyle.Scoped);

            //UnitOfWork
            container.Register<UnitOfWork>(Lifestyle.Scoped);
            container.RegisterPerWebRequest<IUnitOfWork, UnitOfWork>();

            //Repositories
            container.Register(typeof(IRepository<>), typeof(Repository<>), Lifestyle.Scoped);

            container.Register<IInstitutionRepository, InstitutionRepository>(Lifestyle.Scoped);

            //Services
            container.Register(typeof(IService<>), typeof(Service<>), Lifestyle.Scoped);

            container.Register<IInstitutionService, InstitutionService>(Lifestyle.Scoped);
        }
    }
}
