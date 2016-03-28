using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public interface IItemsRepository
    {
        IQueryable<Item> Items { get; }
        Item Save(Item item);
        void Delete(Item item);
    }
}
