using System.ComponentModel.DataAnnotations;

namespace AppSaresp_2024.Models
{
    public class ProfessorAplicador
    {
        [Display(Name = "Código")]
        public int? idProfessor { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "O campo nome é obrigatório")]

        public string nome { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [StringLength(11, ErrorMessage = "O CPF deve ter exatamente 11 dígitos.")]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "O CPF deve conter apenas números e ter 11 dígitos.")]
        public string CPF { get; set; }

        [Display(Name = "RG")]
        [Required(ErrorMessage = "O campo RG é obrigatório.")]
        [StringLength(9, ErrorMessage = "O RG deve ter 9 caracteres.")]
        public string RG { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
        [StringLength(11, ErrorMessage = "O Telefone deve ter no máximo 11 caracteres.")]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "O telefone deve conter apenas números e ter 11 dígitos.")]
        public string telefone { get; set; }

        [Display(Name = "Nascimento")]
        [Required(ErrorMessage = "O campo nascimento é obrigatório")]
        [DataType(DataType.Date)]
        public DateTime dataNasc { get; set; }
    }
}
