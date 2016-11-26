namespace RSS.Most.Relevant.Terms.Core
{
    public interface IFrequencyItem
    {
        string Word { get; set; }
        int Count { get; set; }
    }
}