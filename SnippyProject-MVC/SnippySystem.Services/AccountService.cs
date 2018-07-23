using SnippySystem.Models.EntityModels;

namespace SnippySystem.Services
{
    public class AccountService:Service
    {
        public void CreateUserLogged(ApplicationUser user)
        {
            UserLogged userLog = new UserLogged();
            ApplicationUser currentUser = this.Context.Users.Find(user.Id);
            userLog.User = currentUser;
            this.Context.UserLoggeds.Add(userLog);
            this.Context.SaveChanges();
        }
    }
}