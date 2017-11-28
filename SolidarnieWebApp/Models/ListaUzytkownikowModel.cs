using System.Collections.Generic;

namespace SolidarnieWebApp.Models
{
    public class ListaUzytkownikowModel
    {
        public List<UzytkownikRowModel> Uzytkownicy { get; set; }

        public ListaUzytkownikowModel()
        {
            Uzytkownicy = new List<UzytkownikRowModel>();
        }
    }
}