using System;
using NHibernate;
using NHibernate.Cfg;

namespace Kruchy.Uzytkownicy.Konfiguracja
{
    public interface IHibernateSessionProvider : IDisposable
    {
        ISession DajSesje();
        Configuration DajKonfiguracje();
    }
}