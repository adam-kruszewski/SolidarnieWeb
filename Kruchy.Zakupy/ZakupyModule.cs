using Kruchy.NHibernate.RejestracjaAssembly;
using Ninject.Modules;

namespace Kruchy.Zakupy
{
    public class ZakupyModule : NinjectModule
    {
        public override void Load()
        {
            RejestratorAssembly.Zarejestruj(this.GetType().Assembly);
        }
    }
}