using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SolidarnieWebApp.Models
{
    public class UzytkownikEditModel
    {
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }

        [Required]
        public string Nazwa { get; set; }

        [Required]
        public string Email { get; set; }
    }
}