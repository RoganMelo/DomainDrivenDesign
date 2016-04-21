using System.ComponentModel.DataAnnotations;

namespace DomainDrivenDesign.Presentation.ViewModels
{
    public class InstitutionViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(3, ErrorMessage = "Minimo {0} caracteres")]
        public string Name { get; set; }
    }
}