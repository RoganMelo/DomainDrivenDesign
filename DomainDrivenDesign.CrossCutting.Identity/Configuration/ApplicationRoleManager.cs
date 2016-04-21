using DomainDrivenDesign.CrossCutting.Identity.Context;
using DomainDrivenDesign.CrossCutting.Identity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace DomainDrivenDesign.CrossCutting.Identity.Configuration
{
    //Configurando o RoleManager utilizado na aplicação.
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(IRoleStore<IdentityRole, string> roleStore)
            : base(roleStore)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            return new ApplicationRoleManager(new RoleStore<IdentityRole>(new UnitOfWorkIdentity()));
        }
    }
}
