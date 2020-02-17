namespace INStock.Tests
{
    using INStock.Contracts;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ProductStockTests
    {
        private ProductStock productStock;

        [SetUp]
        public void CreateTestObjects()
        {
            productStock = new ProductStock();

            productStock.Add(new Product()
            {
                Label = "MyProduct",
                Quantity = 1,
                Price = 100
            });
        }

        [Test]
        public void DuplicateLabelAfterAddingNewProduct()
        {
            var countBeforeAdd = productStock.Count;
            productStock.Add(new Product() { Label = "MyProduct", Price = 100 });

            Assert.That(productStock.Count == countBeforeAdd);
        }

        [Test]
        public void ProductQuantityIncreasedByQuatityAdded()
        {
            var quantityBefore = productStock.FirstOrDefault().Quantity;
            productStock.Add(new Product() { Label = "MyProduct", Quantity = 5, Price = 100 });

            Assert.That(productStock.FirstOrDefault().Quantity == 6);
        }

        [Test]
        public void PricePreservedAfterNewProductAdded()
        {
            var product = new Product() { Label = "MyProduct", Price = 5.9m };

            Assert.That(() => productStock.Add(product), Throws.ArgumentException);
        }

        [Test]
        public void TrueIfContainsProduct()
        {
            var product = new Product()
            {
                Label = "MyProduct",
                Quantity = 1,
                Price = 100
            };

            Assert.That(productStock.Contains(product));
        }

        [Test]
        public void FalseIfContainsProduct()
        {
            var product = new Product()
            {
                Label = "MyProduct1",
                Quantity = 1,
                Price = 100
            };

            Assert.That(!productStock.Contains(product));
        }

        [Test]
        public void FindNthProductInStock()
        {
            var product = new Product()
            {
                Label = "NewProduct",
                Quantity = 1,
                Price = 100
            };

            productStock.Add(product);
            var findedProduct = productStock.Find(2);

            Assert.That(findedProduct, Is.EqualTo(product));
        }

        [Test]
        public void ErrorIfProductIndexIsNotValid()
        {
            Assert.Throws<IndexOutOfRangeException>(() => productStock.Find(8));
        }

        [Test]
        public void ProductFoundByLabel()
        {
            var product = productStock.FindByLabel("MyProduct");

            Assert.AreEqual(product, productStock.First());
        }

        [Test]
        public void ErrorIfLabelNotFound()
        {
            Assert.Throws<ArgumentException>(() => productStock.FindByLabel("NewProduct"));
        }

        [Test]
        public void EmptyListIfNotFound()
        {
            var products = productStock.FindAllInPriceRange(1, 2);

            Assert.That(products.Count() == 0);
        }

        [TearDown]
        public void DestroyObjects()
        {
            productStock = null;
        }
    }
}
