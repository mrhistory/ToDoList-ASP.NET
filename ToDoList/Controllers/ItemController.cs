using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ToDoList.Services;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ItemController : ApiController
    {
        public Item[] Get()
        {
            var items = ItemRepository.GetAll();
            if (items.Count() == 0)
            {
                ItemRepository.LoadItems();
                items = ItemRepository.GetAll();
            }
            return items.ToArray();
        }

        public Item Get(int id)
        {
            var item = ItemRepository.Get(id);
            if (item == null) {
                throw new Exception("Item with ID " + id + " not found");
            }
            return item;
        }

        public Item Insert(Item item)
        {
            return ItemRepository.Insert(item);
        }

        public Item Update(int id, Item item)
        {
            return ItemRepository.Update(id, item);
        }

        public void Delete(int id)
        {
            ItemRepository.Delete(id);
        }

        public void DeleteAll() // Very dangerous. This should be removed or require tight security.
        {
            ItemRepository.DeleteAll();
        }
    }
}
