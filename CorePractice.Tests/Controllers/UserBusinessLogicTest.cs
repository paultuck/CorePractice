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
        private IGroupRepository groupRepository;
        private GroupBusinessLogic groupBusinessLogic;

        [TestInitialize()]
        public void Startup()
        {
            userRepository = new MockUserRepository();
            userBusinessLogic = new UserBusinessLogic(userRepository);

            groupRepository = new MockGroupRepository();
            groupBusinessLogic = new GroupBusinessLogic(groupRepository);
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
            // ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void UserNameCantBeModified()
        {
            // Arrange
            var user = new User() { UserId = 1, Username = "User" };
            userBusinessLogic.Add(user);

            // Act
            userBusinessLogic.Update(user.UserId,
                                    "User1",
                                    user.Password,
                                    user.Firstname,
                                    user.Lastname,
                                    user.DateOfBirth,
                                    user.Email,
                                    user.Phone,
                                    user.Mobile);

            // Assert
            // ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void UserPasswordNotStrongEnoughLength()
        {
            // Arrange
            var user = new User() { UserId = 1, Password = "abCdef1" };

            // Act
            userBusinessLogic.Add(user);

            // Assert
            // Assert that the password is long enough
            // ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void UserPasswordNotStrongEnoughNumbersAndLetters()
        {
            // Arrange
            var user = new User() { UserId = 1, Password = "Abcdefgh" };

            // Act
            userBusinessLogic.Add(user);

            // Assert
            // Assert that the password has both numbers and letters
            // ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void UserPasswordNotStrongEnoughUppercaseCharacter()
        {
            // Arrange
            var user = new User() { UserId = 1, Password = "abcdef12" };

            // Act
            userBusinessLogic.Add(user);

            // Assert
            // Assert that the password has a capital letter
            // ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void UserAlreadyInGroup()
        {
            // Arrange
            var user = new User() { UserId = 1, Username = "User 1" };
            var group = new Group() { GroupId = 1, GroupName = "Group 1" };


            // Act


            // Assert
        }
    }
}
