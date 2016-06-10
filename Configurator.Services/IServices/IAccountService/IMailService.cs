using Configurator.DataLayer;
using Configurator.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Services.IServices.IAccountService
{
    public interface IMailService
    {
        void SendPassword(string email, string password);
        void SendMailAboutDelivery(OrderModel o);
    }
}
