using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace freeCommerce
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "produtos",
                "produtos",
                new { controller = "Produtos", action = "Index" }
            );

            routes.MapRoute(
                "produtos-cadastro",
                "produtos/cadastro",
                new { controller = "Produtos", action = "Cadastro" }
            );

            routes.MapRoute(
                "produtos-criar",
                "produtos/criar",
                new { controller = "Produtos", action = "Criar" }
            );

            routes.MapRoute(
                "produto-detalhes",
                "produtos/detalhes/{id}",
                new { controller = "Produtos", action = "Detalhes" }
            );

            routes.MapRoute(
                "produtos-anexar",
                "produtos/anexar/imagem",
                new { controller = "Produtos", action = "Anexar" }
            );

            routes.MapRoute(
                "autenticacao-cadastro",
                "autenticacao/cadastro",
                new { controller = "Autenticacao", action = "Cadastro" }
            );

            routes.MapRoute(
                "autenticacao-criar",
                "autenticacao/criar",
                new { controller = "Autenticacao", action = "Criar" }
            );

            routes.MapRoute(
                "autenticacao-logar",
                "autenticacao/logar",
                new { controller = "Autenticacao", action = "Logar" }
            );

            routes.MapRoute(
                "autenticacao-conta",
                "autenticacao/minhaconta",
                new { controller = "Autenticacao", action = "Conta" }
            );

            routes.MapRoute(
                "autenticacao-desconecta",
                "autenticacao/desconecta",
                new { controller = "Autenticacao", action = "Desconecta" }
            );

            routes.MapRoute(
                "autenticacao-login",
                "autenticacao/login",
                new { controller = "Autenticacao", action = "Login" }
            );

            

            routes.MapRoute(
                "produtos-anexar-porId",
                "produtos/{id}/anexar",
                new { controller = "Produtos", action = "AnexarPorId", id = 0 }
            );

            

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
