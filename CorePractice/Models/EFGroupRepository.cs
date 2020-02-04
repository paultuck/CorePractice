using CorePractice.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CorePractice.Models
{
    public class EFGroupRepository : IGroupRepository
    {
        EFCorePracticeDBContext dbContext = new EFCorePracticeDBContext();
        public Group Add(Group group)
        {
            var retrievedGroup = dbContext.groups.Add(group);
            dbContext.SaveChanges();
            return retrievedGroup;
        }

        public Group Delete(Group group)
        {
            var retrievedGroup = dbContext.groups.Remove(group);
            dbContext.SaveChanges();
            return retrievedGroup;
        }

        public Group Get(int id)
        {
            return dbContext.groups.Where(g => g.GroupId == id).FirstOrDefault();
        }

        public List<Group> List()
        {
            return dbContext.groups.ToList();
        }

        public Group Update(Group group)
        {
            var retrievedGroup = dbContext.groups.Attach(group);
            dbContext.Entry(group).State = EntityState.Modified;
            dbContext.SaveChanges();
            return retrievedGroup;
        }
    }
}