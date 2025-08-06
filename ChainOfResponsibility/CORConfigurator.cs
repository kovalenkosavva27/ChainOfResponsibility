using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ChainOfResponsibility
{
    /// <summary>
    /// Конфигуратор цепочки через DI.
    /// </summary>
    public class CORConfigurator<TInterface> : ICORConfigurator<TInterface>
        where TInterface : class
    {
        private readonly IServiceCollection _services;
        private readonly List<ConstructorInfo> _constructors = new();

        public CORConfigurator(IServiceCollection services)
        {
            _services = services;
        }

        public ICORConfigurator<TInterface> Add<TImplementation>()
            where TImplementation : class, TInterface
        {
            var ctor = typeof(TImplementation)
                .GetConstructors()
                .Single();

            _constructors.Add(ctor);
            _services.AddScoped(typeof(TImplementation));
            return this;
        }

        public IServiceCollection Configure()
        {
            if (!_constructors.Any())
            {
                throw new InvalidOperationException($"Цепочка {typeof(TInterface).Name} не содержит обработчиков.");
            }

            _services.AddScoped(sp =>
            {
                TInterface? next = default;

                foreach (var ctor in _constructors.AsEnumerable().Reverse())
                {
                    var parameters = ctor.GetParameters()
                        .Select(p => p.ParameterType == typeof(TInterface) ? next : sp.GetRequiredService(p.ParameterType))
                        .ToArray();

                    var current = (TInterface)ctor.Invoke(parameters);
                    next = current;
                }

                return next!;
            });

            return _services;
        }
    }
}
