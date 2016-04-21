using System.ComponentModel.DataAnnotations;

namespace DomainDrivenDesign.Presentation.ViewModels.Identity
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}
