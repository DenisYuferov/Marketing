using System;
using System.Collections.Generic;

namespace Marketing.Models.Home
{
    public class BidModel
    {
        public BidModel()
        {
            Header = "Bids";

            var app = new Data.Tables.Application {Code = "123", Name = "Name"};

            var bank = new Data.Tables.Bank {Bic = "123123123", Name = "Банк суровый"};

            var bid = new Data.Tables.Bid
            {
                Id = 321,
                Name = "Заявка на покупку",
                Application = app,
                EndDate = DateTime.Now.AddDays(10),
                Description = "Срочно нужно купить!",
                Bank = bank,
                Email = "mail@mail.ru"
            };


            Bids = new List<Data.Tables.Bid> {bid};
        }
        public string Header { get; set; }
        public IEnumerable<Data.Tables.Bid> Bids { get; set; }
    }
}
