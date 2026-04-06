using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ControleDeContatos.Models;
using System.Text.Json;

namespace ControleDeContatos.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string? sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario))
                return Content("");

            UsuarioModel? usuario = JsonSerializer.Deserialize<UsuarioModel>(sessaoUsuario);

            if (usuario == null)
                return Content("");

            return View(usuario);
        }
    }
}