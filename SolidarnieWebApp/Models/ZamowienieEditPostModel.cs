using System.Collections.Generic;

namespace SolidarnieWebApp.Models
{
    public class ZamowienieEditPostModel
    {
        public int DefinicjaID { get; set; }

        public List<PozycjaZamowieniaModel> Pozycje { get; set; }

        public ZamowienieEditPostModel()
        {
            Pozycje = new List<PozycjaZamowieniaModel>();
        }
    }

    public class PozycjaZamowieniaModel
    {
        public int ID { get; set; }
        public int Ilosc { get; set; }
    }
}