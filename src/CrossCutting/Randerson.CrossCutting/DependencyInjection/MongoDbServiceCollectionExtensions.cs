using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Randerson.Domain.Data;
using Randerson.Infrastructure.MongoDb;

namespace Randerson.CrossCutting.DependencyInjection
{
    public static class MongoDbServiceCollectionExtensions
    {
        public static IServiceCollection AddMongoClient<TEntity, TId>(this IServiceCollection services, IConfiguration configuration)
            where TEntity : BaseEntity<TId>

        {
            var name = GetNameWithoutGenerics(typeof(TEntity));
            var config = configuration.GetSection($"MongoConfig:{name}");
            var clientConfig = config.Get<MongoConfig>();

            if (clientConfig == null)
            {
                throw new InvalidOperationException($"The configuration section 'MongoDB:{name} was not found");
            }

            return services.AddScoped((context) =>
            {
                return new MongoDbClient<TEntity, TId>(clientConfig);
            });
        }

        private static object GetNameWithoutGenerics(Type t)
        {
            string name = t.Name;
            int index = name.IndexOf('`');
            return index == -1 ? name : name.Substring(0, index);
        }
    }
}
