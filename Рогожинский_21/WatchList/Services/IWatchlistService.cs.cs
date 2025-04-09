using System.Collections.Generic;
using WatchList.Models;

namespace WatchList.Services
{
    public interface IWatchlistService
    {
        void AddItem(WatchItem item);
        void RemoveItem(int id);
        IEnumerable<WatchItem> GetAllItems();
        WatchItem GetItemById(int id);
        void MarkAsWatched(int id);
        IEnumerable<WatchItem> GetItemsByStatus(string status);
    }
}