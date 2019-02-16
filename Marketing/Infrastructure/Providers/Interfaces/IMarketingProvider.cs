using Marketing.Infrastructure.Repository.Interfaces;

namespace Marketing.Infrastructure.Providers.Interfaces
{
    public interface IMarketingProvider
    {
        IApplicationRepository Applications { get; set; }
        IBankRepository Banks { get; set; }
        IBidRepository Bids { get; set; }
    }
}
