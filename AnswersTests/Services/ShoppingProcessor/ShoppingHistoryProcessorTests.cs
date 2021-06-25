using NUnit.Framework;
using Answers.Services.Interfaces.ShoppingProcessor;
using System;
using System.Collections.Generic;
using System.Text;
using Answers.Extensions;

namespace Answers.Services.Interfaces.ShoppingProcessor.Tests
{
    [TestFixture()]
    public class ShoppingHistoryProcessorTests
    {
        string productjsonstring;
        List<KeyValuePair<string, double>> out_lst;

        private ShoppingHistoryProcessor shoppingHistoryProcessor;
        [SetUp]
        public void SetUp()
        {
            out_lst = new List<KeyValuePair<string, double>>();
            shoppingHistoryProcessor = new ShoppingHistoryProcessor();
            out_lst.Add(new KeyValuePair<string, double>("Test Product A", 3));
            productjsonstring = "[{\"customerId\":123,\"products\":[{\"name\":\"Test Product A\",\"price\":99.99,\"quantity\":3.0}]}]";
        }
        [Test()]
        public void ProcessShoppingHistoryForProductOccuranceTest()
        {
            var result = shoppingHistoryProcessor.ProcessShoppingHistoryForProductOccurance(productjsonstring);
            Assert.IsTrue(result.Result.CompareKeyValue(out_lst));
        }
    }
}