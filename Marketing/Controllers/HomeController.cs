using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Marketing.Models.Home;
using Marketing.Services.Interfaces;

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
            var indexModel = new IndexModel();

            return View(indexModel);
        }

        public async Task<IActionResult> Application()
        {
            var applicationModel = await  _marketingService.GetApplicationModel();

            return View(applicationModel);
        }

        public async Task<IActionResult> Bank()
        {
            var bankModel = await _marketingService.GetBankModel();

            return View(bankModel);
        }

        public IActionResult Bid()
        {
            var bidModel = new BidModel();

            return View(bidModel);
        }
    }
}
