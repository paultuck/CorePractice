using CorePractice.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CorePractice.Models
{
    public class MockGroupRepository : IGroupRepository
    {
        List<Group> groups = new List<Group>();
        public Group Add(Group group)
        {
            groups.Add(group);
            return group;
        }

        public Group Delete(Group group)
        {
            groups.Remove(group);
            return group;
        }

        public Group Get(int id)
        {
            return groups.Find(g => g.GroupId == id);
        }

        public List<Group> List()
        {
            return groups;
        }

        public Group Update(Group group)
        {
            var retrievedGroup = Get(group.GroupId);
            retrievedGroup.GroupName = group.GroupName;
            retrievedGroup.Description = group.Description;
            return retrievedGroup;
        }
    }
}