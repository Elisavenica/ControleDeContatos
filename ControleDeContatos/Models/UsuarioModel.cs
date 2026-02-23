using ControleDeContatos.Enums;
using System.ComponentModel.DataAnnotations;

public class UsuarioModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Digite o Nome do usuário")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Digite o login do usuário")]
    public string Login { get; set; }

    [Required(ErrorMessage = "Digite o e-mail do usuário!")]
    public string Email { get; set; }

    // 🔴 TIRE O ?
    [Required(ErrorMessage = "Informe o perfil do usuário")]
    public PerfilEnum Perfil { get; set; }

    [Required(ErrorMessage = "Digite a senha do usuário")]
    public string Senha { get; set; }
    public DateTime DataCadastro { get; internal set; }
    public DateTime DataAtualizacao { get; internal set; }
}
