using Configurator.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Services.IServices
{
    public interface IUserService
    {
        UserModel GetUser(string mail);
        IEnumerable<UserModel> GetAllUsers();
        UserModel GetUserById(int id);
        void ChangePassword(int id, string newPass);
    }
}
