using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Marketing.Infrastructure.Providers.Interfaces;
using Marketing.Models;
using Marketing.ViewModels.ApplicationsViewModels;

namespace Marketing.Controllers
{
    public class ApplicationsController : Controller
    {
        private readonly IMarketingProvider _marketingProvider;

        public ApplicationsController(IMarketingProvider marketingProvider)
        {
            _marketingProvider = marketingProvider;
        }

        public async Task<IActionResult> GetAll()
        {
            var applicationsViewModel = new ApplicationsViewModel { Applications = await _marketingProvider.Applications.AllAsync() };

            return View(applicationsViewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var applicationEditViewModel = new ApplicationAddViewModel();

            return View(applicationEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ApplicationEditViewModel model)
        {
            var application = new Application { Code = model.Code, Name = model.Name, RecordDate = DateTime.Now };

            await _marketingProvider.Applications.UpsertAsync(application);

            return Redirect("/Applications/GetAll");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string code)
        {
            var application = await _marketingProvider.Applications.GetByCodeAsync(code);

            var applicationEditViewModel = new ApplicationEditViewModel { Code = application.Code, Name = application.Name };

            return View(applicationEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ApplicationEditViewModel model)
        {
            var application = new Application{Code = model.Code, Name = model.Name, RecordDate = DateTime.Now};

            await _marketingProvider.Applications.UpsertAsync(application);

            return Redirect("/Applications/GetAll");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(ApplicationEditViewModel model)
        {
            await _marketingProvider.Applications.DeleteAsync(model.Code);

            return Redirect("/Applications/GetAll");
        }
    }
}
