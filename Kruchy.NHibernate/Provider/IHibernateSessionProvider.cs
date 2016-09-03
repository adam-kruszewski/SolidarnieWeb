using NHibernate;

namespace Kruchy.NHibernate.Provider
{
    public interface IHibernateSessionProvider
    {
        void UtworzBaze();
        ISession DajSesje();
    }
}