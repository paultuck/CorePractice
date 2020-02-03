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
    }
}