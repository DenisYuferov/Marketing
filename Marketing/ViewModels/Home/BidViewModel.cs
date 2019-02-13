using System;
using System.Collections.Generic;
using Marketing.Data.Entities;

namespace Marketing.ViewModels.Home
{
    public class BidViewModel
    {
        public BidViewModel()
        {
            Header = "Bids";

            var app = new Application {Code = "123", Name = "Name"};

            var bank = new Bank {Bic = "123123123", Name = "Банк суровый"};

            var bid = new Bid
            {
                Id = 321,
                Name = "Заявка на покупку",
                Application = app,
                EndDate = DateTime.Now.AddDays(10),
                Description = "Срочно нужно купить!",
                Bank = bank,
                Email = "mail@mail.ru"
            };


            Bids = new List<Bid> {bid};
        }
        public string Header { get; set; }
        public IEnumerable<Bid> Bids { get; set; }
    }
}
