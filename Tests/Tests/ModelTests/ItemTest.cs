using ToDoList.Models;
using Xunit;

namespace ToDoList.Tests
{
    public class ItemTest
    {
        [Fact]
        public void GetDescription_Test()
        {
            //Arrange
            var item = new Item();
            item.Description = "Wash the dog";

            //Act
            var Result = item.Description;

            //Assert
            Assert.Equal("Wash the dog", Result);
        }
    }
}