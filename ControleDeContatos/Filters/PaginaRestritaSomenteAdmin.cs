using ControleDeContatos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System.Text.Json;

namespace ControleDeContatos.Filters
{
    public class PaginaRestritaSomenteAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string sessaoUsuario = context.HttpContext.Session.GetString("SessaoUsuarioLogado"); // 🔥 corrigido

            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "controller", "Login" },
                    { "action", "Index" }
                });
                return; // 🔥 ESSENCIAL
            }

            UsuarioModel? usuario = JsonSerializer.Deserialize<UsuarioModel>(sessaoUsuario);

            if (usuario == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "controller", "Login" },
                    { "action", "Index" }
                });
                return; // 🔥 ESSENCIAL
            }

            if (usuario.Perfil != Enums.PerfilEnum.Admin)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "controller", "Restrito" },
                    { "action", "Index" }
                });
                return; // 🔥 ESSENCIAL
            }

            base.OnActionExecuting(context);
        }
    }
}