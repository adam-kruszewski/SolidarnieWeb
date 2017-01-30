using Kruchy.NHibernate.RejestracjaAssembly;
using Ninject.Modules;

namespace Kruchy.Uzytkownicy
{
    public class UzytkownicyModule : NinjectModule
    {
        public override void Load()
        {
            RejestratorAssembly.Zarejestruj(this.GetType().Assembly);
        }
    }
}