namespace task1
{
    public class FileInfoProvider
    {
        public static void GetFileInfo(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Файл не существует.");
                return;
            }

            FileInfo fileInfo = new FileInfo(path);
            Console.WriteLine("\nИнформация о файле:");
            Console.WriteLine($"Имя файла: {fileInfo.Name}");
            Console.WriteLine($"Полный путь: {fileInfo.FullName}");
            Console.WriteLine($"Размер: {fileInfo.Length} байт");
            Console.WriteLine($"Дата создания: {fileInfo.CreationTime}");
            Console.WriteLine($"Дата последнего изменения: {fileInfo.LastWriteTime}");
            Console.WriteLine($"Дата последнего доступа: {fileInfo.LastAccessTime}");
        }

        public static void CompareFilesBySize(string path1, string path2)
        {
            FileInfo file1 = new FileInfo(path1);
            FileInfo file2 = new FileInfo(path2);

            if (!file1.Exists || !file2.Exists)
            {
                Console.WriteLine("Один из файлов не существует.");
                return;
            }

            if (file1.Length == file2.Length)
                Console.WriteLine("Файлы имеют одинаковый размер.");
            else
                Console.WriteLine($"Файлы имеют разный размер: {file1.Length} байт vs {file2.Length} байт");
        }

        public static void CheckFilePermissions(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            if (!fileInfo.Exists)
            {
                Console.WriteLine("Файл не существует.");
                return;
            }
            string CheckIsReadOnly = fileInfo.IsReadOnly ? "Нет" : "Да";

            Console.WriteLine($"Права доступа к файлу {path}:");
            Console.WriteLine($"Чтение: {CheckIsReadOnly}");
            Console.WriteLine($"Только для чтения: {fileInfo.IsReadOnly}");
        }
    }
}
