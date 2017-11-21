using System;
using System.Web;

namespace SolidarnieWebApp.Models
{
    public class ZamowienieModel
    {
        public string Nazwa { get; set; }

        public DateTime CzasKoncaZamawiania { get; set; }

        public HttpPostedFileBase Testowo { get; set; }

        public ZamowienieModel()
        {
            CzasKoncaZamawiania = DateTime.Today;
        }
    }
}