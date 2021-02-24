using Microsoft.Owin;
using Owin;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Web.Http;

[assembly: OwinStartup(typeof(SelfHost_WebApi.Startup))]
namespace SelfHost_WebApi
{
    public class Startup
    {
        public static Queue<string> command = new Queue<string>();

        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
           );

           app.UseWebApi(config);
        }
    }
}
