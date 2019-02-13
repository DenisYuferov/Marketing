using System.Collections.Generic;
using Marketing.Data.Entities;

namespace Marketing.ViewModels.Home
{
    public class BankViewModel
    {
        public BankViewModel()
        {
            Header = "Banks";
        }
        public string Header { get; set; }
        public IEnumerable<Bank> Banks { get; set; }
    }
}
