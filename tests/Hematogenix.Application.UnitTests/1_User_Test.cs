using Hematogenix.Core.Model;
using Hematogenix.DataAccess.Repositories;
using Hematogenix.Shared.Dto;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Hematogenix.Application.UnitTests
{
    public class UserTest
    {
        public readonly IUserRepository MockUserRepository;
        [Fact]
        public void GetUsers_Success()
        {
            IList<User> users = new List<User>
            {
                new User { Id=1,Username = "Harun1998",FirstName="Harun",LastName="Ahmad",Role="generaluser",Email="harun@gmail.com"},
                new User { Id=2,Username = "Linda2002",FirstName="Linda",LastName="Darlis",Role="generaluser",Email="linda@gmail.com"}
            };

            Mock<IUserRepository> mockUserRepository = new Mock<IUserRepository>();

            mockUserRepository.Setup(x => x.GetUsers()).Returns(users);


        }
        [Fact]
        public void CanInsertProduct()
        {
            UserDto newUser = new UserDto
            { Id = 4, Username = "Ayu2004", FirstName = "NurWahyuni", LastName = "Harun", Role = "generaluser", Email = "ayu@gmail.com" };

            int userCount = MockUserRepository.GetUsers().Count;
            Assert.Equal(2, userCount); // Verify the expected Number pre-insert

            // try saving our new product
            this.MockUserRepository.Insert(newUser);

            // demand a recount
            userCount = this.MockUserRepository.GetUsers().Count;
            Assert.Equal(3, userCount); // Verify the expected Number post-insert

            // verify that our new product has been saved
            User testUser = MockUserRepository.GetUserById(4);
            Assert.NotNull(testUser); // Test if null
            Assert.IsType<User>(testUser); // Test type
            Assert.Equal(4, testUser.Id); // Verify it has the expected productid
        }
    }
}
