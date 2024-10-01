using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace OnlineStore
{
    class Store
    {
        public List<IProduct> Products { get; set; } = new List<IProduct>();

        public void LoadProducts(string filePath)
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                Products = JsonSerializer.Deserialize<List<Product>>(json);
            }
            else
            {
                Console.WriteLine("Файл с товарами не найден.");
            }
        }

        public void DisplayProducts()
        {
            Console.WriteLine("Список товаров:");
            foreach (var product in Products)
            {
                Console.WriteLine($"ID: {product.Id}, {product.Name}, Цена: {product.Price:C}");
            }
        }
    }
}
