using CalculatorService.Application.Journal.Interfaces;
using CalculatorService.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CalculatorService.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddSingleton<IJournalOperationRepository, JournalOperationRepository>();

            return services;
        }
    }
}
