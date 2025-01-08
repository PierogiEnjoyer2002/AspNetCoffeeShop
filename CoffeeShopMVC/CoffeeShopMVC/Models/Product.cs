using System.ComponentModel.DataAnnotations;

namespace CoffeeShopMVC.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Nazwa produktu jest wymagana")]
        [StringLength(100, ErrorMessage = "Nazwa produktu nie może przekraczać 100 znaków")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Opis nie może przekraczać 500 znaków")]
        public string Description { get; set; }

        [Range(0.01, 9999.99, ErrorMessage = "Cena musi być większa od 0 i mniejsza niż 9999.99")]
        public decimal Price { get; set; }

        [Range(0, 9999, ErrorMessage = "Stan magazynowy nie może być ujemny")]
        public int StockQuantity { get; set; }

        // Relacja do Category (wiele Products -> jedna Category)
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}