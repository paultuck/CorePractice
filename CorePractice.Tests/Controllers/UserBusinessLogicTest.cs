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
            var user1 = new User(UserId: 1, Username : "User", Password : "Abcdefg1", "", "", DateTime.Now, "", "", "" );
            var user2 = new User(UserId: 2, Username : "User", Password : "Abcdefg1", "", "", DateTime.Now, "", "", "" );

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
            var user = new User(UserId: 1, Username: "User", Password: "Abcdefg1", "", "", DateTime.Now, "", "", "");
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
            var user = new User(UserId: 1, Username: "User", Password: "abCdef1", "", "", DateTime.Now, "", "", "");

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
            var user = new User(UserId: 1, Username: "User", Password: "Abcdefgh", "", "", DateTime.Now, "", "", "");


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
            var user = new User(UserId: 1, Username: "User", Password: "abcdef12", "", "", DateTime.Now, "", "", "");


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
            var user = new User(UserId: 1, Username: "User", Password: "Abcdefg1", "", "", DateTime.Now, "", "", "");

            var group = new Group() { GroupId = 1, GroupName = "Group 1" };

            groupRepository.Add(group);
            userRepository.Add(user);

            // Act
            userBusinessLogic.AddGroup(user, group);
            userBusinessLogic.AddGroup(user, group);

            // Assert
            // ExpectedException
        }
    }
}
