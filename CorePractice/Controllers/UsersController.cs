using CorePractice.BusinessLogic;
using CorePractice.Models;
using CorePractice.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CorePractice.Controllers
{
    public class UsersController : ApiController
    {
        IUserRepository userRepository;
        UserBusinessLogic userBusinessLogic;

        public UsersController()
        {
            userRepository = new EFUserRepository();
            userBusinessLogic = new UserBusinessLogic(userRepository);
        }

        // GET api/<controller>
        public List<User> Get()
        {
            var users = userBusinessLogic.List();
            return users;
        }

        // GET api/<controller>/5
        public User Get(int id)
        {
            var user = userBusinessLogic.Get(id);
            return user;
        }

        // Create a new User
        public User Post(User user)
        {
            var createdUser = userBusinessLogic.Create(user);
            return createdUser;
        }

        // PUT api/<controller>/5
        public User Put(User user)
        {
            var updatedUser = userBusinessLogic.Update(user.UserId, 
                                                        user.Username, 
                                                        user.Password, 
                                                        user.Firstname,
                                                        user.Lastname,
                                                        user.DateOfBirth,
                                                        user.Email,
                                                        user.Phone,
                                                        user.Mobile);
            return updatedUser;
        }

        // DELETE api/<controller>/5
        public User Delete(int id)
        {
            var deletedUser = userBusinessLogic.Delete(id);
            return deletedUser;
        }


    }
}