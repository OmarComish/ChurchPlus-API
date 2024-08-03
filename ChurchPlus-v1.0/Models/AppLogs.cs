using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ChurchPlus_v1._0.Models
{
    public class AppLogs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Activity {  get; set; }
        public int ActivityInitiator { get; set; }
        public DateTime TimeStarted { get; set; }
        public DateTime TimeCompleted { get; set; }
        public string Status { get; set; }
        public string StatusMessage { get; set; }
    }
}