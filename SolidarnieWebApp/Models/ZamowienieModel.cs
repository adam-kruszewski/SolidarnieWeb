using System;
using System.ComponentModel;
using System.Web;

namespace SolidarnieWebApp.Models
{
    public class ZamowienieModel
    {
        public string Nazwa { get; set; }

        [DisplayName("Czas końca zamawiania")]
        public DateTime CzasKoncaZamawiania { get; set; }

        [DisplayName("Plik .xslx")]
        public HttpPostedFileBase Plik { get; set; }

        public ZamowienieModel()
        {
            CzasKoncaZamawiania = DateTime.Today;
        }
    }
}