using ControleDeContatos.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o Nome do usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o Login do usuário")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite o e-mail do usuário")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o Celular do usuário")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Digite a Rua do usuário")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Digite o Número do usuário")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Digite o Bairro do usuário")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Digite a Cidade do usuário")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Digite o Estado do usuário")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Digite o Cep do usuário")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Selecione o perfil do usuário")]
        public PerfilEnum Perfil { get; set; }

        [Required(ErrorMessage = "Digite a senha do usuário")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Digite a DataCadastro do usuário")]
        public DateTime DataCadastro { get; set; }

        // DataAtualizacao é opcional (nullable) conforme assinatura; não obrigatória por padrão.
        public DateTime? DataAtualizacao { get; set; }
    }
}       
