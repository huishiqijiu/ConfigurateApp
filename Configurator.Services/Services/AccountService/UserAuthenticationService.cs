using Configurator.Services.IServices.IAccountService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configurator.Services.ServiceModels;
using System.Web;
using Configurator.DataLayer.IRepository;

namespace Configurator.Services.Services.AccountService
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        IUserRepository _userRepo;       
        IFormsAuthenticationAdapter _formsAuthenticationAdapter;
        public UserAuthenticationService (IUserRepository userDb, IFormsAuthenticationAdapter formsAuthenticationAdapter)
        {
            _userRepo = userDb;            
            _formsAuthenticationAdapter = formsAuthenticationAdapter;
        }
        public UserModel AuthenticationRequest(HttpContextBase context)
        {
            throw new NotImplementedException();
        }

        public bool ChangePassword(int id, string password)
        {
            throw new NotImplementedException();
        }

        public UserModel GetUser(string username)
        {
            throw new NotImplementedException();
        }

        public bool Login(string mail, string password)
        {
            var user = _userRepo.GetUser(mail);

            if (user != null && user.Password ==password )
            {
                _formsAuthenticationAdapter.DoAuth(user);
                return true;
            }

            return false;
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public int RegisterUser(UserModel user)
        {
            if(_userRepo.GetUser(user.LoginEmail) == null)
            {
                var newUser = _userRepo.SaveUser(user.GetRepoUser());
                return newUser != null ? newUser.Id : -1;
            }
            return -1;
        }

        public bool UpdateUser(UserModel user)
        {
            throw new NotImplementedException();
        }

        public bool UserExists(string loginEmail)
        {
            return _userRepo.GetUser(loginEmail) != null;
        }

        public bool WrongPassword(string loginEmail, string password)
        {
            return _userRepo.GetUser(loginEmail).Password != password;
        }
    }
}
