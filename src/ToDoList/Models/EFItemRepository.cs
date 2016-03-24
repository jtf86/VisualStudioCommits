using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class EFItemRepository : IItemRepository
    {
        ToDoListContext db = new ToDoListContext();

        public IQueryable<Item> Items
        { get { return db.Items; } }

        public Item Save(Item item)
        {
            if (item.ItemId == 0)
            {
                db.Items.Add(item);
            }
            else
            {
                db.Entry(item).State = EntityState.Modified;
            }
            db.SaveChanges();
            return item;
        }

        public void Delete(Item item)
        {
            db.Items.Remove(item);
            db.SaveChanges();
        }
    }
}
