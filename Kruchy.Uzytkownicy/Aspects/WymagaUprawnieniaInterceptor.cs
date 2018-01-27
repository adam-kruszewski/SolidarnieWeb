using System;
using Kruchy.Core.Autentykacja;
using Kruchy.Uzytkownicy.Uprawnienia;
using Ninject.Extensions.Interception;

namespace Kruchy.Uzytkownicy.Aspects
{
    public class WymagaUprawnieniaInterceptor : IInterceptor
    {
        private readonly IUprawnieniaService uprawnieniaService;
        private readonly IUzytkownikProvider uzytkownikProvider;

        private string uprawnienie;

        public WymagaUprawnieniaInterceptor(
            IUprawnieniaService uprawnieniaService,
            IUzytkownikProvider uzytkownikProvider)
        {
            this.uprawnieniaService = uprawnieniaService;
            this.uzytkownikProvider = uzytkownikProvider;
        }

        public void ustawUprawnienie(string uprawnienie)
        {
            this.uprawnienie = uprawnienie;
        }

        public void Intercept(IInvocation invocation)
        {
            var uzytkownikID = uzytkownikProvider.DajZalogowanego().ID;

            if (!uprawnieniaService.SprawdzCzyPosiada(uzytkownikID, uprawnienie))
                throw new ApplicationException(string.Format("Brak uprawnienia {0}.", uprawnienie));

            invocation.Proceed();
        }
    }
}
