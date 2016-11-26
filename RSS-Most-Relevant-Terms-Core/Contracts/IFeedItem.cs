namespace RSS.Most.Relevant.Terms.Core
{
    public interface IFeedItem
    {
        string Author { get; set; }
        string Title { get; set; }
        string Content { get; set; }
    }
}