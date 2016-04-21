using FluentNHibernate.Mapping;
using DomainDrivenDesign.CrossCutting.Identity.Models;

namespace DomainDrivenDesign.CrossCutting.Identity.Context.Mappings
{
    public class IdentityUserClaimMap : ClassMap<IdentityUserClaim>
    {
        public IdentityUserClaimMap()
        {
            Table("User_Claims");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.ClaimType).Column("Type");
            Map(x => x.ClaimValue).Column("Value");
            References(x => x.User).Column("User_Id");
        }
    }
}
