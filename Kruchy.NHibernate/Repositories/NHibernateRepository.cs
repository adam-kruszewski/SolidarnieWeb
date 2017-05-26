using Kruchy.NHibernate.Provider;

namespace Kruchy.NHibernate.Repositories
{
    public class NHibernateRepository<T>
    {
        private readonly IHibernateSessionProvider sessionProvider;

        public NHibernateRepository(
            IHibernateSessionProvider sessionProvider)
        {
            this.sessionProvider = sessionProvider;
        }

        public virtual T Get(object id)
        {
            var session = sessionProvider.DajSesje();
            return session.Get<T>(id);
        }

        public virtual object Save(object o)
        {
            var session = sessionProvider.DajSesje();
            return session.Save(o);
        }

        public virtual void Update(object o)
        {
            var session = sessionProvider.DajSesje();
            session.Update(o);
        }
    }
}