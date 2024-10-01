using System;
using System.Collections.Generic;

namespace OnlineStore
{
    public class ShoppingCart
    {
        private List<CartItem> _items = new List<CartItem>();

        public void AddToCart(IProduct product, int quantity = 1)
        {
            var existingItem = _items.Find(item => item.Product.Id == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _items.Add(new CartItem { Product = product, Quantity = quantity });
            }
            Console.WriteLine($"{quantity} x {product.Name} добавлено в корзину.");
        }

        public void RemoveFromCart(int productId)
        {
            var item = _items.Find(i => i.Product.Id == productId);
            if (item != null)
            {
                _items.Remove(item);
                Console.WriteLine($"{item.Product.Name} удалён из корзины.");
            }
            else
            {
                Console.WriteLine("Товар не найден в корзине.");
            }
        }

        public void ViewCart()
        {
            if (_items.Count == 0)
            {
                Console.WriteLine("Корзина пуста.");
            }
            else
            {
                Console.WriteLine("Текущая корзина:");
                foreach (var item in _items)
                {
                    Console.WriteLine($"ID:{item.Product.Id} {item.Product.Name} - {item.Quantity} шт. - {item.Product.Price:N2} за штуку");
                }
            }
        }
    }
}
