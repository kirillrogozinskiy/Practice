namespace task3
{  
    public class NotificationService
    {
        public void OnUserLoggedIn(object sender, UserLoggedInEventArgs e)
        {
            Console.WriteLine($"[NotificationService] Уведомление об успешном входе пользователя {e.Username} отправлено.");
        }
    }
}
