namespace Kruchy.Core.Konfiguracja
{
    public interface IPrzygotowanieAplikacji
    {
        void PrzygotujPrzedAktualizacjaBazy();

        void PrzygotujPoAktualizacjiBazy();
    }
}
