using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Controllers;
using ToDoList.Models;
using FluentAssertions;
using Xunit;

namespace ToDoList.Tests
{


    public class ItemControllerTest
    {

        [Fact]
        public void IndexViewTest()
        {
            // Arrange
            var controller = new TestItemsController();

            // Act
            var actionResult = controller.Index();

            // Assert
            actionResult.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public void CreatePostTest()
        {
            // Arrange
            var controller = new TestItemsController();
            var item = new Item();
            item.Description = "Controller Test Item";
            var indexResult = controller.Index();

            // Act
            var actionResult = controller.Create(item);

            // Assert
            actionResult.Should().BeOfType<RedirectToActionResult>();
        }
    }
}
