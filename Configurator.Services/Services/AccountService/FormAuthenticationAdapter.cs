using Configurator.Services.IServices.IAccountService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configurator.DataLayer;
using System.Web.Security;

namespace Configurator.Services.Services.AccountService
{
    public class FormAuthenticationAdapter : IFormsAuthenticationAdapter
    {
        public void DoAuth(User username)
        {
            FormsAuthentication.SetAuthCookie(username.LoginEmail, false);
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}
