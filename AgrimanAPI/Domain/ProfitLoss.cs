namespace AgrimanAPI.Domain
{
    public class ProfitLoss
    {
        public int WorkId { get; private set; }
        public int ThingsId { get; private set; }

        public decimal WorkTotal { get; private set; }
        public decimal ThingsTotal { get; private set; }
        public decimal PackingTotal { get; private set; }

        public decimal ProfitOrLoss { get; private set; }
        public object PackingId { get; internal set; }

        public ProfitLoss(
            int workId,
            int thingsId,
            decimal workTotal,
            decimal thingsTotal,
            decimal packingTotal,
            decimal packingTotal1)
        {
            WorkId = workId;
            ThingsId = thingsId;
            WorkTotal = workTotal;
            ThingsTotal = thingsTotal;
            PackingTotal = packingTotal;

            ProfitOrLoss = workTotal - (thingsTotal + packingTotal);
        }

        public ProfitLoss(int workId, int thingsId, decimal workTotal, decimal thingsTotal, decimal packingTotal)
        {
            WorkId = workId;
            ThingsId = thingsId;
            WorkTotal = workTotal;
            ThingsTotal = thingsTotal;
            PackingTotal = packingTotal;
        }
    }
}
