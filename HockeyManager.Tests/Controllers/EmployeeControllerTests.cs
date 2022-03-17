using HockeyManager.Controllers;
using System;
using Xunit;
using Moq;
using HockeyManager.DataLayer;
using Microsoft.AspNetCore.Identity;

namespace HockeyManager.Tests.Controllers
{
    public class EmployeeControllerTests
    {
        [Fact]
        public void Create_should_return_View()
        {
            //Arrange
            var userManager = new Mock<UserManager<Employee>>();
            var sut = new EmployeeController(null);

            //Act
            var result = sut.Create();

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Delete_WhenDoesntExist_ShouldReturnRedirectToAction()
        {
            //Arrange
            var userManager = new Mock<UserManager<Employee>>();
            var sut = new EmployeeController(null);
            userManager.Setup(x => x.FindByIdAsync(It.IsAny<string>())).Returns(()=>null);
            //Act
            var result = sut.Delete("testId");

            //Assert
            Assert.NotNull(result);
        }
    }
}
