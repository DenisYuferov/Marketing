using System.ComponentModel.DataAnnotations;

namespace Marketing.Data.Tables
{
    public class Bank
    {
        [Key]
        public string Bic { get; set; }
        public string Name { get; set; }
    }
}
