using System;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using System.Collections.Generic;
using ToDoList.Controllers;
using ToDoList.Models;
using Xunit;
using System.Linq;
using Moq;

namespace ToDoList.Tests
{
    public class ItemsControllerTest
    {
        [Fact]
        public void Get_ViewResultIndex_Test()
        {
            //Arrange
            ItemsController controller = new ItemsController();

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Get_ModelListItemIndex_Test()
        {
            //Arrange
            ViewResult indexView = new ItemsController().Index() as ViewResult;

            //Act
            var result = indexView.ViewData.Model;

            //Assert
            Assert.IsType<List<Item>>(result);
        }

        [Fact]
        public void Post_MethodAddsItem_Test()
        {
            // Arrange
            ItemsController controller = new ItemsController();
            Item testItem = new Item();
            testItem.Description = "test";

            // Act
            controller.Create(testItem);
            ViewResult indexView = new ItemsController().Index() as ViewResult;
            var collection = indexView.ViewData.Model as IEnumerable<Item>;

            // Database Cleanup
            ToDoListContext db = new ToDoListContext();
            db.Items.Remove(testItem);
            db.SaveChanges();

            // Assert
            Assert.Contains<Item>(testItem, collection);
        }

        public void Item_Index_View_Contains_ListOfItems_Model()
        {
            // Arrange
            Mock<IItemRepository> mock = new Mock<IItemRepository>();

            mock.Setup(m => m.Items).Returns(new Item[]
                {
                    new Item {ItemId = 1, Description = "Wash the dog" },
                    new Item {ItemId = 2, Description = "Do the dishes" },
                    new Item {ItemId = 3, Description = "Sweep the floor" }
                }.AsQueryable());

            ItemsController controller = new ItemsController(mock.Object);

            // Act
            var actual = (List<Item>)controller.Index().Model;

            // Assert
            Assert.IsType<List<Item>>(actual);
        }

    }
}
