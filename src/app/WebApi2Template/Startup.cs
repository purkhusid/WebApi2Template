using System;
using System.Configuration;
using System.IdentityModel.Tokens;
using System.Web.Http.Dispatcher;
using Castle.Core;
using Castle.Windsor;
using Owin;
using WebApi2Template.Infrastructure;

namespace WebApi2Template
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            JwtSecurityTokenHandler.InboundClaimTypeMap.Clear();

            var config = WebApiConfig.Create();

            config.Services.Replace(typeof(IHttpControllerActivator),
                new WindsorCompositionRoot(CreateContainer()));

            app.UseWebApi(config);
        }

        private static WindsorContainer CreateContainer()
        {
            var container = new WindsorContainer();

            var settings = new ApiSettings()
            {
                LifestyleType = LifestyleType.PerWebRequest,
            };

            container.Install(new OrderApiInstaller(settings));
            return container;
        }
    }
}
