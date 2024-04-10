namespace DespendingMachine.Contracts
{
    public record GoodResponse(
        Guid id,
        string title,
        decimal price,
        int count,
        string image);
}