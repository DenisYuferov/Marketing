using System.Collections.Generic;

namespace Marketing.Models.Home
{
    public class BankModel
    {
        public BankModel()
        {
            Header = "Banks";

            //var bank = new Data.Tables.Bank();
            //bank.Bic = "12312332";
            //bank.Name = "Банк суровый";

            //Banks = new List<Data.Tables.Bank>{bank};
        }
        public string Header { get; set; }
        public IEnumerable<Data.Tables.Bank> Banks { get; set; }
    }
}
