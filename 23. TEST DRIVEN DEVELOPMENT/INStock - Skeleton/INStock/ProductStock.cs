using INStock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INStock
{
    public class ProductStock : IProductStock
    {
        private List<IProduct> products;

        public ProductStock()
        {
            products = new List<IProduct>();
        }

        public IProduct this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Count { get => products.Count; }

        public void Add(IProduct product)
        {
            var existingProduct = (Product)products.FirstOrDefault(x => x.Label == product.Label);//FindByLabel(product.Label);

            if (existingProduct == null)
            {
                products.Add(product);
            }
            else
            {
                if (existingProduct.Price != product.Price)
                {
                    throw new ArgumentException();
                }

                existingProduct.Quantity += product.Quantity;
            }
        }

        public bool Contains(IProduct product)
        {
            return products.Any(x => x.Label == product.Label);
        }

        public IProduct Find(int index)
        {
            try
            {
                return products[index - 1];
            }
            catch (ArgumentOutOfRangeException ae)
            {

                throw new IndexOutOfRangeException(ae.Message, ae);
            }
        }

        public IEnumerable<IProduct> FindAllInPriceRange(decimal lo, decimal hi)
        {
            return products.Where(x => x.Price >= lo && x.Price <= hi);
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProduct> FindAllByPrice(double lo)
        {
            throw new NotImplementedException();
        }

        public IProduct FindByLabel(string label)
        {
            var product = products.FirstOrDefault(x => x.Label == label);
            
            if (product == null)
            {
                throw new ArgumentException();
            }
            
            return product;
        }

        public IProduct FindMostExpensiveProduct()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            return products.GetEnumerator();
        }

        public bool Remove(IProduct product)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
