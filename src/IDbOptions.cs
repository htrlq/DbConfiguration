namespace DbConfiguration
{
    public interface IDbOptions<TOptions> where TOptions : class
    {
        TOptions Value { get; }
    }
}
