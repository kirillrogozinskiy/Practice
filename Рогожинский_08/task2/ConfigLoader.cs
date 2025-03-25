using NLog;
using NLog.Config;

namespace task2
{
    class ConfigLoader
    {
        private static readonly Logger logger;
        static ConfigLoader()
        {
            var config = new XmlLoggingConfiguration(@"D:\Education\С#\Практика\Рогожинский_08\task2\NLog.config.xml");
            LogManager.Configuration = config;
            logger = LogManager.GetCurrentClassLogger();
        }

        public string LoadConfig(string path)
        {
            logger.Info($"Попытка загрузить конфигурационный файл: {path}");

            if (!File.Exists(path))
            {
                FileNotFoundException exception = new FileNotFoundException($"Файл конфигурации не найден: {path}", path);
                logger.Error(exception, $"Ошибка при загрузке конфигурации: {exception.Message}");
                throw exception;
            }

            return File.ReadAllText(path);
        }
    }
}
