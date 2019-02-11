using System.Threading.Tasks;
using Marketing.Models.Home;

namespace Marketing.Services.Interfaces
{
    public interface IMarketingService
    {
        Task<ApplicationModel> GetApplicationModel();
        Task<BankModel> GetBankModel();
    }
}
