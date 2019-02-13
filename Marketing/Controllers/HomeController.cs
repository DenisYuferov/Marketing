using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Marketing.Services.Interfaces;
using Marketing.ViewModels.Home;

namespace Marketing.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMarketingService _marketingService;

        public HomeController(IMarketingService marketingService)
        {
            _marketingService = marketingService;
        }

        public IActionResult Index()
        {
            var indexViewModel = new IndexViewModel();

            return View(indexViewModel);
        }

        public async Task<IActionResult> Application()
        {
            var applicationViewModel = await  _marketingService.GetApplicationViewModelAsync();

            return View(applicationViewModel);
        }

        public async Task<IActionResult> Bank()
        {
            var bankViewModel = await _marketingService.GetBankViewModelAsync();

            return View(bankViewModel);
        }

        public IActionResult Bid()
        {
            var bidViewModel = new BidViewModel();

            return View(bidViewModel);
        }
    }
}
