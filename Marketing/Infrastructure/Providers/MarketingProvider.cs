using Marketing.Infrastructure.Providers.Interfaces;
using Marketing.Infrastructure.Repository.Interfaces;

namespace Marketing.Infrastructure.Providers
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
