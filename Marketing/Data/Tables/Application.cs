using System.ComponentModel.DataAnnotations;

namespace Marketing.Data.Tables
{
    public class Application
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
