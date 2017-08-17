using System;
namespace ToDoList.Models
{
    public class Item
    {
        public Item() {}
        public Item(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Item(string name)
        {
            this.Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
