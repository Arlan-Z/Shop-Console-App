using System;
using System.Threading.Tasks;

// json full path C:\Users\Arlan\Desktop\Проекты\.net Console Application Shop\main\Shop Application\Shop Application\products.json
namespace OnlineStore
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var store = new Store();
            var cart = new ShoppingCart();
            string filePath = "products.json";

            // Current Directory
            // Console.WriteLine($"Working directory: {Environment.CurrentDirectory}");

            // Async json load
            await store.LoadProductsAsync(filePath);

            bool running = true;

            while (running)
            {
                Console.WriteLine("\nГлавное меню:");
                Console.WriteLine("1. Просмотр списка товаров");
                Console.WriteLine("2. Добавить товар в корзину");
                Console.WriteLine("3. Удалить товар из корзины");
                Console.WriteLine("4. Просмотр корзины");
                Console.WriteLine("5. Выход");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        store.DisplayProducts();
                        break;
                    case "2":
                        Console.Write("Введите ID товара для добавления в корзину: ");
                        if (int.TryParse(Console.ReadLine(), out int productId))
                        {
                            var product = store.Products.Find(p => p.Id == productId);
                            if (product != null)
                            {
                                Console.Write("Введите количество (по умолчанию 1): ");
                                string qtyInput = Console.ReadLine();
                                int quantity = 1;
                                if (!string.IsNullOrWhiteSpace(qtyInput))
                                {
                                    if (!int.TryParse(qtyInput, out quantity) || quantity <= 0)
                                    {
                                        Console.WriteLine("Некорректное количество. Используется 1 по умолчанию.");
                                        quantity = 1;
                                    }
                                }
                                cart.AddToCart(product, quantity);
                            }
                            else
                            {
                                Console.WriteLine("Товар с таким ID не найден.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неверный ввод ID товара.");
                        }
                        break;
                    case "3":
                        Console.Write("Введите ID товара для удаления из корзины: ");
                        if (int.TryParse(Console.ReadLine(), out int removeProductId))
                        {
                            cart.RemoveFromCart(removeProductId);
                        }
                        else
                        {
                            Console.WriteLine("Неверный ввод ID товара.");
                        }
                        break;
                    case "4":
                        cart.ViewCart();
                        break;
                    case "5":
                        running = false;
                        Console.WriteLine("Выход из программы...");
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте ещё раз.");
                        break;
                }
            }
        }
    }
}
