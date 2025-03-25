namespace task1
{
    public class User
    {
        public string Role { get; set; }
        public int Id { get; set; }

        public User(string role, int id)
        {
            Role = role;
            Id = id;
        }
    }
}
