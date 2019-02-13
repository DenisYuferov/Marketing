using Marketing.Providers.Interfaces;
using Marketing.Repository.Interfaces;

namespace Marketing.Providers
{
    public class MarketingProvider : IMarketingProvider
    {
        public IApplicationRepository Applications { get; set; }
        public IBankRepository Banks { get; set; }
        public IBidRepository Bids { get; set; }

        public MarketingProvider (IApplicationRepository applications, IBankRepository banks, IBidRepository bids)
        {
            Applications = applications;
            Banks = banks;
            Bids = bids;
        }
    }
}
