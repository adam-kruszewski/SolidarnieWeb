using System.Collections.Generic;

namespace Kruchy.Zakupy.Views
{
    public class ZsumowaneZamowienie
    {
        public int DefinicjaID { get; set; }

        public IList<ZamowionaGrupa> ZamowioneGrupy { get; set; }

        public decimal SumaKwot { get; set; }

        public ZsumowaneZamowienie()
        {
            ZamowioneGrupy = new List<ZamowionaGrupa>();
        }
    }
}
