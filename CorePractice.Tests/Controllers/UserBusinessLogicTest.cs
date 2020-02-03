using System;
using CorePractice.BusinessLogic;
using CorePractice.Models;
using CorePractice.Models.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CorePractice.Tests.Controllers
{
    [TestClass]
    public class UserBusinessLogicTest
    {
        private IUserRepository userRepository;
        private UserBusinessLogic userBusinessLogic;

        [TestInitialize()]
        public void Startup()
        {
            userRepository = new MockUserRepository();
            userBusinessLogic = new UserBusinessLogic(userRepository);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void UserNameAlreadyTaken()
        {
            // Arrange
            var user1 = new User() { UserId = 1, Username = "User" };
            var user2 = new User() { UserId = 2, Username = "User" };

            // Act
            userBusinessLogic.Add(user1);
            userBusinessLogic.Add(user2);

            // Assert
        }

        [TestMethod]
        public void UserNameCantBeModified()
        {
            // Arrange
            // Act
            // Assert
        }

        [TestMethod]
        public void UserPasswordNotStrongEnough()
        {
            // Arrange
            // Act
            // Assert
        }

        [TestMethod]
        public void UserAlreadyInGroup()
        {
            // Arrange
            // Act
            // Assert
        }
    }
}
