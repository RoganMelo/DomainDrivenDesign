using DomainDrivenDesign.Domain.Models;
using FluentNHibernate.Mapping;

namespace DomainDrivenDesign.Infra.Data.Context.Mappings
{
    public class InstitutionMap : ClassMap<InstitutionModel>
    {
        public InstitutionMap()
        {
            Table("Institution");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Not.Nullable().Length(100);
        }
    }
}
