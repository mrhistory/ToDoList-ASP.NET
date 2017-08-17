using NUnit.Framework;
using System;
using ToDoList;
using ToDoList.Controllers;
using ToDoList.Services;
using ToDoList.Models;

namespace ToDoList.Tests.Controllers
{
    [TestFixture()]
    public class ItemControllerTest
    {
        [Test()]
        public void GetAll()
        {
            var controller = new ItemController();

            var result = controller.Get();

            Assert.IsNotEmpty(result);
        }

        [Test()]
        public void Get()
        {
            var controller = new ItemController();
            var item = controller.Insert(new Item("Test Item"));

            var result = controller.Get(item.Id);

            Assert.IsNotNull(result);
            Assert.IsTrue(item.Name.Equals("Test Item"));
        }

        [Test()]
        public void Insert()
        {
            var controller = new ItemController();

            var result = controller.Insert(new Item("Test Item"));
            var item = controller.Get(result.Id);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Name.Equals(item.Name));
            Assert.IsTrue(result.Name.Equals("Test Item"));
            Assert.IsTrue(item.Name.Equals("Test Item"));
        }

        [Test()]
        public void Update()
        {
            var controller = new ItemController();
            var item = controller.Insert(new Item("Test Item"));

            item.Name = "Updated Test Item";
            var result = controller.Update(item.Id, item);
            var item2 = controller.Get(item.Id);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Name.Equals(item.Name));
            Assert.IsTrue(result.Name.Equals(item2.Name));
            Assert.IsTrue(result.Name.Equals("Updated Test Item"));
            Assert.IsTrue(item2.Name.Equals("Updated Test Item"));
        }

        [Test()]
        public void Delete()
        {
            var controller = new ItemController();
            var item = controller.Insert(new Item("Test Item"));

            controller.Delete(item.Id);
        }
    }
}
