namespace task1
{
    public class UserManager
    {
        public List<User> Users { get; set; }

        public UserManager(List<User> users)
        {
            Users = users;
        }

        public List<User> DeleteUser(int id)
        {
            try
            {
                User userToRemove = Users.FirstOrDefault(u => u.Id == id);
                if (userToRemove.Role.ToLower() == "admin")
                {
                    throw new AdminDeletionException(userToRemove.Id);
                }
                
                Users.Remove(userToRemove);
                return Users;
            }
            catch(ArgumentNullException e)
            {
                Console.WriteLine($"{e.Message}");
            }
            return Users;
        }
    }
}
