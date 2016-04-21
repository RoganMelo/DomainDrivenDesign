using FluentNHibernate.Mapping;
using DomainDrivenDesign.CrossCutting.Identity.Models;

namespace DomainDrivenDesign.CrossCutting.Identity.Context.Mappings
{
    public class IdentityUserMap : ClassMap<IdentityUser>
    {
        public IdentityUserMap()
        {
            Table("Users");
            Id(x => x.Id).GeneratedBy.Assigned().Length(128);
            Map(x => x.Email).Not.Nullable().Length(256);
            Map(x => x.EmailConfirmed).Not.Nullable().Default("false");
            Map(x => x.PasswordHash).Nullable();
            Map(x => x.SecurityStamp).Nullable();
            Map(x => x.PhoneNumber).Nullable();
            Map(x => x.PhoneNumberConfirmed).Not.Nullable().Default("false");
            Map(x => x.TwoFactorEnabled).Not.Nullable().Default("false");
            Map(x => x.LockoutEndDateUtc).Nullable();
            Map(x => x.LockoutEnabled).Not.Nullable().Default("false");
            Map(x => x.AccessFailedCount).Not.Nullable().Default("0");
            Map(x => x.UserName).Not.Nullable().Length(256);
            HasMany(x => x.Clients).Cascade.All().Table("User_Clients").KeyColumn("User_Id");
            HasMany(x => x.Logins).Table("User_Logins").KeyColumn("User_Id");
            HasMany(x => x.Roles).Table("User_Roles").KeyColumn("User_Id");
            HasMany(x => x.Claims).Table("User_Claims").KeyColumn("User_Id");
        }
    }
}