using HockeyManager.DataLayer;
using HockeyManager.DataLayer.Repository;
using HockeyManager.Services;
using Moq;
using System;
using Xunit;

namespace HockeyManager.Tests.Services
{
    public class InventoryServiceTest
    {
        [Fact]
        public void Delete_WhenInventoryDoesntExist_ShouldReturnFalse()
        {
            //Arrange
            var inventoryRepo = new Mock<IInventoryRepository>();
            var sut = new InventoryService(inventoryRepo.Object);
            //Act
            var result = sut.DeleteInventoryAsync(Guid.NewGuid().ToString(), 1);
            //Assert
            Assert.False(result.Result);
        }

        [Fact]
        public void Delete_WhenInventoryExist_ShouldDelete_CertainNumberOfInventory()
        {
            //Arrange
            var inventoryRepo = new Mock<IInventoryRepository>();
            var inventory = GetInventory();
            inventoryRepo.Setup(r => r.FindByIdAsync(null).Result).Returns(inventory);
            var sut = new InventoryService(inventoryRepo.Object);
            //Act
            var result = sut.DeleteInventoryAsync(null, 5);
            //Assert
            Assert.True(result.Result);
            Assert.Equal(inventory.Amount, 5);
        }

        [Fact]
        public void Delete_WhenAmountIsMoreThanAmountOfInventory_ShouldReturnFalse()
        {
            //Arrange
            var inventoryRepo = new Mock<IInventoryRepository>();
            var inventory = GetInventory();
            inventoryRepo.Setup(r => r.FindByIdAsync(null).Result).Returns(inventory);
            var sut = new InventoryService(inventoryRepo.Object);
            //Act
            var result = sut.DeleteInventoryAsync(null, 13);
            //Assert
            Assert.False(result.Result);
        }

        private Inventory GetInventory()
        {
            return new Inventory
            {
                Amount = 10,
                NameOfAccessory = "Bauer",
                TypeOfAccessory = "hockey stick",
                USDCost = 500,
                DataOfLastMaintain = DateTime.Now,
                InventoryId = "1"
            };
        }
    }
}