using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Marketing.Infrastructure.Providers.Interfaces;
using Marketing.Models;
using Marketing.ViewModels.BanksViewModels;

namespace Marketing.Controllers
{
    public class BanksController : Controller
    {
        private readonly IMarketingProvider _marketingProvider;

        public BanksController(IMarketingProvider marketingProvider)
        {
            _marketingProvider = marketingProvider;
        }

        public async Task<IActionResult> GetAll()
        {
            var banksViewModel = new BanksViewModel { Banks = await _marketingProvider.Banks.AllAsync() };

            return View(banksViewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var bankEditViewModel = new BankAddViewModel();

            return View(bankEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BankEditViewModel viewModel)
        {
            var bank = new Bank { Bic = viewModel.Bic, Name = viewModel.Name, RecordDate = DateTime.Now };

            await _marketingProvider.Banks.UpsertAsync(bank);

            return Redirect("/Banks/GetAll");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string bic)
        {
            var bank = await _marketingProvider.Banks.GetByBicAsync(bic);

            var bankEditViewModel = new BankEditViewModel { Bic = bank.Bic, Name = bank.Name };

            return View(bankEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BankEditViewModel viewModel)
        {
            var bank = new Bank { Bic = viewModel.Bic, Name = viewModel.Name, RecordDate = DateTime.Now };

            await _marketingProvider.Banks.UpsertAsync(bank);

            return Redirect("/Banks/GetAll");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(BankEditViewModel viewModel)
        {
            await _marketingProvider.Banks.DeleteAsync(viewModel.Bic);

            return Redirect("/Banks/GetAll");
        }
    }
}
