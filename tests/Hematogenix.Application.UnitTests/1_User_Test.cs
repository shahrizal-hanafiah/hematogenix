using Hematogenix.Core.Model;
using Hematogenix.DataAccess.Repositories;
using Hematogenix.Shared.Dto;
using Hematogenix.Web.Controllers.ApiController;
using Hematogenix.Web.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http.Results;
using Xunit;

namespace Hematogenix.Application.UnitTests
{
    public class UserTest
    {
        [Fact]
        public void GetUsers_Success()
        {
            // Arrange
            IList<UserDto> users = new List<UserDto>
            {
                new UserDto { Id=1,Username = "Harun1998",FirstName="Harun",LastName="Ahmad",Role="generaluser",Email="harun@gmail.com"},
                new UserDto { Id=2,Username = "Linda2002",FirstName="Linda",LastName="Darlis",Role="generaluser",Email="linda@gmail.com"}
            };

            var mockAppService = new Mock<IUserAppService>();
            mockAppService.Setup(x => x.GetAll()).Returns(users);

            var controller = new UserController(mockAppService.Object);

            // Act
            var result = controller.Get();

            // Assert
            Assert.Equal(users, result.Value);
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IList<UserDto>>(users);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void InsertUsers_Success()
        {
            // Arrange
            RegisterViewModel newUser = new RegisterViewModel()
            {
                Username = "Ayu2004",
                FirstName = "NurWahyuni",
                LastName = "Harun",
                Role = "generaluser",
                Email = "ayu@gmail.com"
            };

            var mockAppService = new Mock<IUserAppService>();

            var controller = new UserController(mockAppService.Object);

            // Act
            var result = controller.RegisterUser(newUser);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200,result.StatusCode);
        }

    }
}
