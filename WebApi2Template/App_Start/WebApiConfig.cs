using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Newtonsoft.Json.Serialization;
using Swashbuckle.Application;

namespace WebApi2Template
{
    public static class WebApiConfig
    {
        public static HttpConfiguration Create()
        {
            var config = new HttpConfiguration();

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.Filters.Add(new AuthorizeAttribute());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.EnableCors();

            //Swagger config
            config
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "Order Api");
                    c.UseFullTypeNameInSchemaIds();
                    c.DescribeAllEnumsAsStrings();
                    c.IncludeXmlComments(GetXmlCommentsPath());
                })
                .EnableSwaggerUi();

            return config;
        }

        private static string GetXmlCommentsPath()
        {
            return string.Format(@"{0}\WebApi2Template.XML",
                System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
