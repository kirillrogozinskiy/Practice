namespace task1
{
    public class AdminDeletionException : Exception
    {
        public int Username { get; }

        public AdminDeletionException(int username)
            : base($"Попытка удалить пользователя '{username}' с ролью Admin запрещена")
        {
            Username = username;
        }
    }
}
