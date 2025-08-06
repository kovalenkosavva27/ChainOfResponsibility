namespace ChainOfResponsibility.Handlers
{
    public class TrimHandler : ChainHandlerBase<string>, IChainHandler<string>
    {
        public TrimHandler(IChainHandler<string>? next) : base(next) { }

        protected override Task HandleInternalAsync(string context, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Trimmed: {context.Trim()}");
            return Task.CompletedTask;
        }
    }
}
