using System;
using System.Security.Cryptography;
using System.Text;

namespace Kruchy.Uzytkownicy.Services.Impl
{
    class SkrotHaslaService : ISkrotHaslaService
    {

        public string Wylicz(string haslo)
        {
            byte[] bajtyHasla = new UTF8Encoding().GetBytes(haslo);

            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(bajtyHasla);

            return Convert.ToBase64String(hash);
        }
    }
}