using Castle.Core;

namespace WebApi2Template.Infrastructure
{
    public class ApiSettings
    {
        public LifestyleType LifestyleType { get; set; }
        public string MasterLogConnectionString { get; set; }

        public bool IsProduction { get; set; }
    }
}
