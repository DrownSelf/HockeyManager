using System.Collections.Generic;

namespace HockeyManager.Models
{
    public class SetRoleRequest
    {
        public string UserId { get; set; }
        public List<string> Roles { get; set; }
    }
}