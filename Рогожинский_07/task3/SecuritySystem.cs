namespace task3
{
    public class SecuritySystem
    {
        public void OnUserLoggedIn(object sender, UserLoggedInEventArgs e)
        {
            Console.WriteLine($"[SecuritySystem] Проверка доступа пользователя {e.Username}...");
           
            Console.WriteLine($"[SecuritySystem] Доступ пользователя {e.Username} подтвержден.");
        }
    }
}
