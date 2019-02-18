using System;
using System.Collections.Generic;
using Marketing.Models;

namespace Marketing.ViewModels.BidsViewModels
{
    public class BidEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Application Application { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public Bank Bank { get; set; }
        public string Email { get; set; }
        public string ApplicationCode { get; set; }
        public IEnumerable<Application> Applications { get; set; }
        public string BankBic { get; set; }
        public IEnumerable<Bank> Banks { get; set; }
    }
}
