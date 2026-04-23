using ControleDeContatos.Data;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;

public class UsuarioRepositorio : IUsuarioRepositorio
{
    private readonly BancoContext _context;

    public UsuarioRepositorio(BancoContext bancoContext)
    {
        _context = bancoContext;
    }

    public UsuarioModel BuscarPorLogin(string login)
    {
        return _context.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());

    }
    public UsuarioModel BuscarPorId(int id)
    {
        return _context.Usuarios.FirstOrDefault(x => x.Id == id);
    }

    public List<UsuarioModel> BuscarTodos()
    {
        return _context.Usuarios.ToList();
    }

    public UsuarioModel Adicionar(UsuarioModel usuario)
    {
        usuario.DataCadastro = DateTime.Now;
        usuario.SetSenhaHash();
        usuario.DataAtualizacao = DateTime.Now;

        _context.Usuarios.Add(usuario);
        _context.SaveChanges();

        return usuario;
    }

    public UsuarioModel Atualizar(UsuarioModel usuario)
    {
        UsuarioModel usuarioDB = BuscarPorId(usuario.Id);

        if (usuarioDB == null)
            throw new Exception("Usuário não encontrado.");

        usuarioDB.Nome = usuario.Nome;
        usuarioDB.Email = usuario.Email;
        usuarioDB.Login = usuario.Login;
        usuarioDB.Perfil = usuario.Perfil;
        usuarioDB.DataAtualizacao = DateTime.Now;

        _context.Usuarios.Update(usuarioDB);
        _context.SaveChanges();

        return usuarioDB;
    }

    public UsuarioModel Apagar(int id)
    {
        UsuarioModel usuarioDB = BuscarPorId(id);

        if (usuarioDB == null)
            throw new Exception("Usuário não encontrado.");

        _context.Usuarios.Remove(usuarioDB);
        _context.SaveChanges();

        return usuarioDB;
    }


    public UsuarioModel BuscarPorEmailELogin(string email, string login)
    {
        return _context.Usuarios
            .FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper()
                              && x.Login.ToUpper() == login.ToUpper());
    
    }
}

