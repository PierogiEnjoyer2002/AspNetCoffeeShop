using System;
using System.Collections.Generic;

namespace CoffeeShopMVC.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        // Identyfikator użytkownika (z Identity) - do autoryzacji
        public string UserId { get; set; }

        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }

        // Relacja jeden-do-wielu: jedno zamówienie -> wiele OrderItem
        public List<OrderItem> OrderItems { get; set; }

        // Relacja jeden-do-jeden z CustomerInfo
        public int CustomerInfoId { get; set; }
        public CustomerInfo CustomerInfo { get; set; }
    }
}