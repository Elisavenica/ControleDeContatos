using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ControleDeContatos.Models;
using System.Text.Json;

namespace ControleDeContatos.Filters
{
    public class PaginaParaUsuarioLogado : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.RouteData.Values["controller"]?.ToString();

            // libera login
            if (controller == "Login")
            {
                return;
            }

            string sessaoUsuario = context.HttpContext.Session.GetString("SessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "controller", "Login" },
                    { "action", "Index" }
                });
                return;
            }

            UsuarioModel? usuario = JsonSerializer.Deserialize<UsuarioModel>(sessaoUsuario);

            if (usuario == null)
            {
                context.HttpContext.Session.Clear();

                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "controller", "Login" },
                    { "action", "Index" }
                });
            }

            base.OnActionExecuting(context);
        }
    }
}