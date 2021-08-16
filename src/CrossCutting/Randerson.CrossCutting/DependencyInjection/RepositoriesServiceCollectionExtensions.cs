using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization;
using Randerson.Domain.Entities;
using Randerson.Domain.Repositories;
using Randerson.Infrastructure.Repositories;

namespace Randerson.CrossCutting.DependencyInjection
{
    public static class RepositoriesServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMongoClient<Customer, string>(configuration);
            BsonClassMap.RegisterClassMap<Customer>(cm => cm.AutoMap());
            services.AddTransient<ICustomerReadRepository, CustomerReadRepository>();
            return services;
        }
    }
}