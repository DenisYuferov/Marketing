using System.Collections.Generic;
using Marketing.Data.Entities;

namespace Marketing.ViewModels.Home
{
    public class ApplicationViewModel
    {
        public ApplicationViewModel()
        {
            Header = "Applications";
        }
        public string Header { get; set; }
        public IEnumerable<Application> Applications { get; set; }
    }
}
