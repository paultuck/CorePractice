using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePractice.Models.Interfaces
{
    public interface IGroupRepository
    {
        List<Group> List();
        Group Get(int id);
        Group Add(Group group);
        Group Update(Group group);
        Group Delete(Group group);
    }
}