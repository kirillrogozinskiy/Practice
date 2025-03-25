using NLog;
using NLog.Config;

namespace task2
{
    class ConfigurationManager
    {
        private static readonly Logger logger;
        static ConfigurationManager()
        {
            var config = new XmlLoggingConfiguration(@"D:\Education\С#\Практика\Рогожинский_08\task2\NLog.config.xml");
            LogManager.Configuration = config;
            logger = LogManager.GetCurrentClassLogger();
        }

        public void LoadConfiguration(string path)
        {
            try
            {
                logger.Info($"Начало загрузки конфигурации из {path}");

                ConfigLoader loader = new ConfigLoader();
                string config = loader.LoadConfig(path);

                logger.Info("Конфигурация успешно загружена");
            }
            catch (FileNotFoundException ex)
            {
                logger.Error(ex, $"Ошибка при загрузке конфигурационного файла: {ex.Message}");

                throw new ConfigurationException($"Не удалось загрузить конфигурацию из {path}", ex);
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"Неожиданная ошибка при загрузке конфигурации: {ex.Message}");
                throw;
            }
        }
    }
}
