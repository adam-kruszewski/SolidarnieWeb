using System;
using Kruchy.NHibernate.Provider;
using Ninject.Extensions.Interception;

namespace Kruchy.Core.Aspects
{
    public class TransakcyjnyInterceptor : IInterceptor
    {
        private readonly IHibernateSessionProvider sessionProvider;

        public TransakcyjnyInterceptor(
            IHibernateSessionProvider sessionProvider)
        {
            this.sessionProvider = sessionProvider;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                var bylaTransakcja = sessionProvider.JestOtwartaTransakcja();
                if (!bylaTransakcja)
                    sessionProvider.RozpocznijTransakcje();
                invocation.Proceed();
                if (!bylaTransakcja)
                    sessionProvider.Commit();
            }
            catch (Exception)
            {
                if (sessionProvider.JestOtwartaTransakcja())
                    sessionProvider.Rollback();
                throw;
            }
        }
    }
}
