using System.ComponentModel.DataAnnotations;

namespace CarDealership.Backend.Models
{
    public class Car
    {
        [Key]
        public int Key { get; set; }
        [Required, Display(Name = "Merkki")]
        public string Brand { get; set; }
        [Required, Display(Name = "Malli")]
        public string Model { get; set; }
        [Required, Display(Name = "Valmistusvuosi")]
        public int Year { get; set; }
    }
}
