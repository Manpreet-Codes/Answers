using Answers.Extensions;
using Answers.Modal;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Answers.Services.Interfaces.ProductSorting.Tests
{
    [TestFixture()]
    public class ProductSortingServiceLowPriceTests
    {
        List<Product> products;
        List<Product> out_products;

        ProductSortingServiceLowPrice productSortingServiceLowPrice;

        [SetUp]
        public void SetUp()
        {
            products = new List<Product>();
            out_products = new List<Product>();

            products.Add(new Product() { name = "Proct B", price = 10, quantity = 0 });
            products.Add(new Product() { name = "Proct A", price = 20, quantity = 0 });
            products.Add(new Product() { name = "Proct C", price = 30, quantity = 0 });

            out_products.Add(new Product() { name = "Proct B", price = 10, quantity = 0 });
            out_products.Add(new Product() { name = "Proct A", price = 20, quantity = 0 });
            out_products.Add(new Product() { name = "Proct C", price = 30, quantity = 0 });

            productSortingServiceLowPrice = new ProductSortingServiceLowPrice();
        }

        [Test()]
        public void SortProductDataTest()
        {
            var result = productSortingServiceLowPrice.SortProductData(products);
            Assert.IsTrue(result.Result.CompareProductList(out_products));
        }
    }
}
