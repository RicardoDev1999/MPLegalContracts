using Microsoft.Extensions.DependencyInjection;
using MPLegalContracts.Services.LegalContracts;
using MPLegalContracts.Services.Mappers;

namespace MPLegalContracts.Services
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            return services
                .ConfigureApplicationMapper()
                .AddTransient<ILegalContractServices, LegalContractServices>();
        }
    }
}
