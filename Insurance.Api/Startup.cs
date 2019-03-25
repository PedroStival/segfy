using System.Net.Http.Formatting;
using System.Web.Http;
using Insurance.Api;
using Insurance.Startup;
using Microsoft.Owin;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Insurance.Api
{
    public partial class Startup
    {
        
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            // Configure Dependency Injection
            var container = new UnityContainer();
            DependencyResolver.Resolve(container);
            config.DependencyResolver = new UnityResolver(container);

            //ConfigureOAuth(app,container);

            ConfigureWebApi(config);
            //ConfigureOAuth(app, container.Resolve<IUserService>());

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);

        }

        public void ConfigureOAuth(IAppBuilder app, UnityContainer container)
        {
        }

        public static void ConfigureWebApi(HttpConfiguration config)
        {
            // Remove o XML
            var formatters = config.Formatters;
            formatters.Clear();
            formatters.Add(new JsonMediaTypeFormatter());
            // Modifica a identação
            var jsonSettings = formatters.JsonFormatter.SerializerSettings;
            jsonSettings.Formatting = Formatting.Indented;
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Modifica a serialização
            //formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling =
            //    PreserveReferencesHandling.Objects;
            formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;


            //config.MessageHandlers.Add(new CorsHandler());
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }
    }
}