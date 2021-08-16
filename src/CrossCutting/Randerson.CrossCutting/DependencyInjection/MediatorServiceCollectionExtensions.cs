using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Randerson.CrossCutting.DependencyInjection
{
    public static class MediatorServiceCollectionExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("Randerson.Application");
            services.AddMediatR(assembly);
            return services;
        }
    }
}
