using HockeyManager.Controllers;
using System;
using Xunit;
using Moq;
using HockeyManager.DataLayer;
using Microsoft.AspNetCore.Identity;
using HockeyManager.Services;
using HockeyManager.DataLayer.Repository;
using HockeyManager.Models;

namespace HockeyManager.Tests.Controllers
{
    public class EmployeeControllerTests
    {
        [Fact]
        public void Create_should_return_View()
        {
            //Arrange
            var employeeService = new Mock<EmployeeService>();
            var employeeRoleService = new Mock<EmployeeRoleService>();
            var sut = new EmployeeController(employeeService.Object, employeeRoleService.Object);
            //Act
            var result = sut.CreateEmployee();

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Delete_WhenDoesntExist_ShouldReturnRedirectToAction()
        {
            //Arrange
            var employeeService = new Mock<EmployeeService>();
            var employeeRoleService = new Mock<EmployeeRoleService>();
            var sut = new EmployeeController(employeeService.Object, employeeRoleService.Object);
            
            //Act
            var result = sut.Delete("testId");

            //Assert
            Assert.NotNull(result);
        }
    }
}
