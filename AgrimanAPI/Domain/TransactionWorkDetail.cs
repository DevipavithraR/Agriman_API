public class TransactionWorkDetail
{
    public int Id { get; set; }
    public int WorkId { get; set; }
    public string WorkName { get; set; } = null!;
    public int WorkersCount { get; set; }
    public decimal Amount { get; set; }

    public TransactionWorkDetail() { }

    public TransactionWorkDetail(int id, int workId, string workName, int workersCount, decimal amount)
    {
        Id = id;
        WorkId = workId;
        WorkName = workName;       // ✅ assign property, not private field
        WorkersCount = workersCount;
        Amount = amount;
    }
}
