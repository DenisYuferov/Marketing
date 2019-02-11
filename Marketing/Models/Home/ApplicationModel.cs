using System.Collections.Generic;

namespace Marketing.Models.Home
{
    public class ApplicationModel
    {
        public ApplicationModel()
        {
            Header = "Applications";

            //var app = new Data.Tables.Application();
            //app.Id = 123;
            //app.Name = "Name";

            //Applications = new List<Data.Tables.Application>{app};
        }
        public string Header { get; set; }
        public IEnumerable<Data.Tables.Application> Applications { get; set; }
    }
}
