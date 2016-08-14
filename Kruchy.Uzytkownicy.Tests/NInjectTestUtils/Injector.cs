using Ninject;

namespace Kruchy.Uzytkownicy.Tests.NInjectTestUtils
{
    class Injector
    {
        private static IKernel InstancjaKernela { get; set; }
        public static IKernel Instance
        {
            get
            {
                if (InstancjaKernela == null)
                    InstancjaKernela = new StandardKernel();
                return InstancjaKernela;
            }
        }
    }
}