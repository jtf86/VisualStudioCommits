using Microsoft.AspNet.Mvc;
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
        Mock<IItemRepository> mock = new Mock<IItemRepository>();

        private void DbSetup()
        {
            mock.Setup(m => m.Items).Returns(new Item[]
            {
                new Item {ItemId = 1, Description = "Wash the dog" },
                new Item {ItemId = 2, Description = "Do the dishes" },
                new Item {ItemId = 3, Description = "Sweep the floor" }
            }.AsQueryable());
        }

        [Fact]
        public void Get_ViewResultIndex_Test()
        {
            //Arrange
            DbSetup();
            ItemsController controller = new ItemsController(mock.Object);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Item_Index_View_Contains_ListOfItems_Model()
        {
            // Arrange
            DbSetup();
            ViewResult indexView = new ItemsController(mock.Object).Index() as ViewResult;

            // Act
            var result = indexView.ViewData.Model;

            // Assert
            Assert.IsType<List<Item>>(result);
        }

        [Fact]
        public void Post_MethodAddsItem_Test()
        {
            // Arrange
            DbSetup();
            ItemsController controller = new ItemsController(mock.Object);
            Item testItem = new Item();
            testItem.Description = "Wash the dog";
            testItem.ItemId = 1;

            // Act
            //controller.Create(testItem);
            ViewResult indexView = controller.Index() as ViewResult;
            var collection = indexView.ViewData.Model as IEnumerable<Item>;

            // Assert
            Assert.Contains<Item>(testItem, collection);
        }
    }
}
