using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;
using Xunit;

namespace ToDoList.Tests
{
    public class ItemTest
    {
        private ToDoListContext db = new ToDoListContext();

        [Fact]
        public void GetDescriptionTest()
        {
            //Arrange
            var item = new Item();
            item.Description = "Wash the dog";

            //Act
            var Result = item.Description;

            //Assert
            Assert.Equal("Wash the dog", Result);
        }

        [Fact]
        public void Save()
        {
            //Arrange
            var item = new Item();
            item.Description = "Wash the dog";

            //Act
            db.Items.Add(item);
            db.SaveChanges();
            Item thisItem = db.Items.Last();
            int thisId = thisItem.ItemId;

            //Assert
            Assert.NotEqual(0, thisId);
        }
    }
}
