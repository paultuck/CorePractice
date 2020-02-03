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
            retrievedUser = userRepository.Add(user);
            return retrievedUser;
        }
    }
}