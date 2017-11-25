namespace Kruchy.Uzytkownicy.Domain
{
    class Uzytkownik
    {
        public virtual int ID { get; set; }

        public virtual string Nazwa { get; set; }

        public virtual string Email { get; set; }

        public virtual string Haslo { get; set; }
    }
}