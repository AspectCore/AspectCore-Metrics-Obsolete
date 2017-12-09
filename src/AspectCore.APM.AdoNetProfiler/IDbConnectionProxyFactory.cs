using System.Data;
using AspectCore.DynamicProxy;

namespace AspectCore.APM.AdoNetProfiler
{
    [NonAspect]
    public interface IDbConnectionProxyFactory
    {
        IDbConnection CreateConnectionProxy(IDbConnection connection);
    }
}