using Marketing.Repository.Interfaces;

namespace Marketing.Providers.Interfaces
{
    public interface IMarketingProvider
    {
        IApplicationRepository Applications { get; set; }
        IBankRepository Banks { get; set; }
        IBidRepository Bids { get; set; }
    }
}
