using System;
using System.ComponentModel.DataAnnotations;

namespace Marketing.Models
{
    public class Bank
    {
        [Key]
        public string Bic { get; set; }
        public string Name { get; set; }
        public DateTime RecordDate { get; set; }
    }
}
