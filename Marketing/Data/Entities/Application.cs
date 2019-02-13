using System;
using System.ComponentModel.DataAnnotations;

namespace Marketing.Data.Entities
{
    public class Application
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime RecordDate { get; set; }
    }
}
