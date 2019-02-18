using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketing.Models
{ 
    public class Bid
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Code")]
        public Application Application { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        [ForeignKey("Bic")]
        public Bank Bank { get; set; }
        public string Email { get; set; }
        public DateTime RecordDate { get; set; }
    }
}
