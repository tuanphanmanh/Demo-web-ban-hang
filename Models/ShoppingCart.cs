using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models
{
    public class ShoppingCart
    {
        public List<ShoppingCartItem> Items { get; set; }
        public ShoppingCart() {
            this.Items = new List<ShoppingCartItem>();
        }
        public void AddToCard(ShoppingCartItem item, int Quantity)
        {
            var checkExits = Items.FirstOrDefault(a => a.ProductId == item.ProductId);
            if(checkExits != null)
            {
                checkExits.Quantity += Quantity;
                checkExits.TotalPrice = checkExits.Price * checkExits.Quantity;
            }
            else
            {
                Items.Add(item);
            }
        }
        public void Remove(int id)
        {
            var checkExits = Items.SingleOrDefault(a=>a.ProductId == id);
            if (checkExits != null)
            {
                Items.Remove(checkExits);
            }
        }
        public void UpdateQuantity(int id, int quantity)
        {
            var checkExits = Items.SingleOrDefault(a => a.ProductId == id);
            if (checkExits != null)
            {
                checkExits.Quantity = quantity;
                checkExits.TotalPrice = checkExits.Price * checkExits.Quantity;
            }
        }
        public decimal GetTotal()
        {
            return Items.Sum(a => a.TotalPrice);
        }
        public decimal GetTotalQuantity()
        {
            return Items.Sum(a => a.Quantity);
        } 
        public void ClearCart()
        {
            Items.Clear();
        }


    }

    public class ShoppingCartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string Alias { get; set; }
        public string ProductImg { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
    }
}