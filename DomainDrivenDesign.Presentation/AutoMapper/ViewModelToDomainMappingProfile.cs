using AutoMapper;
using DomainDrivenDesign.Domain.Models;
using DomainDrivenDesign.Presentation.ViewModels;

namespace DomainDrivenDesign.Presentation.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
            : base("ViewModelToDomainMappings")
        {

        }

        protected override void Configure()
        {
            Mapper.CreateMap<InstitutionViewModel, InstitutionModel>();
        }
    }
}