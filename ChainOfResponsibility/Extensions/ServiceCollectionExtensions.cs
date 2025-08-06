using ChainOfResponsibility.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace ChainOfResponsibility.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddChainOfResponsibility(this IServiceCollection services)
        {
            return services
                .Chain<IChainHandler<string>>()
                .Add<TrimHandler>()
                .Add<UpperCaseHandler>()
                .Configure();
        }

        private static ICORConfigurator<T> Chain<T>(this IServiceCollection services)
            where T : class
        {
            return new CORConfigurator<T>(services);
        }
    }
}
