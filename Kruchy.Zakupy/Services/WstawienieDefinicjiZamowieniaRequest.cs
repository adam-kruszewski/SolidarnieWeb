using System;

namespace Kruchy.Zakupy.Services
{
    public class WstawienieDefinicjiZamowieniaRequest
    {
        public string Nazwa { get; set; }
        public string NazwaPliku { get; set; }
        public byte[] ZawartoscPliku { get; set; }
        public DateTime DataKoncaZamawiania { get; set; }
    }
}