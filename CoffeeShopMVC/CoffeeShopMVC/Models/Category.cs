using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoffeeShopMVC.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Nazwa kategorii jest wymagana")]
        [StringLength(50, ErrorMessage = "Nazwa kategorii nie może przekraczać 50 znaków")]
        public string Name { get; set; }

        // Relacja: Jedna kategoria -> wiele produktów
        public List<Product>? Products { get; set; }
    }
}