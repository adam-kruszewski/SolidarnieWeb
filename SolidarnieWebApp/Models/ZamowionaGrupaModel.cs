using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SolidarnieWebApp.Models
{
    public class ZamowionaGrupaModel
    {
        public int GrupaProduktowID { get; set; }

        public string NazwaGrupy { get; set; }

        public int? Limit { get; set; }

        public int SumaIlosci { get; set; }

        public List<ZamowionyProduktModel> ZamowioneProdukty { get; set; }

        public ZamowionaGrupaModel()
        {
            ZamowioneProdukty = new List<ZamowionyProduktModel>();
        }
    }
}