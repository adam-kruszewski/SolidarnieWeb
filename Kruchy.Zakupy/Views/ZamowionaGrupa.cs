using System.Collections.Generic;
using Kruchy.Zakupy.Domain;

namespace Kruchy.Zakupy.Views
{
    public class ZamowionaGrupa
    {
        public int GrupaProduktowID { get; set; }

        public string NazwaGrupy { get; set; }

        public int? Limit { get; set; }

        public int SumaIlosci { get; set; }

        public List<ZamowionyProdukt> ZamowioneProdukty { get; set; }

        public ZamowionaGrupa(GrupaProduktowZamowienia grupaProduktowZamowienia)
        {
            ZamowioneProdukty = new List<ZamowionyProdukt>();
            GrupaProduktowID = grupaProduktowZamowienia.ID;
            Limit = grupaProduktowZamowienia.LimitIlosciowy;
            NazwaGrupy = grupaProduktowZamowienia.Nazwa;
        }
    }
}