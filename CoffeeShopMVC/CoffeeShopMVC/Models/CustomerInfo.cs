using System.ComponentModel.DataAnnotations;

namespace CoffeeShopMVC.Models
{
    public class CustomerInfo
    {
        public int CustomerInfoId { get; set; }

        [Required(ErrorMessage = "Imię jest wymagane")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        public string LastName { get; set; }

        [Phone(ErrorMessage = "Wprowadź poprawny numer telefonu")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Adres dostawy jest wymagany")]
        public string DeliveryAddress { get; set; }

        // Relacja 1-1 z Order (jedna encja CustomerInfo -> jedno Order)
        public Order Order { get; set; }
    }
}