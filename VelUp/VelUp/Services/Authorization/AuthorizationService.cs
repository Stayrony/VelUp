using System;
using System.Threading.Tasks;
using VelUp.Models;

namespace VelUp.Services.Authorization
{
    public class AuthorizationService : IAuthorizationService
    {
        public AuthorizationService()
        {
        }

        #region -- IAuthorizationService immpelementation --

        public async Task<AOResult> LoginAsync(string email, string password)
        {
            var res = new AOResult();

            try
            {
                //Implement login logic
                await Task.Delay(500);
                res.SetSuccess();
            }
            catch (Exception ex)
            {
                res.SetError(nameof(LoginAsync), ex.Message, ex);
            }

            return res;
        }

        public async Task<AOResult> LogoutAsync()
        {
            var res = new AOResult();

            try
            {
                //Implement logout logic
                await Task.Delay(500);
                res.SetSuccess();
            }
            catch (Exception ex)
            {
                res.SetError(nameof(LogoutAsync), ex.Message, ex);
            }

            return res;
        }

        #endregion
    }
}
