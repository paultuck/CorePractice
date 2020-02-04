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
            user.Groups.Add(group);
            return user;
        }

        public User Delete(User user)
        {
            users.Remove(user);
            return user;
        }

        public User DeleteGroup(User user, Group group)
        {
            user.Groups.Remove(group);
            return user;
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

        public List<User> GetPage(int page, int pageSize)
        {
            if (page < 1) page = 1;
            return users.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public List<User> List()
        {
            return users;
        }

        public List<User> Search(string searchTerm)
        {
            var searchTermsArray = searchTerm.Split(" ".ToCharArray());
            //Firstname, Lastname, DateOfBirth, Email, Phone, Mobile
            var foundUsers = users.Where(u => searchTermsArray.Any(s => u.Firstname.Contains(s) ||
                                                        u.Lastname.Contains(s) ||
                                                        u.DateOfBirth.ToString().Contains(s) ||
                                                        u.Email.Contains(s) ||
                                                        u.Phone.Contains(s) ||
                                                        u.Mobile.Contains(s))).ToList();
            return foundUsers;
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