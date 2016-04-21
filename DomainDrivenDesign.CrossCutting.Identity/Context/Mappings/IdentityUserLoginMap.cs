using FluentNHibernate.Mapping;
using DomainDrivenDesign.CrossCutting.Identity.Models;

namespace DomainDrivenDesign.CrossCutting.Identity.Context.Mappings
{
    public class IdentityUserLoginMap : ClassMap<IdentityUserLogin>
    {
        public IdentityUserLoginMap()
        {
            Table("User_Logins");
            Id(x => x.ProviderKey).GeneratedBy.Assigned();
            Map(x => x.LoginProvider);
        }
    }
}
