using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ToDoList.Models;
using Microsoft.Data.Entity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoList.Controllers
{
    public class ItemsController : Controller
    {
        private IItemRepository db;

        public ItemsController(IItemRepository itemRepo = null)
        {
            if (itemRepo == null)
            {
                this.db = new EFItemRepository();
            }
            else
            {
                this.db = itemRepo;
            }
        }


        public ViewResult Index()
        {
            return View(db.Items.ToList());
        }

        public IActionResult Details(int id)
        {
            Item thisItem = db.Items.FirstOrDefault(x => x.ItemId == id);
            return View(thisItem);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            db.Save(item);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Item thisItem = db.Items.FirstOrDefault(x => x.ItemId == id);
            return View(thisItem);
        }

        [HttpPost]
        public IActionResult Edit(Item item)
        {
            db.Edit(item);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Item thisItem = db.Items.FirstOrDefault(x => x.ItemId == id);
            return View(thisItem);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Item thisItem = db.Items.FirstOrDefault(x => x.ItemId == id);
            db.Remove(thisItem);
            return RedirectToAction("Index");
        }
    }
}
