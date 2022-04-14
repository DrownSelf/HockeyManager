using HockeyManager.Models;

namespace HockeyManager.Services
{
    public interface ISignInService
    {
        public Task<bool> PasswordSignInAsync(LogInRequest logInRequest);

        public Task SignOutAsync();
    }
}
