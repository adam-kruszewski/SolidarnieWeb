using System.Collections.Generic;

namespace SolidarnieWebApp.Models
{
    public class ZsumowaneZamowienieModel
    {
        public int DefinicjaID { get; set; }

        public IList<ZamowionaGrupaModel> ZamowioneGrupy { get; set; }

        public decimal SumaKwot { get; set; }

        public ZsumowaneZamowienieModel()
        {
            ZamowioneGrupy = new List<ZamowionaGrupaModel>();
        }
    }
}