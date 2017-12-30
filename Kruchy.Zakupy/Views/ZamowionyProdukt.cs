using System.Collections.Generic;

namespace Kruchy.Zakupy.Views
{
    public class ZamowionyProdukt
    {
        public int ProduktID { get; set; }

        public int Ilosc { get; set; }

        public decimal Cena { get; set; }

        public decimal SumaKwot { get; set; }

        public List<IloscUzytkownika> IlosciUzytkownikow { get; set; }

        public ZamowionyProdukt()
        {
            IlosciUzytkownikow = new List<IloscUzytkownika>();
        }
    }
}