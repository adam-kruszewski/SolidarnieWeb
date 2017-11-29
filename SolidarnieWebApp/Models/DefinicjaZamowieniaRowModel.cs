using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SolidarnieWebApp.HtmlHelpers.Attributes;

namespace SolidarnieWebApp.Models
{
    public class DefinicjaZamowieniaRowModel
    {
        [UkrytaKolumna]
        public int ID { get; set; }

        public string Nazwa { get; set; }

        [DisplayName("Czas końca zamawiania")]
        public DateTime CzasKoncaZamawiania { get; set; }

        [UIHint("KolumnaAkcji")]
        [DisplayName("")]
        public int IDDlaAkcji { get; set; }
    }
}