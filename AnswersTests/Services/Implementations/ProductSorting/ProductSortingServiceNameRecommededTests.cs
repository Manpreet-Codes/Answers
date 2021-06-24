using NUnit.Framework;
using Answers.Services.Interfaces.ProductSorting;
using System;
using System.Collections.Generic;
using System.Text;
using Answers.Services.Interfaces.Data;
using Moq;
using Answers.Services.Interfaces.ShoppingProcessor;
using System.Threading.Tasks;
using Answers.Modal;
using System.Linq;

namespace Answers.Services.Interfaces.ProductSorting.Tests
{
    [TestFixture()]
    public class ProductSortingServiceNameRecommededTests
    {
        ProductSortingServiceNameRecommeded productSortingServiceNameRecommeded;
        Mock<IHttpDataService> httpDataServiceMock = new Mock<IHttpDataService>();
        Mock<IShoppingHistoryProcessor> shoppingHistoryProcessorMock = new Mock<IShoppingHistoryProcessor>();

        string productjsonstring;
        List<KeyValuePair<string, double>> out_lst = new List<KeyValuePair<string, double>>();
        
        List<Product> products = new List<Product>();
        List<Product> out_products = new List<Product>();

        [SetUp]
        public void SetUp()
        {
            //Setup Data
            out_lst.Add(new KeyValuePair<string, double>("Proct A", 9));
            out_lst.Add(new KeyValuePair<string, double>("Proct B", 7));
            //out_lst.Add(new KeyValuePair<string, double>("Proct C", 9));

            
            products.Add(new Product() { name = "Proct B", price = 0, quantity = 0 });
            products.Add(new Product() { name = "Proct A", price = 0, quantity = 0 });
            products.Add(new Product() { name = "Proct C", price = 0, quantity = 0 });

            out_products.Add(new Product() { name = "Proct A", price = 0, quantity = 0 });
            out_products.Add(new Product() { name = "Proct B", price = 0, quantity = 0 });
            out_products.Add(new Product() { name = "Proct C", price = 0, quantity = 0 });

            productjsonstring = "[{\"customerId\":123,\"products\":[{\"name\":\"Test Product A\",\"price\":99.99,\"quantity\":3.0}]}]";

            var historyUrl = "http://dev-wooliesx-recruitment.azurewebsites.net/api/resource/shopperHistory?token=eb848457-3d00-454f-9270-4490790cea30";

            httpDataServiceMock.Setup(p => p.GetRequest(historyUrl)).Returns(Task.FromResult(productjsonstring));
            shoppingHistoryProcessorMock.
                Setup(p => p.ProcessShoppingHistoryForProductOccurance(It.IsAny<List<ShoppingHistory>>())).Returns(Task.FromResult(out_lst));

            productSortingServiceNameRecommeded =
            new ProductSortingServiceNameRecommeded(httpDataServiceMock.Object, shoppingHistoryProcessorMock.Object);
        }

        [Test()]
        public void SortProductDataTest()
        {
            var result = productSortingServiceNameRecommeded.SortProductData(products);

            var lst = result.Result;

            
            

            Assert.IsTrue(lst.SequenceEqual( out_products)) ;
            
        }
    }
}