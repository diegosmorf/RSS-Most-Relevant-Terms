using System.Collections.Generic;

namespace RSS.Most.Relevant.Terms.Core
{
    public interface IServiceWordsFrequency
    {
        IEnumerable<IFrequencyItem> GetTop5Words(string content);
    }
}