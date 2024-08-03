using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChurchPlus_v1._0.Models;
using Microsoft.AspNetCore.Identity;

namespace ChurchPlus_v1._0.AuthService
{
    public interface ISecureSignin
    {
        string Encrypt(string cleartext);
        string Decrypt(string decipheredtext);
    }
    public interface ITokenService
    {
        string GenerateToken(string username);
    }
    public interface IAuthManager
    {
        Task<AuthResponse> Authenticate(UserLogin userlogin);
    }
}