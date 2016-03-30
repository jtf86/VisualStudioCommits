using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using ToDoList.Controllers;
using ToDoList.Models;
using Xunit;
using System.Linq;
using Moq;
using Microsoft.Data.Entity;

namespace ToDoList.Tests
{
    public class ItemsControllerTest
    {
        EFItemRepository db = new EFItemRepository(new ToDoListContextTest());

        [Fact]
        public void Get_ViewResultIndex_Test()
        {
            //Arrange
            ItemsController controller = new ItemsController(db);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Item_Index_View_Contains_ListOfItems_Model()
        {
            // Arrange
            ViewResult indexView = new ItemsController(db).Index() as ViewResult;

            // Act
            var result = indexView.ViewData.Model;

            // Assert
            Assert.IsType<List<Item>>(result);
        }

        [Fact]
        public void ConfirmEntry_Test()
        {
            // Arrange
            ItemsController controller = new ItemsController(db);
            Item testItem = new Item();
            testItem.Description = "Test DB WORKS!!!";

            // Act
            controller.Create(testItem);
            ViewResult indexView = controller.Index() as ViewResult;
            var collection = indexView.ViewData.Model as IEnumerable<Item>;

            // Assert
            Assert.Contains<Item>(testItem, collection);
        }
    }
}
