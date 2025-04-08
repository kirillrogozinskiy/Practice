using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WatchList.Models;

namespace WatchList.Controllers
{
    public class WatchController : Controller
    {
        private static List<WatchItem> _watchItems = new List<WatchItem>();

        // GET: Watch
        public ActionResult Index()
        {
            return View(_watchItems);
        }

        // GET: Watch/Add
        public ActionResult Add()
        {
            return View();
        }

        // POST: Watch/Add
        [HttpPost]
        public ActionResult Add(WatchItem watchItem)
        {
            if (ModelState.IsValid)
            {
                watchItem.Id = _watchItems.Count > 0 ? _watchItems.Max(x => x.Id) + 1 : 1;
                _watchItems.Add(watchItem);
                return RedirectToAction("Index");
            }

            return View(watchItem);
        }

        // GET: Watch/MarkAsWatched/{id}
        public ActionResult MarkAsWatched(int id)
        {
            var item = _watchItems.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.Status = "Watched";
            }
            return RedirectToAction("Index");
        }

        // GET: Watch/ByStatus/{status}
        public ActionResult ByStatus(string status)
        {
            var items = _watchItems.Where(x => x.Status == status).ToList();
            return View(items);
        }
    }
}