using System.Threading.Tasks;
using Marketing.ViewModels.Home;

namespace Marketing.Services.Interfaces
{
    public interface IMarketingService
    {
        Task<ApplicationViewModel> GetApplicationViewModelAsync();
        Task<BankViewModel> GetBankViewModelAsync();
    }
}
