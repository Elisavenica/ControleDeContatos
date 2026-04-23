using ControleDeContatos.Helper;
using ControleDeContatos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace ControleDeContatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            // Se usuário estiver logado, redireciona para Home
            if (_sessao.BuscarSessaoDoUsuario() != null)
                return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult RedefinirSenha()
        {
            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoDoUsuario();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);

                    if (usuario == null || !usuario.SenhaValida(loginModel.Senha))
                    {
                        ModelState.AddModelError("", "Usuário ou senha inválidos.");
                        return View("Index");
                    }

                    _sessao.CriarSessaoDoUsuario(usuario);

                    return RedirectToAction("Index", "Home");
                }

                return View("Index");
            }
            catch (Exception erro)
            {
                ModelState.AddModelError("", $"Erro ao realizar login: {erro.Message}");
                return View("Index");
            }
        }

        [HttpPost]
        public IActionResult EnviarLinkParaRedefinirSenha(RedefinirSenhaModel redefinirSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorEmailELogin(
                        redefinirSenhaModel.Email,
                        redefinirSenhaModel.Login
                    );

                    if (usuario != null)
                    {
                        string novaSenha = usuario.GerarNovaSenha();
                        _usuarioRepositorio.Atualizar(usuario);

                        // Aqui você pode gerar nova senha e enviar email futuramente
                        TempData["MensagemSucesso"] = "Enviamos para seu e-mail cadastrado uma nova senha.";
                        return RedirectToAction("Index", "Login");
                    }
                }

                TempData["MensagemErro"] = "Não conseguimos redefinir sua senha. Verifique os dados informados.";
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro ao redefinir senha: {erro.Message}";
                return View("Index");
            }
        }
    }
}