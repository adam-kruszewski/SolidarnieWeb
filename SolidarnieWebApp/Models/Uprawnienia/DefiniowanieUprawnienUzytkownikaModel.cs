using System.Collections.Generic;

namespace SolidarnieWebApp.Models.Uprawnienia
{
    public class DefiniowanieUprawnienUzytkownikaModel
    {
        public int UzytkownikID { get; set; }

        public string NazwaUzytkownika { get; set; }

        public List<UprawnienieUzytkownikaModel> Uprawnienia { get; set; }

        public DefiniowanieUprawnienUzytkownikaModel()
        {
            Uprawnienia = new List<UprawnienieUzytkownikaModel>();
        }
    }
}