using Microsoft.AspNetCore.Mvc;
using Marketing.ViewModels.HomeViewModels;

namespace Marketing.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Home()
        {
            var homeViewModel = new HomeViewModel();

            return View(homeViewModel);
        }
    }
}
