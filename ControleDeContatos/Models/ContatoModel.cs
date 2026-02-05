using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o Nome do contato")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o e-mail do contato")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido!")]
        public string Email { get; set; }
      

        [Required(ErrorMessage = "Digite o Celular do contato")]
        [Phone(ErrorMessage = "O celular informado não é válido!")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Digite o Estado do contato")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Digite a Cidade do contato")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Digite o Cep do contato")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Digite o Bairro do contato")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Digite a Rua do contato")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Digite o Número do contato")]
        public string Numero { get; set; }
    }
}
