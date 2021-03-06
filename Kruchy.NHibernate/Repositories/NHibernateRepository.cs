﻿using System.Collections.Generic;
using Kruchy.NHibernate.Provider;
using NHibernate;

namespace Kruchy.NHibernate.Repositories
{
    public class NHibernateRepository<T> : INHibernateRepository<T>
        where T : class
    {
        private readonly IHibernateSessionProvider sessionProvider;

        protected ISession Session { get { return sessionProvider.DajSesje(); } }

        public NHibernateRepository(
            IHibernateSessionProvider sessionProvider)
        {
            this.sessionProvider = sessionProvider;
        }

        public virtual T Load(object id)
        {
            var session = sessionProvider.DajSesje();
            return session.Load<T>(id);
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

        public virtual void Delete(T o)
        {
            var session = sessionProvider.DajSesje();
            session.Delete(o);
        }

        public void Flush()
        {
            sessionProvider.DajSesje().Flush();
        }
    }
}