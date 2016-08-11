using System.ComponentModel.DataAnnotations;

namespace SolidarnieWebApp.Models
{
    public class UzytkownikEditModel
    {
        public int ID { get; set; }

        [Required]
        public string Nazwa { get; set; }

        [Required]
        public string Email { get; set; }
    }
}