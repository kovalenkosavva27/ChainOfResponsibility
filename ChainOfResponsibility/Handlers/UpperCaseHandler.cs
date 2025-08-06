namespace ChainOfResponsibility.Handlers
{
    public class UpperCaseHandler : ChainHandlerBase<string>, IChainHandler<string>
    {
        public UpperCaseHandler(IChainHandler<string>? next) : base(next) { }

        protected override Task HandleInternalAsync(string context, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Upper: {context.ToUpper()}");
            return Task.CompletedTask;
        }
    }
}
