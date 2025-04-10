using Microsoft.AspNetCore.Mvc;
using WatchList.Models;
using WatchList.Services;

namespace WatchList.Controllers
{
    public class WatchlistController : Controller
    {
        private readonly IWatchlistService _watchlistService;

        public WatchlistController(IWatchlistService watchlistService)
        {
            _watchlistService = watchlistService;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _watchlistService.GetAllItemsAsync();
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WatchItem item)
        {
            if (ModelState.IsValid)
            {
                await _watchlistService.AddItemAsync(item);
                TempData["Notification"] = $"{item.Title} добавлен в ваш список!";
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var item = await _watchlistService.GetItemByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(WatchItem item)
        {
            if (ModelState.IsValid)
            {
                await _watchlistService.UpdateItemAsync(item);
                TempData["Notification"] = $"{item.Title} обновлен!";
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _watchlistService.RemoveItemAsync(id);
            TempData["Notification"] = "Элемент удален из вашего списка!";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ByStatus(string status)
        {
            var items = await _watchlistService.GetItemsByStatusAsync(status);
            ViewBag.Status = status;
            return View(items);
        }
    }
}