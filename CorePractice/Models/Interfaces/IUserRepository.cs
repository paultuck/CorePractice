using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePractice.Models.Interfaces
{
    public interface IUserRepository
    {
        List<User> List();
        User Get(int id);
        User Get(string username);
        User Add(User user);
        User Update(User modifiedUser);
        User Delete(User user);
        User AddGroup(User user, Group group);
        User DeleteGroup(User user, Group group);
    }
}
