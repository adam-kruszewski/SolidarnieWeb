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

            Uzytkownicy.Add(new UzytkownikRowModel {
                Nazwa = "uztykownik1",
                Email = "uzytkonik1@u1.pl",
                ID = 4
            });
        }
    }
}