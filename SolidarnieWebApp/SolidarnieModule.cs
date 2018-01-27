using Kruchy.Core.Autentykacja;
using Kruchy.NHibernate.Provider;
using Kruchy.NInject.Adapter.Ladowanie;
using Kruchy.Uzytkownicy;
using Kruchy.Zakupy;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using SolidarnieWebApp.Authentication;
using SolidarnieWebApp.Services;

namespace SolidarnieWebApp
{
    public class SolidarnieModule : NinjectModule
    {


        public override void Load()
        {
            Kernel.LoadOnce<UzytkownicyModule>();
            Kernel.LoadOnce<ZakupyModule>();
            Kernel.Bind<IHibernateSessionProvider>()
                .To<HibernateSessionProvider>()
                    .InRequestScope();

            Kernel.Bind<IUzytkownikProvider>().To<HttpUzytkownikProvider>();

            var przygotowanie = Kernel.Get<IStartAplikacji>();
            przygotowanie.Przygotuj();
        }
    }
}