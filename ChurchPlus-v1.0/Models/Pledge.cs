using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChurchPlus_v1._0.Models
{
    public class Pledge 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PledgeId { get; set; }
        public double AmountPledged { get; set; }
        public double ActualAmountFulfilled { get; set; }
        public DateTime DatePledged { get; set; }
        public DateTime? DateFulfilled { get; set; }
        public int ReceivedBy { get; set; }
        public int ApprovedBy { get; set; }
        public DateTime DateApproved { get; set; }
        public DateTime DateCreated {get; set;}  
        public int Status { get; set; }
        public DateTime? DateModified { get; set; }
    }
}