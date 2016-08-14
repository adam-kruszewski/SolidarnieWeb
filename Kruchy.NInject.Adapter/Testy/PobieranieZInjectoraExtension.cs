using Ninject;

namespace Kruchy.NInject.Adapter.Testy
{
    public static class PobieranieZInjectoraExtension
    {
        public static T Pobierz<T>(this IKernel kernel)
        {
            return (T)kernel.GetService(typeof(T));
        }
    }
}