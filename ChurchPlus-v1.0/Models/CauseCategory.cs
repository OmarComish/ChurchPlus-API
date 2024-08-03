using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using DocumentFormat.OpenXml.Bibliography;

namespace ChurchPlus_v1._0.Models
{
    public class CauseCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CauseName { get; set; } //PROJECT,CHARITY,EVENTS,Church service,
        public int CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public int Status { get; set; }
    }
}