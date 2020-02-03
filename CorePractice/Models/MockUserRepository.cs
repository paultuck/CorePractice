using CorePractice.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CorePractice.Models
{
    public class MockUserRepository : IUserRepository
    {
        private List<User> users = new List<User>();
        public User Add(User user)
        {
            users.Add(user);
            return user;
        }

        public User AddGroup(User user, Group group)
        {
            throw new NotImplementedException();
        }

        public User Delete(User user)
        {
            throw new NotImplementedException();
        }

        public User DeleteGroup(User user, Group group)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(string username)
        {
            var user = users.Find(u => u.Username == username);
            return user;
        }

        public List<User> List()
        {
            throw new NotImplementedException();
        }

        public User Update(User modifiedUser)
        {
            throw new NotImplementedException();
        }
    }
}