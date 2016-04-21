using FluentNHibernate.Mapping;
using DomainDrivenDesign.CrossCutting.Identity.Models;

namespace DomainDrivenDesign.CrossCutting.Identity.Context.Mappings
{
    public class IdentityRoleMap : ClassMap<IdentityRole>
    {
        public IdentityRoleMap()
        {
            Table("User_Roles");
            Id(x => x.Id).GeneratedBy.Assigned();
            Map(x => x.Name).Not.Nullable().Unique().Length(255);
            HasMany(x => x.Users).Table("User_Roles");
        }
    }
}
