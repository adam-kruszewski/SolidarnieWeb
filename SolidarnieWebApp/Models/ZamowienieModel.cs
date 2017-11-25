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

        [DisplayName("Plik .xlsx")]
        public HttpPostedFileBase Plik { get; set; }

        public ZamowienieModel()
        {
            CzasKoncaZamawiania = DateTime.Today;
        }
    }
}