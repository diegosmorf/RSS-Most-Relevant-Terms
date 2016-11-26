using Autofac;
using RSS.Most.Relevant.Terms.Core;

namespace RSS.Most.Relevant.Terms.Tests
{
    public class IocInfrastructure : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Configuration
            var configuration = new ApplicationConfiguration
            {
                Url = @"http://feeds.arstechnica.com/arstechnica/technology-lab"
            };

            builder.RegisterType<ServiceRssReader>().AsImplementedInterfaces();
            builder.RegisterType<ServiceWordsFrequency>().AsImplementedInterfaces();
            builder.RegisterInstance(configuration);

            base.Load(builder);
        }
    }
}