using System.Linq;
using Autofac;
using NUnit.Framework;
using RSS.Most.Relevant.Terms.Core;

namespace RSS.Most.Relevant.Terms.Tests.ServiceTests
{
    public class WordFrequencyTests : BaseIntegrationTests
    {
        [Test]
        public void WhenContentEmpty_ThenFrequencyEmpty()
        {
            //definitions
            var service = container.Resolve<IServiceWordsFrequency>();
            var content = @"";
            var expectedNumberOfResults = 0;
            //actions
            var result = service.GetTop5Words(content);
            //asserts
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedNumberOfResults, result.Count());
        }

        [Test]
        public void WhenContentMoreThan5RepeatedWords_ThenFrequencyTop5()
        {
            //definitions
            var service = container.Resolve<IServiceWordsFrequency>();
            var content =
                @"For example. We generate all our HTML in code. Yes, you read that correctly. We write Java code that constructs HTML. And yes, that means we are slinging angle brackets around.
                            To be fair, we’ve managed to move most of the angle bracket slingers into a single module that hides the HTML construction behind an abstraction barrier. This helps a lot, but cripe who would sling angle brackets when template system are so prevalent? I hope nobody. But FitNesse was not conceived at a time when template systems made sense (at least to us).
                            Fear not, I am working through the Fitnesse code replacing the HTML generation with Velocity templates. It’ll take some time, but I’ll get it done. The point is, that just like every other software system you’ve seen, FitNesse is a collection of historical compromises. The architecture shows the scars of many decisions that have since had to be reversed or deeply modified.";
            var expectedNumberOfResults = 5;
            //actions
            var result = service.GetTop5Words(content);
            //asserts
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedNumberOfResults, result.Count());
        }

        [Test]
        public void WhenContentMoreThan5RepeatedWords_ThenFrequencyTop5Count()
        {
            //definitions
            var service = container.Resolve<IServiceWordsFrequency>();
            var content =
                @"For example. We generate all our HTML in code. Yes, you read that correctly. We write Java code that constructs HTML. And yes, that means we are slinging angle brackets around.
                            To be fair, we’ve managed to move most of the angle bracket slingers into a single module that hides the HTML construction behind an abstraction barrier. This helps a lot, but cripe who would sling angle brackets when template system are so prevalent? I hope nobody. But FitNesse was not conceived at a time when template systems made sense (at least to us).
                            Fear not, I am working through the Fitnesse code replacing the HTML generation with Velocity templates. It’ll take some time, but I’ll get it done. The point is, that just like every other software system you’ve seen, FitNesse is a collection of historical compromises. The architecture shows the scars of many decisions that have since had to be reversed or deeply modified.";
            var expectedCount = 6;
            //actions
            var result = service.GetTop5Words(content);
            //asserts
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedCount, result.First().Count);
        }

        [Test]
        public void WhenContentMoreThan5RepeatedWords_ThenFrequencyTop5Word()
        {
            //definitions
            var service = container.Resolve<IServiceWordsFrequency>();
            var content =
                @"For example. We generate all our HTML in code. Yes, you read that correctly. We write Java code that constructs HTML. And yes, that means we are slinging angle brackets around.
                            To be fair, we’ve managed to move most of the angle bracket slingers into a single module that hides the HTML construction behind an abstraction barrier. This helps a lot, but cripe who would sling angle brackets when template system are so prevalent? I hope nobody. But FitNesse was not conceived at a time when template systems made sense (at least to us).
                            Fear not, I am working through the Fitnesse code replacing the HTML generation with Velocity templates. It’ll take some time, but I’ll get it done. The point is, that just like every other software system you’ve seen, FitNesse is a collection of historical compromises. The architecture shows the scars of many decisions that have since had to be reversed or deeply modified.";
            var expectedWord = "that";
            //actions
            var result = service.GetTop5Words(content);
            //asserts
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedWord, result.First().Word);
        }

        [Test]
        public void WhenContentMoreThan5WordsBut1Repeated_ThenFrequencyTop1()
        {
            //definitions
            var service = container.Resolve<IServiceWordsFrequency>();
            var content = @"RSS Most Relevant Terms Tests Service Tests";
            var expectedNumberOfResults = 1;
            //actions
            var result = service.GetTop5Words(content);
            //asserts
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedNumberOfResults, result.Count());
        }

        [Test]
        public void WhenContentWith3EqualsWords_ThenFrequencyTop1()
        {
            //definitions
            var service = container.Resolve<IServiceWordsFrequency>();
            var content = @"Tests Tests Tests";
            var expectedNumberOfResults = 1;
            //actions
            var result = service.GetTop5Words(content);
            //asserts
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedNumberOfResults, result.Count());
        }
    }
}