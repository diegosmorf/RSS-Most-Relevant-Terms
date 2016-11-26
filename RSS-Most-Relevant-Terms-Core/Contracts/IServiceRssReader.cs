using System.Collections.Generic;

namespace RSS.Most.Relevant.Terms.Core.Contracts
{
    public interface IServiceRssReader
    {
        bool OpenConnection(string url);
        IEnumerable<IFeedItem> GetFeeds(string url);
    }
}