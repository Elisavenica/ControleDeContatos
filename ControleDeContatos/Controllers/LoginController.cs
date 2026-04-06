using ControleDeContatos.Helper;
using ControleDeContatos.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;
        public LoginController(IUsuarioRepositorio usuarioRepositorio,
            ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            //Se isiario estiver logado, redirecionar para a home
            if(_sessao.BuscarSessaoDoUsuario() !=null) return RedirectToAction("Index", "Home");

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

                    // Se usuário não existir OU senha estiver errada
                    if (usuario == null || !usuario.SenhaValida(loginModel.Senha))
                    {
                        ModelState.AddModelError("", "Usuário ou senha inválidos.");
                        return View("Index");
                    }

                    // ✅ Aqui sim cria a sessão (login correto)
                    _sessao.CriarSessaoDoUsuario(usuario);

                    return RedirectToAction("Index", "Home");

                 ;
                }

                return View("Index");
            }
            catch (Exception erro)
            {
                ModelState.AddModelError("", $"Erro ao realizar login: {erro.Message}");
                return View("Index");
            }
        }
    }
    
}