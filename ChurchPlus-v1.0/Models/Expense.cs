using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChurchPlus_v1._0.Models
{
    public class Expense
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime DateIncurred { get; set; }
        public int ReceiptNumber { get; set; }
        public string Purpose { get; set; }
        public int CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public int Status { get; set; }

    }
}