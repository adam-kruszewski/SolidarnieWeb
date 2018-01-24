using System;
using Kruchy.Core.Autentykacja;
using Kruchy.Uzytkownicy.Uprawnienia;

namespace SolidarnieWebApp.Extensions
{
    public static class UprawnieniaServiceExtensions
    {
        public static void UstawCzyAdministrator(
            this IUprawnieniaService uprawnieniaService,
            IUzytkownikProvider uzytkownikProvider,
            Action<bool> akcjaUstawienia)
        {
            var uzytkownik = uzytkownikProvider.SzukajZalogowanego();
            if (uzytkownik == null)
            {
                akcjaUstawienia(false);
                return;
            }

            var maUprawnienie =
                uprawnieniaService
                    .SprawdzCzyPosiada(
                        uzytkownik.ID,
                        "Administrator");
            akcjaUstawienia(maUprawnienie);
        }
    }
}