using Microsoft.Extensions.DependencyInjection;

namespace MPLegalContracts.Services.Mappers
{
    public static class ApplicationMapperExtensions
    {
        public static IServiceCollection ConfigureApplicationMapper(this IServiceCollection services)
        {
            return services.AddAutoMapper(typeof(ApplicationMapperExtensions));
        }
    }
}
