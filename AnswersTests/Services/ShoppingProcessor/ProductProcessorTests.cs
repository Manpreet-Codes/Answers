using NUnit.Framework;
using Answers.Services.Interfaces.ShoppingProcessors;
using System;
using System.Collections.Generic;
using System.Text;
using Answers.Services.Interfaces.Data;
using Moq;
using Answers.Modal;
using System.Threading.Tasks;
using Answers.Extensions;

namespace Answers.Services.Interfaces.ShoppingProcessors.Tests
{    

    [TestFixture()]
    public class ProductProcessorTests
    {
        private Mock<IHttpDataService> httpDataServiceMock;
        List<Product> products;
        private ProductProcessor productProcessor;

        [SetUp]
        public void SetUp()
        {
            httpDataServiceMock = new Mock<IHttpDataService>();
            products = new List<Product>();
            string productjsonstring = "[{\"name\":\"Test Product A\",\"price\":99.99,\"quantity\":3.0}]";
            products.Add(new Product() { name = "Test Product A", price = 99.99, quantity = 3.0 });

            httpDataServiceMock.Setup(p => p.GetRequest(It.IsAny<string>())).Returns(Task.FromResult(productjsonstring));

            productProcessor = new ProductProcessor(httpDataServiceMock.Object);

        }

        [Test()]
        public void ProcessProductsTest()
        {
            var prods = productProcessor.ProcessProducts();

            Assert.IsTrue(prods.Result.CompareProductList(products));
        }
    }
}