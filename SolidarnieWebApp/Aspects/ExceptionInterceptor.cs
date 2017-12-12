//using NHibernate.Proxy.DynamicProxy;

using System;
using System.Diagnostics;
using Kruchy.NHibernate.Provider;
using Ninject.Extensions.Interception;

namespace SolidarnieWebApp.Aspects
{
    public class ExceptionInterceptor : IInterceptor
    {
        private readonly IHibernateSessionProvider provider;

        public ExceptionInterceptor(
            IHibernateSessionProvider provider)
        {
            this.provider = provider;
        }


        //public object Intercept(InvocationInfo invocation)
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.StackTrace);
                throw;
            }
        }
    }
}