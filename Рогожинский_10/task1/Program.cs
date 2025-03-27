namespace task1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // 1. Создать файл, записать в него текст, прочитать и вывести в консоль
            string path1 = "test1.txt";
            FileManager.CreateFile(path1, "Пример текста для первого файла");
            string content = File.ReadAllText(path1);
            Console.WriteLine("Задача 1:");
            Console.WriteLine(content);

            // 2. Проверить существование файла перед его удалением
            Console.WriteLine("Задача 2:");
            bool deleted = FileManager.DeleteFile(path1);
            Console.WriteLine(deleted ? "Файл удален" : "Файл не существует");

            // 3. Получить информацию о файле (размер, даты)
            string path2 = "test2.txt";
            FileManager.CreateFile(path2, "Пример текста для второго файла");
            Console.WriteLine("Задача 3:");
            FileInfoProvider.GetFileInfo(path2);

            // 4. Скопировать файл и убедиться, что копия существует
            string copyPath = "test2_copy.txt";
            FileManager.CopyFile(path2, copyPath);
            Console.WriteLine("Задача 4:");
            Console.WriteLine(File.Exists(copyPath) ? "Копия существует" : "Копия не существует");

            // 5. Переместить файл в новую директорию
            string dirPath = "new_directory";
            Directory.CreateDirectory(dirPath);
            string movedPath = Path.Combine(dirPath, "test2_moved.txt");
            FileManager.MoveFile(path2, movedPath);
            Console.WriteLine("Задача 5:");
            Console.WriteLine(File.Exists(movedPath) ? "Файл перемещен успешно" : "Ошибка перемещения");

            // 6. Переименовать файл в файл familiya.io
            string renamedPath = "rogozinskiy.io";
            FileManager.RenameFile(copyPath, renamedPath);
            Console.WriteLine("Задача 6:");
            Console.WriteLine(File.Exists(renamedPath) ? "Файл переименован успешно" : "Ошибка переименования");

            // 7. Обработать ошибку при удалении несуществующего файла
            Console.WriteLine("Задача 7:");
            bool result = FileManager.DeleteFile("nonexistent_file.txt");
            Console.WriteLine(result ? "Файл удален" : "Файл не существует, удаление невозможно");

            // 8. Сравнить два файла по размеру
            string path3 = "test3.txt";
            FileManager.CreateFile(path3, "Этот файл больше");
            Console.WriteLine("Задача 8:");
            FileInfoProvider.CompareFilesBySize(renamedPath, path3);

            // 9. Удалить все файлы в папке, соответствующие определенному шаблону
            FileManager.CreateFile("file1.ii", "Файл с расширением ii");
            FileManager.CreateFile("file2.ii", "Еще один файл с расширением ii");
            Console.WriteLine("Задача 9:");
            FileManager.DeleteFilesByPattern(Directory.GetCurrentDirectory(), "*.ii");
            Console.WriteLine("Файлы с расширением .ii удалены");

            // 10. Вывести список всех файлов в заданной директории
            Console.WriteLine("Задача 10:");
            string[] files = FileManager.GetFilesInDirectory(Directory.GetCurrentDirectory());
            Console.WriteLine("Файлы в текущей директории:");
            foreach (string file in files)
            {
                Console.WriteLine(Path.GetFileName(file));
            }
            Console.WriteLine();

            // 11. Запретить запись в файл и попытаться записать в него
            FileManager.SetFileReadOnly(path3, true);
            Console.WriteLine("Задача 11:");
            try
            {
                File.WriteAllText(path3, "Попытка записи");
                Console.WriteLine("Запись прошла успешно");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Ошибка: Запись запрещена (файл только для чтения)");
            }
            finally
            {
                FileManager.SetFileReadOnly(path3, false);
            }

            // 12. Проверить доступные права к файлу (чтение, запись, выполнение)
            Console.WriteLine("Задача 12:");
            FileInfoProvider.CheckFilePermissions(path3);
        }
    }
}