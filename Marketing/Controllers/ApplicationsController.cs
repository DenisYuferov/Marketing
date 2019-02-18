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
            var applicationAddViewModel = new ApplicationAddViewModel();

            return View(applicationAddViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ApplicationAddViewModel viewModel)
        {
            var application = new Application { Code = viewModel.Code, Name = viewModel.Name, RecordDate = DateTime.Now };

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
        public async Task<IActionResult> Edit(ApplicationEditViewModel viewModel)
        {
            var application = new Application{Code = viewModel.Code, Name = viewModel.Name, RecordDate = DateTime.Now};

            await _marketingProvider.Applications.UpsertAsync(application);

            return Redirect("/Applications/GetAll");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(ApplicationEditViewModel viewModel)
        {
            await _marketingProvider.Applications.DeleteAsync(viewModel.Code);

            return Redirect("/Applications/GetAll");
        }
    }
}
