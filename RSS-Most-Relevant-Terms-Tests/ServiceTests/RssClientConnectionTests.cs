using Autofac;
using NUnit.Framework;
using RSS.Most.Relevant.Terms.Core;
using RSS.Most.Relevant.Terms.Core.Contracts;

namespace RSS.Most.Relevant.Terms.Tests.ServiceTests
{
    public class RssClientConnectionTests : BaseIntegrationTests
    {
        [Test]
        public void WhenConnectRssUrl_ThenConnectionSucess()
        {
            //definitions
            var serviceRssReader = container.Resolve<IServiceRssReader>();
            var configuration = container.Resolve<ApplicationConfiguration>();
            //actions
            var result = serviceRssReader.OpenConnection(configuration.Url);
            //asserts
            Assert.IsTrue(result);
        }

        [Test]
        public void WhenConnectRssWrongUrl_ThenConnectionFailed()
        {
            //definitions
            var serviceRssReader = container.Resolve<IServiceRssReader>();
            var configuration = container.Resolve<ApplicationConfiguration>();
            //actions
            var result = serviceRssReader.OpenConnection(configuration.Url + "WrongURL");
            //asserts
            Assert.IsFalse(result);
        }
    }
}