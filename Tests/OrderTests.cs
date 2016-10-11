using Bangazon.Orders;
using System;
using System.Collections.Generic;
using Xunit;

namespace Bangazon.Tests
{
    public class OrderTests
    {
        [Fact]
        public void TestTheTesingFramework(){
            Assert.True(true);
        }
        [Fact]
        public void OrdersCanExist()
        {
            Order ord = new Order();
            Assert.NotNull(ord);
        }
        [Fact]
        public void NewOrderHaveGuid()
        {
            Order ord = new Order();
            Assert.NotNull(ord.orderNumber);
            Assert.IsType<Guid>(ord.orderNumber);
            
        }
        [Fact]
        public void NewOrderShouldHaveAnEmptyProductListOfStrings()
        {
            Order ord = new Order();
            Assert.NotNull(ord.products);
            Assert.IsType<List<string>>(ord.products);
            Assert.Empty(ord.products);
        }
        [Theory]
        [InlineDataAttribute("Banana")]
        [InlineDataAttribute("6826476492")]
        [InlineDataAttribute("A product with space")]
        [InlineDataAttribute("Product, that has a, comma")]
        public void OrdersCanHaveProductsAddedToThem(string product){
            Order ord = new Order();
            ord.addProduct(product);
            Assert.Equal(1, ord.products.Count);
            Assert.Contains<string>(product, ord.products);

        }
        [Theory]
        [InlineDataAttribute("Product")]
        [InlineDataAttribute("Product,another product")]
        [InlineDataAttribute("A first product,someother,yet another")]
        [InlineDataAttribute("Prod 1,Prod 2,Prod 3,Prod 4")]
        public void OrdersCanHaveMultipleProductsAddedToThem(string productsStr)
        {
            string[] products = productsStr.Split(new char[] { ','});
            Order ord = new Order();
            foreach(string product in products)
            {
              ord.addProduct(product);
            }
            Assert.Equal(products.Length, ord.products.Count);
            foreach(string product in products)
            {
              Assert.Contains<string>(product, ord.products);
            }
            
        }
        [Theory]
        [InlineDataAttribute("Product")]
        [InlineDataAttribute("Product,another product")]
        [InlineDataAttribute("A first product,someother,yet another")]
        [InlineDataAttribute("Prod 1,Prod 2,Prod 3,Prod 4")]
        public void OrdersCanListProductsForTerminalDisplay(string productsStr)
        {
            string[] products = productsStr.Split(new char[] { ','});
            Order ord = new Order();
            foreach(string product in products)
            {
              ord.addProduct(product);
            }
            Assert.Equal(products.Length, ord.products.Count);
            foreach(string product in products)
            {
              Assert.Contains($"\nYou ordered {product}", ord.listProducts());
            }
            
        }
        [Fact]
        public void OrdersCanHaveProductsReovedFromThem()
        {
             Order ord = new Order();
            ord.addProduct("Product");
            ord.addProduct("Banana");
            ord.addProduct("Honeydrew Melon");

            ord.removeProduct("Banana");
            
            Assert.Equal(2, ord.products.Count);
            Assert.DoesNotContain<string>("Banana", ord.products);
        }
        [Fact]
        public void OrdersCanNotRemovProductsThatDoesnotExsistFromThem()
        {
             Order ord = new Order();
            ord.addProduct("Product");
            ord.addProduct("Banana");
            ord.addProduct("cake");
            ord.addProduct("Honeydrew Melon");

            ord.removeProduct("Pineapple");
            
            Assert.Equal(4, ord.products.Count);
        }
        [Theory]
        [InlineDataAttribute("Banana")]
        [InlineDataAttribute("Pineapple")]
        public void RemoveMethodeReturnBooleanIndicatingIfProductWasRemoved(string product)
        {
            Order ord = new Order();
            ord.addProduct("BAnana Bread");
            ord.addProduct("Product");
            ord.addProduct("Banana");
            ord.addProduct("Honeydrew Melon");

            bool removed = ord.removeProduct(product);
            if (product == "Banana")
            {
              Assert.True(removed);
            }
            if (product == "Pineapple")
            {
              Assert.False(removed);
            }
            
        }
        [Fact]
        public void AllProductsFromOrderCanbeDeleted()
        {
            Order ord = new Order();
            ord.addProduct("BAnana Bread");
            ord.addProduct("Product");
            ord.addProduct("Banana");
            ord.addProduct("Honeydrew Melon");

            ord.removeProduct();

            Assert.Empty(ord.products);
            
            
        }

        
        
        
    }
}