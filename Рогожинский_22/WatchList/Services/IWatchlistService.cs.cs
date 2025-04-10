using System.Collections.Generic;
using WatchList.Models;

namespace WatchList.Services
{
    public interface IWatchlistService
    {
        Task AddItemAsync(WatchItem item);
        Task RemoveItemAsync(int id);
        Task<List<WatchItem>> GetAllItemsAsync();
        Task<WatchItem> GetItemByIdAsync(int id);
        Task UpdateItemAsync(WatchItem item);
        Task<List<WatchItem>> GetItemsByStatusAsync(string status);
    }
}