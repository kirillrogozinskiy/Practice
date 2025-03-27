namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Путь к тестовой папке (измените при необходимости)
            string testFolder = Path.Combine(Environment.CurrentDirectory, "FileWatcherTest");

            try
            {
                Directory.CreateDirectory(testFolder);
                Console.WriteLine($"Тестовая папка: {testFolder}");

                using FileWatcher fileWatcher = new FileWatcher(testFolder);

                Console.WriteLine("FileWatcher запущен. Выполните действия в папке:");
                Console.WriteLine("1. Создайте любой файл");
                Console.WriteLine("2. Создайте файл .tmp (будет автоматически удалён)");
                Console.WriteLine("3. Измените содержимое файла");
                Console.WriteLine("4. Переименуйте файл");
                Console.WriteLine("5. Удалите файл");
                Console.WriteLine("\nНажмите Enter для выхода...");

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            finally
            {
                Directory.Delete(testFolder, true);
            }
        }
    }
}
