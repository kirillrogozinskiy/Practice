namespace task3
{
    class UserLoginManager
    {
        public event UserLoggedInEventHandler UserLoggedIn;

        public void LoginUser(string username)
        {
            Console.WriteLine($"Попытка входа пользователя: {username}");

            Console.WriteLine($"Пользователь {username} успешно аутентифицирован.");

            OnUserLoggedIn(new UserLoggedInEventArgs(username));
        }
        protected virtual void OnUserLoggedIn(UserLoggedInEventArgs e)
        {
            UserLoggedIn?.Invoke(this, e);
        }
    }
}
