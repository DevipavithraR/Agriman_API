namespace AgrimanAPI.Domain
{
    public class ProfitLoss
    {
        public int WorkId { get; private set; }
        public int ThingsId { get; private set; }
        public int PackingId { get; private set; }

        public decimal WorkTotal { get; private set; }
        public decimal ThingsTotal { get; private set; }
        public decimal PackingTotal { get; private set; }

        public decimal ProfitOrLoss { get; private set; }

        public ProfitLoss(int workId, int thingsId, int packingId, decimal workTotal, decimal thingsTotal, decimal packingTotal)
        {
            WorkId = workId;
            ThingsId = thingsId;
            PackingId = packingId;

            WorkTotal = workTotal;
            ThingsTotal = thingsTotal;
            PackingTotal = packingTotal;

            ProfitOrLoss = WorkTotal + ThingsTotal - PackingTotal;
        }
    }
}
