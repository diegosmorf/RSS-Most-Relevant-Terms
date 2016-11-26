using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RSS.Most.Relevant.Terms.Core
{
    public class ServiceWordsFrequency : IServiceWordsFrequency
    {
        public IEnumerable<IFrequencyItem> GetTop5Words(string content)
        {
            const string expression = @"\W+";
            const int numberOfItems = 5;
            var listOfTop5 = new List<IFrequencyItem>();

            if (!string.IsNullOrEmpty(content))
            {
                var listTemp = Regex.Split(content.ToLower(), expression)
                    .Where(s => s.Length > 3)
                    .GroupBy(s => s)
                    .OrderByDescending(g => g.Count())
                    .Take(numberOfItems)
                    .ToList();

                foreach (var item in listTemp.Where(x => x.Count() > 1))
                    listOfTop5.Add(new FrequencyItem {Word = item.Key, Count = item.Count()});
            }

            return listOfTop5;
        }
    }
}