using System.ComponentModel.DataAnnotations;
using SolidarnieWebApp.HtmlHelpers.Attributes;

namespace SolidarnieWebApp.Models.Uprawnienia
{
    public class UprawnienieUzytkownikaModel
    {
        [UIHint("PosiadaUprawnienie")]
        public bool Posiada { get; set; }

        public string Nazwa { get; set; }

        public string Opis { get; set; }
    }
}