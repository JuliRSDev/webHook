

using System.Web.Http;
using WbHooksCroydon.Handlers;

namespace WbHooksCroydon
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.InitializeDafitiWebHookReciver();
            //config.InitializeLinioWebHookReciver();
        }
    }
}
