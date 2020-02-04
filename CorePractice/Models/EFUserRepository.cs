using CorePractice.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CorePractice.Models
{
    public class EFUserRepository : IUserRepository
    {
        EFCorePracticeDBContext dbContext = new EFCorePracticeDBContext();
        public User Add(User user)
        {
            var retrievedUser = dbContext.users.Add(user);
            dbContext.SaveChanges();
            return retrievedUser;
        }

        public User AddGroup(User user, Group group)
        {
            user.Groups.Add(group);
            dbContext.Entry<User>(user).State = EntityState.Modified;
            var retrievedUser = dbContext.users.Attach(user);
            dbContext.SaveChanges();
            return retrievedUser;
        }

        public User Delete(User user)
        {
            var retrievedUser = dbContext.users.Remove(user);
            return retrievedUser;
        }

        public User DeleteGroup(User user, Group group)
        {
            user.Groups.Remove(group);
            dbContext.Entry<User>(user).State = EntityState.Modified;
            var retrievedUser = dbContext.users.Attach(user);
            dbContext.SaveChanges();
            return retrievedUser;
        }

        public User Get(int id)
        {
            return dbContext.users.Where(u => u.UserId == id).FirstOrDefault();
        }

        public User Get(string username)
        {
            return dbContext.users.Where(u => u.Username == username).FirstOrDefault();
        }

        public List<User> GetPage(int page, int pageSize)
        {
            if (page < 1) page = 1;
            var currentPage = dbContext.users.OrderBy(u => u.UserId).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return currentPage;
        }

        public List<User> List()
        {
            return dbContext.users.ToList();
        }

        public List<User> Search(string searchTerm)
        {
            var searchTermsArray = searchTerm.Split(" ".ToCharArray());
            //Firstname, Lastname, DateOfBirth, Email, Phone, Mobile
            var foundUsers = dbContext.users.Where(u => searchTermsArray.Any(s => u.Firstname.Contains(s) ||
                                                        u.Lastname.Contains(s) ||
                                                        u.DateOfBirth.ToString().Contains(s) ||
                                                        u.Email.Contains(s) || 
                                                        u.Phone.Contains(s) ||
                                                        u.Mobile.Contains(s))).ToList();
            return foundUsers;
        }

        public User Update(User modifiedUser)
        {
            dbContext.Entry<User>(modifiedUser).State = EntityState.Modified;
            dbContext.users.Attach(modifiedUser);
            dbContext.SaveChanges();
            return modifiedUser;
        }
    }
}