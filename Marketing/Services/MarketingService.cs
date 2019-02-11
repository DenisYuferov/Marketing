using System.Threading.Tasks;
using Marketing.Models.Home;
using Marketing.Repository.Interfaces;
using Marketing.Services.Interfaces;

namespace Marketing.Services
{
    public class MarketingService : IMarketingService
    {
        private readonly IMarketingRepository _marketingRepository;

        public MarketingService(IMarketingRepository marketingRepository)
        {
            _marketingRepository = marketingRepository;
        }

        public async Task<ApplicationModel> GetApplicationModel()
        {
            var appModel = new ApplicationModel {Applications = await _marketingRepository.Applications.All()};

            return appModel;
        }

        public async Task<BankModel> GetBankModel()
        {
            var bankModel = new BankModel { Banks = await _marketingRepository.Banks.All() };

            return bankModel;
        }
    }
}
