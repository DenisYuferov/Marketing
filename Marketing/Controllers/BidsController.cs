using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Marketing.Infrastructure.Providers.Interfaces;
using Marketing.Models;
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

        public async Task<IActionResult> GetAll()
        {
            var bidsViewModel = new BidsViewModel { Bids = await _marketingProvider.Bids.AllAsync() };

            return View(bidsViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var bidAddViewModel = new BidAddViewModel();
            bidAddViewModel.Applications = await _marketingProvider.Applications.AllAsync();
            bidAddViewModel.Banks = await _marketingProvider.Banks.AllAsync();

            return View(bidAddViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BidAddViewModel viewModel)
        {
            var application = await _marketingProvider.Applications.GetByCodeAsync(viewModel.ApplicationCode);
            var bank = await _marketingProvider.Banks.GetByBicAsync(viewModel.BankBic);

            var bid = new Bid
            {
                Name = viewModel.Name, Application = application, EndDate = viewModel.EndDate,
                Description = viewModel.Description, Bank = bank, Email = viewModel.Email, RecordDate = DateTime.Now
            };

            await _marketingProvider.Bids.UpsertAsync(bid);

            return Redirect("/Bids/GetAll");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var bid = await _marketingProvider.Bids.GetByIdAsync(id);
            var application = await _marketingProvider.Applications.GetByCodeAsync(bid.Application.Code);
            var bank = await _marketingProvider.Banks.GetByBicAsync(bid.Bank.Bic);

            var bidEditViewModel = new BidEditViewModel
            {
                Id = bid.Id, Name = bid.Name, Application = bid.Application, ApplicationCode = application.Code,
                EndDate = bid.EndDate, Description = bid.Description,
                Bank = bid.Bank, BankBic = bank.Bic, Email = bid.Email
            };
            bidEditViewModel.Applications = await _marketingProvider.Applications.AllAsync();
            bidEditViewModel.Banks = await _marketingProvider.Banks.AllAsync();

            return View(bidEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BidEditViewModel viewModel)
        {
            var bid = await _marketingProvider.Bids.GetByIdAsync(viewModel.Id);
            var application = await _marketingProvider.Applications.GetByCodeAsync(viewModel.ApplicationCode);
            var bank = await _marketingProvider.Banks.GetByBicAsync(viewModel.BankBic);

            bid.Name = viewModel.Name;
            bid.Application = application;
            bid.EndDate = viewModel.EndDate;
            bid.Description = viewModel.Description;
            bid.Bank = bank;
            bid.Email = viewModel.Email;
            bid.RecordDate = DateTime.Now;

            await _marketingProvider.Bids.UpsertAsync(bid);

            return Redirect("/Bids/GetAll");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(BidEditViewModel viewModel)
        {
            await _marketingProvider.Bids.DeleteAsync(viewModel.Id);

            return Redirect("/Bids/GetAll");
        }
    }
}