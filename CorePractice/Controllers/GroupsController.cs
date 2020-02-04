using CorePractice.BusinessLogic;
using CorePractice.Models;
using CorePractice.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CorePractice.Controllers
{
    public class GroupsController : ApiController
    {
        IGroupRepository groupRepository;
        GroupBusinessLogic groupBusinessLogic;

        public GroupsController()
        {
            groupRepository = new EFGroupRepository();
            groupBusinessLogic = new GroupBusinessLogic(groupRepository);
        }

        public List<Group> Get()
        {
            var groups = groupBusinessLogic.List();
            return groups;
        }

        public Group Get(int id)
        {
            var group = groupBusinessLogic.Get(id);
            return group;
        }

        // Post method for creating a new group
        public Group Post(Group group)
        {
            var createdGroup = groupBusinessLogic.Create(group);
            return createdGroup;
        }

        // put method for updating a group
        public Group Put(Group group)
        {
            var updatedGroup = groupBusinessLogic.Update(group);
            return updatedGroup;
        }

        public Group DeleteGroup(int id)
        {
            var deletedGroup = groupBusinessLogic.Delete(id);
            return deletedGroup;
        }
    }
}