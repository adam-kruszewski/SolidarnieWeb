using System.Collections.Generic;
using Kruchy.Core.Konfiguracja;
using Kruchy.NHibernate.Provider;

namespace SolidarnieWebApp.Services.Impl
{
    class StartAplikacji : IStartAplikacji
    {
        private readonly IList<IPrzygotowanieAplikacji> przygotowania;
        private readonly IHibernateSessionProvider sesjaProvider;

        public StartAplikacji(
            IList<IPrzygotowanieAplikacji> przygotowania,
            IHibernateSessionProvider sesjaProvider)
        {
            this.przygotowania = przygotowania;
            this.sesjaProvider = sesjaProvider;
        }

        public void Przygotuj()
        {
            foreach (var przygotowanie in przygotowania)
                przygotowanie.PrzygotujPrzedAktualizacjaBazy();
            sesjaProvider.AktualizujBaze();
            foreach (var przygotowanie in przygotowania)
                przygotowanie.PrzygotujPoAktualizacjiBazy();
        }

    }
}