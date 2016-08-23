using System;
using NHibernate;
using NHibernate.Cfg;

namespace Kruchy.Uzytkownicy.Konfiguracja
{
    interface IHibernateSessionProvider : IDisposable
    {
        ISession DajSesje();
        Configuration DajKonfiguracje();
    }
}