
using System.Web.Mvc;

namespace SolidarnieWebApp.Models
{
    public class LoginModel
    {
        public string Uzytkownik { get; set; }

        public string Haslo { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ReturnUrl { get; set; }
    }
}