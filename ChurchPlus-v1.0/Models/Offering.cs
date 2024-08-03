using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChurchPlus_v1._0.Models
{
    public class Offering
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int OfferingGroupId { get; set; }
        public int CollectedBy { get; set; }
        public double Amount { get; set; }
        public DateTime CollectionDate { get; set; }
        public int ServiceSession { get; set; }
        public int CheckedBy { get; set; }
        public DateTime DateChecked { get; set; }
        public int Status { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
    }
}