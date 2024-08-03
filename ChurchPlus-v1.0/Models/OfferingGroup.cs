using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChurchPlus_v1._0.Models
{
    public class OfferingGroup
    {
       [Key]
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int Id { get; set; }
       public string GroupName { get; set; } //Sunday service, Wednesday service, Friday service, Sunday school
       public int CreatedBy { get; set; }
       public DateTime DateCreated { get; set; }
       public int ModifiedBy { get; set; }
       public DateTime? DateModified { get; set; }
       public int Status { get; set; }
    }
}