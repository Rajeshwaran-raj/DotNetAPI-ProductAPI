using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ModelsData
{
    public class DataExport
    {
        private static readonly List<Product> _products = new()
    {
        new Product { Id = 1, Name = "Laptop", Price = 55000, Stock = 10 },
        new Product { Id = 2, Name = "Mouse", Price = 500, Stock = 100 },
        new Product { Id = 3, Name = "Keyboard", Price = 1200, Stock = 50 }
    };

        private static int _nextId = 4;

        public static List<Product> GetAll() => _products;

        public static Product? GetById(int id)
            => _products.FirstOrDefault(p => p.Id == id);

        public static Product Add(Product product)
        {
            product.Id = _nextId++;
            product.CreatedAt = DateTime.UtcNow;
            _products.Add(product);
            return product;
        }

        public static bool Update(Product product)
        {
            var existing = GetById(product.Id);
            if (existing is null) return false;

            existing.Name = product.Name;
            existing.Price = product.Price;
            existing.Stock = product.Stock;
            return true;
        }

        public static bool UpdateStock(int id, int stock)
        {
            var product = GetById(id);
            if (product is null) return false;

            product.Stock = stock;
            return true;
        }

        public static bool Delete(int id)
        {
            var product = GetById(id);
            if (product is null) return false;

            _products.Remove(product);
            return true;
        }

    }
}
