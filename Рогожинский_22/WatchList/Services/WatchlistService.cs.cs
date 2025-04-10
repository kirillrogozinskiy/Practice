using Microsoft.EntityFrameworkCore;
using WatchList.Data;
using WatchList.Models;

namespace WatchList.Services
{
    public class WatchlistService : IWatchlistService
    {
        private readonly WatchListContext _context;

        public WatchlistService(WatchListContext context)
        {
            _context = context;
        }

        public async Task AddItemAsync(WatchItem item)
        {
            _context.WatchItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveItemAsync(int id)
        {
            var item = await _context.WatchItems.FindAsync(id);
            if (item != null)
            {
                _context.WatchItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<WatchItem>> GetAllItemsAsync()
        {
            return await _context.WatchItems.ToListAsync();
        }

        public async Task<WatchItem> GetItemByIdAsync(int id)
        {
            return await _context.WatchItems.FindAsync(id);
        }

        public async Task UpdateItemAsync(WatchItem item)
        {
            _context.WatchItems.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task<List<WatchItem>> GetItemsByStatusAsync(string status)
        {
            return await _context.WatchItems
                .Where(x => x.Status == status)
                .ToListAsync();
        }
    }
}