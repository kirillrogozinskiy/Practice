namespace task3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            UserLoginManager loginManager = new UserLoginManager();

            SecuritySystem securitySystem = new SecuritySystem();
            NotificationService notificationService = new NotificationService();

            loginManager.UserLoggedIn += securitySystem.OnUserLoggedIn;
            loginManager.UserLoggedIn += notificationService.OnUserLoggedIn;

            loginManager.LoginUser("User");
        }
    }
}
