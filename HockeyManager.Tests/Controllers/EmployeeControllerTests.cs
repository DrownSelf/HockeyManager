using HockeyManager.Controllers;
using Xunit;
using Moq;
using HockeyManager.Services;

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
