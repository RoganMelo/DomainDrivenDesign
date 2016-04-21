using System.ComponentModel.DataAnnotations;

namespace DomainDrivenDesign.Presentation.ViewModels.Identity
{
    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Número do Telefone")]
        public string Number { get; set; }
    }
}
