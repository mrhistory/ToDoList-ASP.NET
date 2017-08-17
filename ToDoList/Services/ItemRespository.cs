using System;
using System.Collections.Generic;
using ToDoList.Models;

namespace ToDoList.Services
{
    public static class ItemRepository
    {
        private static List<Item> items = new List<Item>();

        public static List<Item> GetAll()
        {
            return items;
        }

        public static Item Get(int id)
        {
            var item = items.Find(x => x.Id == id);
            if (item != null)
            {
                return item;
            }
            else
            {
                return null;
            }
        }

        public static Item Insert(Item item)
        {
            item.Id = items.Count;
            items.Add(item);
            return item;
        }

        public static Item Update(int id, Item item)
        {
            var index = items.FindIndex(x => x.Id == id);
            if (index != -1)
            {
				items[index] = item;
				return item;
            }
            else
            {
                throw new Exception("Item with ID " + id + " not found");
            }
        }

        public static void Delete(int id)
        {
            var index = items.FindIndex(x => x.Id == id);
            if (index != -1)
            {
                items.Remove(items[index]);
            }
        }

        public static void DeleteAll()
        {
            items.Clear();
        }

        public static void LoadItems() {
            Insert(new Item("Collect underpants"));
            Insert(new Item("???"));
            Insert(new Item("Profit"));
        }
    }
}
