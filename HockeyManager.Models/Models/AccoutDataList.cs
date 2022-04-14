namespace HockeyManager.Models
{
    public class UserRoles
    {
        public string UserEmail { get; set; }

        public string UserId { get; set; }

        public int USDSalary { get; set; }

        public IList<string> Roles { get; set; }
    }
}