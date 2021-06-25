using NUnit.Framework;
using Answers.Services.Interfaces.ProductSorting;
using System;
using System.Collections.Generic;
using System.Text;
using Answers.Modal;
using Answers.Extensions;

namespace Answers.Services.Interfaces.ProductSorting.Tests
{
    [TestFixture()]
    public class ProductSortingServiceHighPriceTests
    {
        List<Product> products;
        List<Product> out_products;

        ProductSortingServiceHighPrice productSortingServiceHighPrice;

        [SetUp]
        public void SetUp()
        {
            products = new List<Product>();
            out_products = new List<Product>();

            products.Add(new Product() { name = "Proct B", price = 10, quantity = 0 });
            products.Add(new Product() { name = "Proct A", price = 20, quantity = 0 });
            products.Add(new Product() { name = "Proct C", price = 30, quantity = 0 });

            out_products.Add(new Product() { name = "Proct C", price = 30, quantity = 0 });
            out_products.Add(new Product() { name = "Proct A", price = 20, quantity = 0 });
            out_products.Add(new Product() { name = "Proct B", price = 10, quantity = 0 });

            productSortingServiceHighPrice = new ProductSortingServiceHighPrice();
        }

        [Test()]
        public void SortProductDataTest()
        {
            var result = productSortingServiceHighPrice.SortProductData(products);
            Assert.IsTrue(result.Result.CompareProductList(out_products));
        }
    }
}