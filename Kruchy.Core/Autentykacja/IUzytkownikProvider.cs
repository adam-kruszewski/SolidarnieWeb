namespace Kruchy.Core.Autentykacja
{
    public interface IUzytkownikProvider
    {
        IUzytkownik DajZalogowanego();
    }
}
