using Marketing.Repository.Interfaces;

namespace Marketing.Repository
{
    public class MarketingRepository : IMarketingRepository
    {
        public IApplicationRepository Applications { get; set; }
        public IBankRepository Banks { get; set; }
        public IBidRepository Bids { get; set; }

        public MarketingRepository (IApplicationRepository applications, IBankRepository banks, IBidRepository bids)
        {
            Applications = applications;
            Banks = banks;
            Bids = bids;
        }
    }
}
