using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Kruchy.NHibernate.RejestracjaAssembly
{
    public static class RejestratorAssembly
    {
        private static List<Assembly> listaAssembly = new List<Assembly>();

        public static void Zarejestruj(Assembly assembly)
        {
            listaAssembly.Add(assembly);
        }

        internal static IList<Assembly> DajZarejestrowaneAssembly()
        {
            return listaAssembly.ToList();
        }
    }
}
