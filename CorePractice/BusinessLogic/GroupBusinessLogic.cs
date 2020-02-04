using CorePractice.Models;
using CorePractice.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CorePractice.BusinessLogic
{
    public class GroupBusinessLogic
    {
        private IGroupRepository groupRepository;
        public GroupBusinessLogic(IGroupRepository groupRepository)
        {
            this.groupRepository = groupRepository;
        }

        public List<Group> List()
        {
            return groupRepository.List();
        }

        public Group Get(int id)
        {
            return groupRepository.Get(id);
        }

        public Group Create(Group group)
        {
            return groupRepository.Add(group);
        }

        public Group Update(Group group)
        {
            return groupRepository.Update(group);
        }

        public Group Delete(int id)
        {
            var group = Get(id);
            return groupRepository.Delete(group);
        }
    }
}