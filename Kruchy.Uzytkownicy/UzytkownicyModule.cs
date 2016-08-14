using Kruchy.Uzytkownicy.Services;
using Kruchy.Uzytkownicy.Services.Impl;
using Ninject.Modules;

namespace Kruchy.Uzytkownicy
{
    public class UzytkownicyModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUzytkownicyService>().To<UzytkownicyService>();
        }
    }
}