using System.Collections.Generic;

namespace Kruchy.Zakupy.Views
{
    public class ZamowionaGrupa
    {
        public int GrupaProduktowID { get; set; }

        public string NazwaGrupy { get; set; }

        public int Limit { get; set; }

        public int SumaIlosci { get; set; }

        public List<ZamowionyProdukt> ZamowioneProdukty { get; set; }

        public ZamowionaGrupa()
        {
            ZamowioneProdukty = new List<ZamowionyProdukt>();
        }
    }
}