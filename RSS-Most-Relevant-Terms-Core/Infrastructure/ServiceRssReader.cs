using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using RSS.Most.Relevant.Terms.Core.Contracts;

namespace RSS.Most.Relevant.Terms.Core
{
    public class ServiceRssReader : IServiceRssReader
    {
        private XDocument document;

        public bool OpenConnection(string url)
        {
            try
            {
                if (string.IsNullOrEmpty(url))
                    return false;

                document = XDocument.Load(url);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<IFeedItem> GetFeeds(string url)
        {
            OpenConnection(url);
            XNamespace nm = @"http://purl.org/rss/1.0/modules/content/";
            var listOfFeeds = new List<IFeedItem>();

            var items = document.Descendants("item").Select(i => new
            {
                Title = (string) i.Element("title"),
                Description = (string) i.Element("description"),
                Link = (string) i.Element("link"),
                Content = (string) i.Element(nm + "encoded")
            }).ToArray();

            foreach (var item in items)
                listOfFeeds.Add(new FeedItem
                {
                    Title = item.Title,
                    Content = item.Content
                });

            return listOfFeeds;
        }
    }
}