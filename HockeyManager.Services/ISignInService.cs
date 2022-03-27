using HockeyManager.DataLayer;
using HockeyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyManager.Services
{
    public interface ISignInService
    {
        public Task<bool> PasswordSignInAsync(LogInRequest logInRequest);

        public Task SignOutAsync();
    }
}
