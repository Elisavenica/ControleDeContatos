using ControleDeContatos.Enums;
using System;   

namespace ControleDeContatos.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; } 
        public string Rua { get; set; } 
        public string Numero { get; set; } 
        public string Bairro { get; set; } 
        public string rua { get; set; } 
        public string Cidade { get; set; } 
        public string Estado { get; set; } 
        public string Cep { get; set; } 
        public PerfilEnum Perfil { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }



    }
}
