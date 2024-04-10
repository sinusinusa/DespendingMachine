namespace DespendingMachine.Contracts
{
    public record GoodRequest(
        string title,
        decimal price,
        int count,
        string image);
}