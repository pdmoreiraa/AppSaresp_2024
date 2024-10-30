using System.ComponentModel.DataAnnotations;

namespace AppSaresp_2024.Models
{
    public class Aluno
    {
        [Display(Name = "Código")]
        public int? idAluno { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "O campo nome é obrigatório")]

        public string nome { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string email { get; set; }

        [Required(ErrorMessage = "O campo Série é obrigatório.")]
        [StringLength(1, ErrorMessage = "A Série deve ter 1 caractere.")]
        [RegularExpression("^[0-9]$", ErrorMessage = "A Série deve ser um número de 0 a 9.")]
        [Display(Name = "Série")]
        public string serie { get; set; }

        [Required(ErrorMessage = "O campo Turma é obrigatório.")]
        [Display(Name = "Turma")]
        public string turma { get; set; }

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
