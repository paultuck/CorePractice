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
        public void UserNameAlreadyTaken()
        {
            // Arrange
            // Act
            // Assert
        }
    }
}
