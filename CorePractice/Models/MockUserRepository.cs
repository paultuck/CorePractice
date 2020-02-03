using CorePractice.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CorePractice.Models
{
    public class MockUserRepository : IUserRepository
    {
        public User Add(User user)
        {
            throw new NotImplementedException();
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