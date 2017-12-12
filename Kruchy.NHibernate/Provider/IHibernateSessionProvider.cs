using NHibernate;

namespace Kruchy.NHibernate.Provider
{
    public interface IHibernateSessionProvider
    {
        void AktualizujBaze();
        void UtworzBaze();
        ISession DajSesje();
        bool JestOtwartaTransakcja();
        void RozpocznijTransakcje();
        void Commit();
        void Rollback();
    }
}