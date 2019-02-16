using Microsoft.AspNetCore.Mvc;
using Marketing.Infrastructure.Providers.Interfaces;
using Marketing.ViewModels.BidsViewModels;

namespace Marketing.Controllers
{
    public class BidsController : Controller
    {
        private readonly IMarketingProvider _marketingProvider;

        public BidsController(IMarketingProvider marketingProvider)
        {
            _marketingProvider = marketingProvider;
        }

        public IActionResult Bid()
        {
            var bidViewModel = new BidViewModel();

            return View(bidViewModel);
        }
    }
}
