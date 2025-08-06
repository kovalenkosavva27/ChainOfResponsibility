using Microsoft.Extensions.DependencyInjection;

namespace ChainOfResponsibility
{
    /// <summary>
    /// Конфигуратор цепочки обязанностей.
    /// </summary>
    /// <typeparam name="TInterface">Тип интерфейса.</typeparam>
    public interface ICORConfigurator<TInterface>
        where TInterface : class
    {
        /// <summary>
        /// Добавляет реализацию интерфейса в цепочку.
        /// </summary>
        ICORConfigurator<TInterface> Add<TImplementation>()
            where TImplementation : class, TInterface;

        /// <summary>
        /// Создаёт цепочку.
        /// </summary>
        IServiceCollection Configure();
    }
}
