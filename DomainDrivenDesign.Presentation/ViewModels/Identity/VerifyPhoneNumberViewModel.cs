using System.ComponentModel.DataAnnotations;

namespace DomainDrivenDesign.Presentation.ViewModels.Identity
{
    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Código")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Número do Telefone")]
        public string PhoneNumber { get; set; }
    }
}
