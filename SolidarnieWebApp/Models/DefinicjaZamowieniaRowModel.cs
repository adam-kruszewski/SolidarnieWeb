using System;

namespace SolidarnieWebApp.Models
{
    public class DefinicjaZamowieniaRowModel
    {
        public int ID { get; set; }

        public string Nazwa { get; set; }

        public DateTime CzasKoncaZamawiania { get; set; }
    }
}