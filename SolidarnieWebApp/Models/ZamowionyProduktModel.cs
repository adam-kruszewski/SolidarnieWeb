using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Kruchy.Zakupy.Views;
using SolidarnieWebApp.HtmlHelpers.Attributes;

namespace SolidarnieWebApp.Models
{
    public class ZamowionyProduktModel
    {
        [UkrytaKolumna]
        public int ProduktID { get; set; }

        public string Nazwa { get; set; }

        public int Ilosc { get; set; }

        public decimal Cena { get; set; }

        public decimal SumaKwot { get; set; }

        [UIHint("IlosciUzytkownikow")]
        public List<IloscUzytkownika> IlosciUzytkownikow { get; set; }

        public ZamowionyProduktModel()
        {
            IlosciUzytkownikow = new List<IloscUzytkownika>();
        }
    }
}