﻿using CorePractice.Models.Interfaces;
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
            return users.Find(u => u.UserId == id);
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
            var user = Get(modifiedUser.UserId);
            user.Username = modifiedUser.Username;
            user.DateOfBirth = modifiedUser.DateOfBirth;
            user.Email = modifiedUser.Email;
            user.Firstname = modifiedUser.Firstname;
            user.Groups = modifiedUser.Groups;
            user.Lastname = modifiedUser.Lastname;
            user.Mobile = modifiedUser.Mobile;
            user.Password = modifiedUser.Password;
            user.Phone = modifiedUser.Phone;

            return user;
        }
    }
}