using ControleDeContatos.Models;

public interface IUsuarioRepositorio
{
    UsuarioModel BuscarPorLogin(string login);  
    List<UsuarioModel> BuscarTodos();
    UsuarioModel BuscarPorId(int id);
    UsuarioModel Adicionar(UsuarioModel usuario);
    UsuarioModel Atualizar(UsuarioModel usuario);
    UsuarioModel Apagar(int id);
    UsuarioModel BuscarPorId(object id);
}
