namespace DespendingMachine.Contracts
{
    public record GoodUpdate(
        string? title,
        decimal? price,
        int? count,
        string? image
        );
}
