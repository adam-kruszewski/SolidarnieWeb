using Ninject;
using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Attributes;
using Ninject.Extensions.Interception.Request;

namespace Kruchy.Uzytkownicy.Aspects
{
    public class WymagaUprawnieniaAttribute : InterceptAttribute
    {
        public string Uprawnienie { get; set; }

        public WymagaUprawnieniaAttribute(string uprawnienie)
        {
            Uprawnienie = uprawnienie;
        }

        public override IInterceptor CreateInterceptor(IProxyRequest request)
        {
            var interceptor = request.Kernel.Get<WymagaUprawnieniaInterceptor>();
            interceptor.ustawUprawnienie(Uprawnienie);
            return interceptor;
        }
    }
}
