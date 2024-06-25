using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giorno_1
{
    internal class ProductService : IProductService
    {

        private List<Product> _allProducts = [
            new Product{Id = 1, Name = "Coca Cola", Price = 2.50m},
            new Product{Id = 2, Name = "Insalata di pollo", Price = 5.20m},
            new Product {Id = 3, Name = "Pizza Margherita", Price = 10.00m},
            new Product {Id = 4, Name = "Pizza 4 Formaggi", Price = 12.50m},
            new Product {Id = 5, Name = "Pz patatine fritte", Price = 3.50m},
            new Product {Id = 6, Name = "Insalata di riso", Price = 8.00m},
            new Product {Id = 7, Name = "Frutta di stagione", Price = 5.00m},
            new Product {Id = 8, Name = "Pizza fritta", Price = 5.00m},
            new Product {Id = 9, Name = "Piadina vegetariana", Price = 6.00m},
            new Product {Id = 10, Name = "Panino Hamburger", Price = 7.90m}
            ];

        private Bill bill = new Bill();
        public Bill GetBill()
        {
            var Amount = 0m;
            foreach (var item in bill.Products) {
                Amount += item.Price;
            }
            bill.Amount = Amount + bill.TableService;
            return bill;
        }

        public List<Product> GetProducts()
        {
            return _allProducts;
        }

        public void Order()
        {
            bill = new Bill();
        }

        public void SelectProduct(int id)
        {
            var product = new Product {Id = id};
            bill.Products.Add(product);
        }
    }
}
