namespace RSS.Most.Relevant.Terms.Core
{
    public class FeedItem : IFeedItem
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}