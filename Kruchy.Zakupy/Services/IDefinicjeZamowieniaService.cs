using Kruchy.NHibernate.Repositories;
using Kruchy.Zakupy.Domain;

namespace Kruchy.Zakupy.Services
{
    interface IDefinicjeZamowieniaService
    {
        int Wstaw(WstawienieDefinicjiZamowieniaRequest request);
    }
}