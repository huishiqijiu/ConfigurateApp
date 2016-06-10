using Configurator.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Services.IServices.IAccountService
{
    public interface IFormsAuthenticationAdapter
    {
        void DoAuth(User username);

        void Logout();
    }
}
