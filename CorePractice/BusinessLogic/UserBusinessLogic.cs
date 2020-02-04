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
                var user = new User(userId, username, validatePassword(password), firstname, lastname, dateOfBirth, email, phone, mobile); ;
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
            if (containsLettersAndNumbers(password) == false)
            {
                throw new Exception("Password doesn't contain both letters and numbers.");
            }
            if (containsUppercaseCharacter(password) == false)
            {
                throw new Exception("Password doesn't contain an uppercase character.");
            }
            return password;
        }

        private bool containsLettersAndNumbers(string password)
        {
            var lettersAndNumbers = false;
            var letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var numbers = "0123456789";
            for(int i = 0; i < password.Length; i++){
                if (letters.Contains(password[i]))
                {
                    for (int j = 0; j < password.Length; j++)
                    {
                        if (numbers.Contains(password[j]))
                        {
                            lettersAndNumbers = true;
                            break;
                        }
                    }
                    if (lettersAndNumbers) break;
                }
            }
            return lettersAndNumbers;
        }

        private bool containsUppercaseCharacter(string password)
        {
            var uppercaseCharacter = false;
            var capitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (int i = 0; i < password.Length; i++)
            {
                if (capitalLetters.Contains(password[i]))
                {
                    uppercaseCharacter = true;
                    break;
                }
            }
            return uppercaseCharacter;
        }

        public void AddGroup(User user, Group group)
        {
            if (user.Groups.Contains(group))
            {
                throw new Exception("User is already a member of this Group.");
            }
            userRepository.AddGroup(user, group);
        }
    }
}