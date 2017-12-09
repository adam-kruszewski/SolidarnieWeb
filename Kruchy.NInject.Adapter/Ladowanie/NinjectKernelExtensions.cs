using System.Linq;
using System.Reflection;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Modules;

namespace Kruchy.NInject.Adapter.Ladowanie
{
    public static class NinjectKernelExtensions
    {
        public static void BindImplementationsFromCallingAssembyFor<T>(this IKernel kernel)
        {
            kernel.BindImplementationsFor<T>(Assembly.GetCallingAssembly());
        }

        public static void BindImplementationsFor<T>(
            this IKernel kernel,
            Assembly assembly)
        {
            kernel.Bind(
                scanner => scanner
                    .From(assembly)
                    .IncludingNonPublicTypes()
                    .Select(o => typeof(T).IsAssignableFrom(o))
                    .BindSelection((type, baseTypes) => baseTypes.Where(o => o == typeof(T)))
                    .Configure(o => o.InSingletonScope()));
        }

        public static void LoadOnce<TModule>(this IKernel kernel)
            where TModule : INinjectModule, new()
        {
            if (kernel.HasModule(typeof(TModule).FullName))
                return;

            var assembly = Assembly.GetAssembly(typeof(TModule));

            kernel.Bind(
                scanner =>
                    scanner.From(assembly)
                        .IncludingNonPublicTypes()
                        .SelectAllClasses()
                        .BindWith(new BindingGenerator()));

            kernel.Load<TModule>();
        }
    }
}
