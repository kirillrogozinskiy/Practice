using System.IO.MemoryMappedFiles;
using System.Text;

namespace WpfApp.Services
{
    public class NotificationService
    {
        private const string MapName = "ScheduleNotifications";

        public void SendNotification(string message)
        {
            using (var mmf = MemoryMappedFile.CreateOrOpen(MapName, 1024))
            using (var accessor = mmf.CreateViewAccessor())
            {
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                accessor.WriteArray(0, buffer, 0, buffer.Length);
            }
        }

        public string ReceiveNotification()
        {
            using (var mmf = MemoryMappedFile.OpenExisting(MapName))
            using (var accessor = mmf.CreateViewAccessor())
            {
                byte[] buffer = new byte[1024];
                int bytesRead = accessor.ReadArray(0, buffer, 0, buffer.Length);
                return Encoding.UTF8.GetString(buffer, 0, bytesRead).TrimEnd('\0');
            }
        }
    }
}