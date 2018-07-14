using System;
using System.Threading.Tasks;
using VelUp.Models;

namespace VelUp.Services.Authorization
{
    public interface IAuthorizationService
    {
        Task<AOResult> LoginAsync(string email, string password);

        Task LogoutAsync();
    }
}
