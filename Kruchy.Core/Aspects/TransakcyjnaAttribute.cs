using System;
using Ninject;
using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Attributes;
using Ninject.Extensions.Interception.Request;

namespace Kruchy.Core.Aspects
{
    public class TransakcyjnaAttribute : InterceptAttribute
    {
        public override IInterceptor CreateInterceptor(IProxyRequest request)
        {
            return request.Kernel.Get<TransakcyjnyInterceptor>();
        }
    }
}
