using System.Collections.Generic;

namespace SolidarnieWebApp.Models.Uprawnienia
{
    public class UprawnieniaUzytkownikaFormModel
    {
        public int UzytkownikID { get; set; }

        public string NazwaUzytkownika { get; set; }

        public List<UprawnienieUzytkownikaModel> Uprawnienia { get; set; }

        public UprawnieniaUzytkownikaFormModel()
        {
            Uprawnienia = new List<UprawnienieUzytkownikaModel>();
        }
    }
}