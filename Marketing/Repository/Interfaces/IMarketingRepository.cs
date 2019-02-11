namespace Marketing.Repository.Interfaces
{
    public interface IMarketingRepository
    {
        IApplicationRepository Applications { get; set; }
        IBankRepository Banks { get; set; }
        IBidRepository Bids { get; set; }
    }
}
