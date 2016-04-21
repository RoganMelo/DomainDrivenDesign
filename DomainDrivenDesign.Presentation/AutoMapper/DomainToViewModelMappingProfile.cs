using AutoMapper;
using DomainDrivenDesign.Domain.Models;
using DomainDrivenDesign.Presentation.ViewModels;

namespace DomainDrivenDesign.Presentation.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
            : base("DomainToViewModelMappings")
        {

        }

        protected override void Configure()
        {
            Mapper.CreateMap<InstitutionModel, InstitutionViewModel>();
        }
    }
}