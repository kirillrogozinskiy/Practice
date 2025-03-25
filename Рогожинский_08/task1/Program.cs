namespace task1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                List<User> users = new List<User>
                {
                    new User("Admin", 1),
                    new User("User", 2)
                };

                UserManager manager = new UserManager(users);
                manager.DeleteUser(2);
                
                foreach (User user in users)
                {
                    Console.WriteLine($"{user.Id}, {user.Role}");
                }

                manager.DeleteUser(1);
            }
            catch (AdminDeletionException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}