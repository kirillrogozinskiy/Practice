using Microsoft.AspNetCore.Mvc;
using WatchList.Models;
using WatchList.Services;
using System.Collections.Generic;

namespace WatchList.Controllers
{
    public class WatchlistController : Controller
    {
        private readonly IWatchlistService _watchlistService;

        public WatchlistController(IWatchlistService watchlistService)
        {
            _watchlistService = watchlistService;
        }

        public IActionResult Index()
        {
            var items = _watchlistService.GetAllItems();
            return View(items);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(WatchlistItemViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var item = new WatchItem
                {
                    Title = viewModel.Title,
                    Genre = viewModel.Genre,
                    Type = viewModel.Type
                };

                _watchlistService.AddItem(item);
                TempData["Notification"] = $"{item.Title} добавлен в ваш список!";
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        public IActionResult Delete(int id)
        {
            _watchlistService.RemoveItem(id);
            TempData["Notification"] = "Элемент удален из вашего списка!";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult MarkAsWatched(int id)
        {
            _watchlistService.MarkAsWatched(id);
            TempData["Notification"] = "Элемент помечен как просмотренный!";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ByStatus(string status)
        {
            var items = _watchlistService.GetItemsByStatus(status);
            ViewBag.Status = status;
            return View(items);
        }
    }
}