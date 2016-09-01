using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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