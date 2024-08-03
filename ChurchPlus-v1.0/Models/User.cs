using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChurchPlus_v1._0.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string MiddleNme { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public int ChurchLocation { get; set; }
        public DateTime? LastSignedOn {get; set; }
        public int Status { get; set; }
        public int RoleId { get; set; }
        public int CumulativeLogin {get; set; }
        public int CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public string Email {get; set;}
        public string MobileNumber {get; set;}  
    }
}