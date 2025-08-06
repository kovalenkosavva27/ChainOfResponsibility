namespace ChainOfResponsibility.Handlers
{
    /// <summary>
    /// Базовый интерфейс обработчика цепочки.
    /// </summary>
    public interface IChainHandler<TContext>
    {
        /// <summary>
        /// Выполняет обработку и передаёт управление следующему обработчику.
        /// </summary>
        Task HandleAsync(TContext context, CancellationToken cancellationToken);
    }
}
