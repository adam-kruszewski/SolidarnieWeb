namespace Kruchy.Core.Autentykacja
{
    public interface IUzytkownik
    {
        int ID { get; }
        string Nazwa { get; }
        string Email { get; }
    }
}