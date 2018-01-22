using System;

namespace Kruchy.Uzytkownicy.Domain
{
    public class UprawnienieUzytkownika
    {
        public virtual int ID { get; set; }

        public virtual DateTime DataOd { get; set; }

        public virtual DateTime? DataDo { get; set; }

        public virtual string Uprawnienie { get; set; }

        public virtual Uzytkownik Uzytkownik { get; set; }
    }
}
