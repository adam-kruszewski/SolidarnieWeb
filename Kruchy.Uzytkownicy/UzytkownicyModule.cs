using Kruchy.NHibernate.RejestracjaAssembly;
using Kruchy.Uzytkownicy.Services;
using Kruchy.Uzytkownicy.Services.Impl;
using Ninject.Modules;

namespace Kruchy.Uzytkownicy
{
    public class UzytkownicyModule : NinjectModule
    {
        public override void Load()
        {
            RejestratorAssembly.Zarejestruj(this.GetType().Assembly);

            Bind<IUzytkownicyService>().To<UzytkownicyService>();
        }
    }
}