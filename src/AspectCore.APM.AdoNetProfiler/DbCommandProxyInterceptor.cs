using System.Data;
using System.Threading.Tasks;
using AspectCore.DynamicProxy;
using AspectCore.Injector;

namespace AspectCore.APM.AdoNetProfiler
{
    public class DbCommandProxyInterceptor : AbstractInterceptor
    {
        public override async Task Invoke(AspectContext context, AspectDelegate next)
        {
            await context.Invoke(next);
            if (context.Implementation is IDbConnection)
            {
                if (context.ReturnValue is IDbCommand command && !command.IsProxy())
                {
                    var proxyGenerator = context.ServiceProvider.Resolve<IProxyGenerator>();
                    context.ReturnValue = proxyGenerator.CreateInterfaceProxy<IDbCommand>(command);
                }
            }
        }
    }
}