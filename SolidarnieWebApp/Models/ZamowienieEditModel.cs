using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolidarnieWebApp.Models
{
    public class ZamowienieEditModel
    {
        public int ID { get; set; }

        List<GrupaProduktowEditModel> GrupyProduktow;

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
        public string Nazwa { get; set; }

        public decimal Cena { get; set; }

        public int Ilosc { get; set; }
    }
}