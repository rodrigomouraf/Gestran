using System.ComponentModel.DataAnnotations;

namespace Gestran.Models
{
    public struct Endereco
    {
        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "O formato do CEP é inválido.")]
        public string Cep { get; set; }
        
        [Required(ErrorMessage = "A rua é obrigatória.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "A rua deve ter entre 5 e 100 caracteres.")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "O número é obrigatorio.")]
        public int Numero { get; set; }

        [StringLength(50, ErrorMessage = "O complemento não pode ter mais que 50 caracteres.")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "A cidade é obrigatória.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "A cidade deve ter entre 2 e 50 caracteres.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O estado é obrigatório.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O estado deve ter 2 caracteres.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O país é obrigatório.")]
        [StringLength(50, ErrorMessage = "O país não pode ter mais que 50 caracteres.")]
        public string Pais { get; set; }

        public Endereco(string cep, string rua, int numero, string complemento, string cidade, string estado, string pais)
        {
            Cep = cep;
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
        }
    }
}

