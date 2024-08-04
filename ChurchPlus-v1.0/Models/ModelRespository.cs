using System;

namespace ChurchPlus_v1._0.Models
{
    public class AuthResponse
    {
       public string Status { get; set; }
       public string Message { get; set; }
       public string Token { get; set; }
       public int UserId { get; set; }
    }
    public class UserLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        
    }
    public class VMUserProfile
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public int SatelliteId { get; set; }
        public int Role { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public int ForcePasswordChange { get; set; }
        public int Status { get; set; }
    }
    public class UserProfileDetail
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Satellite { get; set; }
        public int SatelliteId { get; set; }
        public int UserRole { get; set; }
        public string RoleName { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public int Status { get; set; }
        public DateTime? LastSignedOnDate { get; set; }

    }
    public class ResponseObject
    {
        public int Id { get; set;}
        public string Status { get; set; }
        public string Message { get; set; }
    }
}