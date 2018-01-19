using System.Collections.Generic;

namespace SolidarnieWebApp.Models
{
    public class DefiniowanieUprawnienUzytkownikaModel
    {
        public int UzytkownikID { get; set; }

        public string NazwaUzytkownika { get; set; }

        public List<UprawnienieUzytkownikaModel> Uprawnienia { get; set; }
    }
}