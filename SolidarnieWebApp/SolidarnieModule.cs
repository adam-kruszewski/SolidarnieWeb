using Kruchy.NHibernate.Provider;
using Kruchy.NInject.Adapter.Ladowanie;
using Kruchy.Uzytkownicy;
using Kruchy.Zakupy;
using Ninject.Modules;
using Ninject.Web.Common;

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

            var sesjaProvider =
                Kernel.GetService(typeof(IHibernateSessionProvider))
                    as IHibernateSessionProvider;
            sesjaProvider.AktualizujBaze();
        }
    }
}