using System.Collections.Generic;
using Kruchy.NHibernate.Provider;

namespace Kruchy.NHibernate.Repositories
{
    public class NHibernateRepository<T>
        where T : class
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

        public virtual T Save(T o)
        {
            var session = sessionProvider.DajSesje();
            session.Save(o);
            return o;
        }

        public virtual void Update(T o)
        {
            var session = sessionProvider.DajSesje();
            session.Update(o);
        }

        public IList<T> GetAll()
        {
            return sessionProvider.DajSesje().QueryOver<T>().List<T>();
        }

        public void Flush()
        {
            sessionProvider.DajSesje().Flush();
        }
    }
}