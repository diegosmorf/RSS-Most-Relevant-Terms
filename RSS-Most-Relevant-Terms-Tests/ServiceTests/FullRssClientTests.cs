using System.Linq;
using Autofac;
using NUnit.Framework;
using RSS.Most.Relevant.Terms.Core;
using RSS.Most.Relevant.Terms.Core.Contracts;

namespace RSS.Most.Relevant.Terms.Tests.ServiceTests
{
    public class FullRssClient : BaseIntegrationTests
    {
        [Test]
        public void WhenConnectRss_ThenDownloadFeedsSucess()
        {
            //definitions
            var serviceRssReader = container.Resolve<IServiceRssReader>();
            var configuration = container.Resolve<ApplicationConfiguration>();
            var expectedCount = 0;
            //actions
            var rssData = serviceRssReader.GetFeeds(configuration.Url);
            
            //asserts
            Assert.IsNotNull(rssData);
            Assert.Greater(rssData.Count(), expectedCount);
        }

        [Test]
        public void WhenDownloadFeed_ThenGetFrequencyTop5()
        {
            //definitions
            var serviceRssReader = container.Resolve<IServiceRssReader>();
            var serviceFrequency = container.Resolve<IServiceWordsFrequency>();
            var configuration = container.Resolve<ApplicationConfiguration>();
            var expectedCount = 5;
            //actions
            var rssData = serviceRssReader.GetFeeds(configuration.Url);
            var result = serviceFrequency.GetTop5Words(rssData.First().Content);

            //asserts
            Assert.IsNotNull(rssData);
            Assert.Greater(rssData.Count(), 0);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), expectedCount);
        }

        [Test]
        public void WhenDownloadFeed_ThenGetFrequencyTop5Word()
        {
            //definitions
            var serviceRssReader = container.Resolve<IServiceRssReader>();
            var serviceFrequency = container.Resolve<IServiceWordsFrequency>();
            var configuration = container.Resolve<ApplicationConfiguration>();
            var expectedCount = 5;
            //actions
            var rssData = serviceRssReader.GetFeeds(configuration.Url);
            var result = serviceFrequency.GetTop5Words(rssData.First().Content);

            //asserts
            Assert.IsNotNull(rssData);
            Assert.Greater(rssData.Count(), 0);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), expectedCount);
            Assert.AreEqual("arstechnica", result.First().Word);
        }
    }
}
