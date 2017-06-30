using System;
using System.ComponentModel.DataAnnotations;

namespace SolidarnieWebApp.Models
{
    public class ZamowienieModel
    {
        public string Nazwa { get; set; }

        public DateTime CzasKoncaZamawiania { get; set; }

        [UIHint("FileUpload")]
        public string NazwaPolaPliku { get; set; }

        public ZamowienieModel()
        {
            NazwaPolaPliku = "excel";
        }
    }
}