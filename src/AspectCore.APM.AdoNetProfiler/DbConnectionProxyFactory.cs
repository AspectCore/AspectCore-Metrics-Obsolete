using System;
using System.Data;
using AspectCore.DynamicProxy;

namespace AspectCore.APM.AdoNetProfiler
{
    public class DbConnectionProxyFactory : IDbConnectionProxyFactory
    {
        private readonly IProxyGenerator _proxyGenerator;

        public DbConnectionProxyFactory(IProxyGenerator proxyGenerator)
        {
            _proxyGenerator = proxyGenerator ?? throw new ArgumentNullException(nameof(proxyGenerator));
        }

        public IDbConnection CreateConnectionProxy(IDbConnection connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (connection.IsProxy())
            {
                return connection;
            }
            return _proxyGenerator.CreateInterfaceProxy<IDbConnection>(connection);
        }
    }
}