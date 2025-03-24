namespace task3
{
    public delegate void UserLoggedInEventHandler(object sender, UserLoggedInEventArgs e);
    public class UserLoggedInEventArgs : EventArgs
    {
        public string Username { get; set; }
        public DateTime LoginTime { get; set; }

        public UserLoggedInEventArgs(string username)
        {
            Username = username;
            LoginTime = DateTime.Now;
        }
    }
}
