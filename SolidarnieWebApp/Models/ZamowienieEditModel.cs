using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Kruchy.Core.Autentykacja;
using SolidarnieWebApp.HtmlHelpers.Attributes;

namespace SolidarnieWebApp.Models
{
    public class ZamowienieEditModel
    {
        public IUzytkownik Uzytkownik { get; set; }

        public int ID { get; set; }

        public List<GrupaProduktowEditModel> GrupyProduktow { get; set; }

        public ZamowienieEditModel()
        {
            GrupyProduktow = new List<GrupaProduktowEditModel>();
        }
    }

    public class GrupaProduktowEditModel
    {
        public string Nazwa { get; set; }

        public int? Limit { get; set; }

        public List<ProduktEditModel> Produkty { get; set; }

        public GrupaProduktowEditModel()
        {
            Produkty = new List<ProduktEditModel>();
        }
    }

    public class ProduktEditModel
    {
        [UkrytaKolumna]
        public int ID { get; set; }

        public string Nazwa { get; set; }

        public decimal Cena { get; set; }

        [UIHint("Ilosc")]
        public int Ilosc { get; set; }
    }
}