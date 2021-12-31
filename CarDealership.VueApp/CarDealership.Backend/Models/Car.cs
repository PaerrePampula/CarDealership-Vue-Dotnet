using System.ComponentModel.DataAnnotations;

namespace CarDealership.Backend.Models
{
    public class Car
    {
        [Key]
        public int ID { get; set; }

        //Lokalisaatiotekstit olisi entistä järkevämpi hakea jostain muusta lähteestä,
        //kuten asialle tarkoitetusta classin tiedoista, ja sitten jostain lokalisaatiotiedostosta yms.,
        //mutta pidetään asiat nyt yksinkertaisena
        [Required, Display(Name = "Merkki")]
        public string Brand { get; set; }

        [Required, Display(Name = "Malli")]
        public string Model { get; set; }

        [Required, Display(Name = "Valmistusvuosi")]
        public int Year { get; set; }
    }
}
