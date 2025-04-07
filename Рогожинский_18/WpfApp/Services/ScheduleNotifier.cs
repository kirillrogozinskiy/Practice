using System.IO.MemoryMappedFiles;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    public class ScheduleNotifier
    {
        private const string MapName = "ScheduleMap";
        private const int MapSize = 1024;

        public async Task WriteScheduleChangeAsync(string message)
        {
            using (var mmf = MemoryMappedFile.CreateOrOpen(MapName, MapSize))
            using (var accessor = mmf.CreateViewAccessor())
            {
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                accessor.WriteArray(0, buffer, 0, buffer.Length);
            }
        }

        public async Task<string> ReadScheduleChangeAsync()
        {
            using (var mmf = MemoryMappedFile.OpenExisting(MapName))
            using (var accessor = mmf.CreateViewAccessor())
            {
                byte[] buffer = new byte[MapSize];
                accessor.ReadArray(0, buffer, 0, buffer.Length);
                return Encoding.UTF8.GetString(buffer).TrimEnd('\0');
            }
        }
    }
}