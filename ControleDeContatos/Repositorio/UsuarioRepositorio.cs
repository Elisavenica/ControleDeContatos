using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _context;

        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _context = bancoContext;
        }

        public UsuarioModel ListarPorId(int id)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _context.Usuarios.ToList();
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            if (usuario == null)
                throw new Exception("Os dados do usuário não podem ser nulos.");

            usuario.DataCadastro = DateTime.Now;
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            if (usuario == null)
                throw new Exception("Os dados do usuário não podem ser nulos.");

            UsuarioModel usuarioDB = ListarPorId(usuario.Id);

            if (usuarioDB == null)
                throw new Exception("Houve um erro na atualização do usuário.");

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Celular = usuario.Celular;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataAtualizacao = DateTime.Now;

            usuarioDB.Rua = usuario.Rua;
            usuarioDB.Numero = usuario.Numero;
            usuarioDB.Bairro = usuario.Bairro;
            usuarioDB.Cidade = usuario.Cidade;
            usuarioDB.Estado = usuario.Estado;
            usuarioDB.Cep = usuario.Cep;

            _context.Usuarios.Update(usuarioDB);
            _context.SaveChanges();

            return usuarioDB;
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDB = ListarPorId(id);

            if (usuarioDB == null)
                throw new Exception("Houve um erro ao tentar deletar usuário.");

            _context.Usuarios.Remove(usuarioDB);
            _context.SaveChanges();

            return true;
        }
    }
}
