using System.IO;
using System.Security.Authentication;
using System.Web;
using Kruchy.Core.Autentykacja;
using Kruchy.Uzytkownicy.Views;
using Newtonsoft.Json;

namespace SolidarnieWebApp.Authentication
{
    class HttpUzytkownikProvider : IUzytkownikProvider
    {
        public IUzytkownik DajZalogowanego()
        {
            var cookie = HttpContext.Current.Request.Cookies["solidarnie"];

            if (cookie == null)
                throw new AuthenticationException("Brak zalogowanego użytkownika");

            var userView =
                new JsonSerializer()
                    .Deserialize<UzytkownikView>(
                        new JsonTextReader(new StringReader(cookie.Value)));

            return new Uzytkownik(userView);
        }

        private class Uzytkownik : IUzytkownik
        {
            private readonly UzytkownikView view;

            public Uzytkownik(UzytkownikView view)
            {
                this.view = view;
            }

            public string Email
            {
                get
                {
                    return view.Email;
                }
            }

            public int ID
            {
                get
                {
                    return view.ID;
                }
            }

            public string Nazwa
            {
                get
                {
                    return view.Nazwa;
                }
            }
        }
    }
}