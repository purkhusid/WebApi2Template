using System;
using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace WebApi2Template.Infrastructure
{
    public class OrderApiInstaller : IWindsorInstaller
    {
        private readonly ApiSettings settings;

        public OrderApiInstaller(ApiSettings settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            this.settings = settings;
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));

            //Web
            container.Register(Classes.FromThisAssembly().BasedOn<ApiController>()
                .Configure(x => x.LifeStyle.Is(settings.LifestyleType)));
        }
    }
}
