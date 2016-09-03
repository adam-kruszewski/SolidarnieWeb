using System;
using NHibernate;

namespace Kruchy.Uzytkownicy.Konfiguracja
{
    public interface IHibernateSessionProvider : IDisposable
    {
        void UtworzBaze();
        ISession DajSesje();
    }
}