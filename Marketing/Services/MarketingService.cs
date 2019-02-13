using System.Threading.Tasks;
using Marketing.Providers.Interfaces;
using Marketing.Services.Interfaces;
using Marketing.ViewModels.Home;

namespace Marketing.Services
{
    public class MarketingService : IMarketingService
    {
        private readonly IMarketingProvider _marketingProvider;

        public MarketingService(IMarketingProvider marketingProvider)
        {
            _marketingProvider = marketingProvider;
        }

        public async Task<ApplicationViewModel> GetApplicationViewModelAsync()
        {
            var applicationViewModel = new ApplicationViewModel {Applications = await _marketingProvider.Applications.AllAsync()};

            return applicationViewModel;
        }

        public async Task<BankViewModel> GetBankViewModelAsync()
        {
            var bankViewModel = new BankViewModel { Banks = await _marketingProvider.Banks.AllAsync() };

            return bankViewModel;
        }
    }
}
