using System.ComponentModel.DataAnnotations;

namespace Gestran.Models
{
    public class Fornecedor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O e-mail não pode ter mais que 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório")]
        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$", ErrorMessage = "CNPJ inválido.")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage = "Telefone inválido.")]
        public string Telefone { get; set; }
        
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Endereço de email inválido.")]
        [StringLength(100, ErrorMessage = "O e-mail não pode ter mais que 100 caracteres.")]
        public string Email { get; set; }
        
        public ICollection<Endereco>? Enderecos { get; set; }
    }    
}