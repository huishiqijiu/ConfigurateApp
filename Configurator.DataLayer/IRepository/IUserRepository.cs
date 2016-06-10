using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.DataLayer.IRepository
{
    public interface IUserRepository
    {
        User GetUser(string mail);
        User GetUserById(int id);
        IEnumerable<User> GetAllUsers();
        User SaveUser(User user);
        bool UpdateUser(User user);
        void ChangePassword(int id, string newPass);
    }
}
