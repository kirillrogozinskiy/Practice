using SQLitePCL;
using Microsoft.EntityFrameworkCore;
using WatchList.Models;

namespace WatchList.Data
{
    public class WatchListContext : DbContext
    {
        public WatchListContext(DbContextOptions<WatchListContext> options)
            : base(options)
        {
            Batteries.Init();
        }

        public DbSet<WatchItem> WatchItems { get; set; }
    }
}
