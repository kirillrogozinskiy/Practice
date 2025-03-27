using NLog;

namespace task4
{
    public class FileWatcher
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly FileSystemWatcher watcher;
        private readonly string folderPath;

        public FileWatcher(string path)
        {
            folderPath = path;
            watcher = new FileSystemWatcher(path)
            {
                NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName
            };

            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;
            watcher.Changed += OnChanged;
            watcher.Renamed += OnRenamed;

            watcher.EnableRaisingEvents = true;
            logger.Info($"Начало наблюдения за папкой: {Path.GetFullPath(path)}");
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            logger.Info($"Создан: {e.FullPath}");
            ProcessTempFile(e.FullPath);
        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            logger.Info($"Удалён: {e.FullPath}");
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (Directory.Exists(e.FullPath)) 
            { 
                return; 
            }

            logger.Info($"Изменён: {e.FullPath}");
            ProcessTempFile(e.FullPath);
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            logger.Info($"Переименован: {e.OldFullPath} -> {e.FullPath}");
            ProcessTempFile(e.FullPath);
        }

        private void ProcessTempFile(string filePath)
        {
            if (Path.GetExtension(filePath).Equals(".tmp", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                        logger.Info($"Временный файл удалён: {filePath}");
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex, $"Ошибка удаления временного файла: {filePath}");
                }
            }
        }
    }
}
