using CorePractice.Models;
using CorePractice.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CorePractice.BusinessLogic
{
    public class UserBusinessLogic
    {
        private IUserRepository userRepository;
        public UserBusinessLogic(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User Add(User user)
        {
            var retrievedUser = userRepository.Get(user.Username);
            if(retrievedUser != null)
            {
                throw new Exception("This username is currently in use.");
            }
            validatePassword(user.Password);
            retrievedUser = userRepository.Add(user);
            return retrievedUser;
        }

        // Made this function take all the params in seperately to avoid the case where you could update the user entity's username directly
        public User Update(int userId, string username, string password, string firstname, string lastname, DateTime dateOfBirth, string email, string phone, string mobile)
        {
            var retrievedUser = userRepository.Get(userId);
            if (retrievedUser != null)
            {
                if (retrievedUser.Username != username)
                {
                    throw new Exception("Usernames can't be changed.");
                }
                var user = new User()
                {
                    UserId = userId,
                    DateOfBirth = dateOfBirth,
                    Email = email,
                    Firstname = firstname,
                    Lastname = lastname,
                    Mobile = mobile,
                    Password = validatePassword(password),
                    Phone = phone,
                    Username = username
                };
                retrievedUser = userRepository.Update(user);
            }
            return retrievedUser;
        }

        private string validatePassword(string password)
        {
            if (password.Length < 8)
            {
                throw new Exception("Password is too short.");
            }
            return password;
        }
    }
}