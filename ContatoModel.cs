using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class ContatoModel
    {
        // Propriedades já esperadas pelo formulário Criar.cshtml
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O celular é obrigatório")]
        public string Celular { get; set; }

        // FIX: adicionar a propriedade 'Perfil' que está faltando e causa CS1061
        // Ajuste o tipo/validação conforme sua necessidade (string neste exemplo)
        public string Perfil { get; set; }

        // Endereço
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }

        [StringLength(2, ErrorMessage = "Use a sigla do estado (ex: PE)")]
        public string Estado { get; set; }

        [RegularExpression(@"\d{5}-\d{3}", ErrorMessage = "CEP no formato 00000-000")]
        public string Cep { get; set; }
    }
}   