namespace ChainOfResponsibility.Handlers
{
    /// <summary>
    /// Базовый обработчик цепочки.
    /// </summary>
    public abstract class ChainHandlerBase<TContext> : IChainHandler<TContext>
    {
        private readonly IChainHandler<TContext>? _next;

        protected ChainHandlerBase(IChainHandler<TContext>? next)
        {
            _next = next;
        }

        public async Task HandleAsync(TContext context, CancellationToken cancellationToken)
        {
            await HandleInternalAsync(context, cancellationToken);

            if (_next is not null)
            {
                await _next.HandleAsync(context, cancellationToken);
            }
        }

        /// <summary>
        /// Логика конкретного обработчика.
        /// </summary>
        protected abstract Task HandleInternalAsync(TContext context, CancellationToken cancellationToken);
    }
}
