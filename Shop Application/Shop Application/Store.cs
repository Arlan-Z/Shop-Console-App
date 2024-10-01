using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace OnlineStore
{
    public class Store
    {
        public List<IProduct> Products { get; set; } = new List<IProduct>();

        public async Task LoadProductsAsync(string filePath)
        {
            string fullPath = Path.GetFullPath(filePath);
            // Console.WriteLine($"Getting json from: {fullPath}");

            if (File.Exists(fullPath))
            {
                //Console.WriteLine($"File {fullPath} Found. Reading...");
                var json = await File.ReadAllTextAsync(fullPath);
                //Console.WriteLine("File contains:");
                //Console.WriteLine(json); 

                try
                {
                    var productList = JsonSerializer.Deserialize<List<Product>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (productList != null && productList.Count > 0)
                    {
                        Products = new List<IProduct>(productList);
                        Console.WriteLine("Success!. File Found");
                    }
                    else
                    {
                        Console.WriteLine("Deserialization completed, but items not found.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Deserialization error {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"file{fullPath} not found.");
            }
        }

        public void DisplayProducts()
        {
            if (Products.Count == 0)
            {
                Console.WriteLine("Нет доступных товаров для отображения.");
                return;
            }

            Console.WriteLine("Список товаров:");
            foreach (var product in Products)
            {
                Console.WriteLine($"ID: {product.Id}, {product.Name}, Цена: {product.Price:N2}");
            }
        }
    }
}
