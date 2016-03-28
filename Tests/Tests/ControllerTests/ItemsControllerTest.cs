using System;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using System.Collections.Generic;
using ToDoList.Controllers;
using ToDoList.Models;
using Xunit;

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
        //[Theory]
        //[InlineData("test item")]
        //[InlineData("sample item")]
        //[InlineData("example item")]
        public void Post_MethodAddsItem_Test()
        //public void Post_MethodAddsItem_Test(string value)
        {
            // Arrange
            ItemsController controller = new ItemsController();
            Item testItem = new Item();
            testItem.Description = "test";
            //testItem.Description = value;

            // Act
            controller.Create(testItem);
            ViewResult indexView = new ItemsController().Index() as ViewResult;
            var collection = indexView.ViewData.Model as IEnumerable<Item>;

            // Assert
            Assert.Contains<Item>(testItem, collection);

            // Database Cleanup
            //ToDoListContext db = new ToDoListContext();
            //db.Items.Remove(testItem);
            //db.SaveChanges();
        }
    }
}
