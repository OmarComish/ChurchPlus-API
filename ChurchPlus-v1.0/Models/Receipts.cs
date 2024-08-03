using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChurchPlus_v1._0.Models
{
    public class Receipts
    {
        [Key]
        public int Id { get; set; }
        public string ReceiptLocation { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; } 
        public int Status { get; set; }

    }
}