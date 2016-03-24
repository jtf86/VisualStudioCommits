using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;
using ToDoList.Controllers;
using Xunit;
using Moq;

namespace ToDoList.Tests
{
    public class ItemTest
    {
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
        }
    }
}
