using Configurator.Services.IServices.IAccountService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configurator.Services.ServiceModels;
using System.Net.Mail;
using System.Net;
using Configurator.Services.IServices;

namespace Configurator.Services.Services.AccountService
{
    public class MailService : IMailService
    {

        IUserService _userService;
        public MailService(IUserService userService)
        {
            _userService = userService;
        }
        public void SendMailAboutDelivery(OrderModel o)
        {
            UserModel user = _userService.GetUserById(o.UserId);
            try
            {
                using (SmtpClient client = new SmtpClient("smtp.gmail.com"))
                {
                    MailMessage message = new MailMessage();
                    message.From = new MailAddress("huishi0709@gmail.com");
                    message.To.Add(user.LoginEmail);
                    message.Body = "Your order from YourDesign AB has been delivered today.";
                    message.Subject = "Your Order from YourDesign AB";
                    client.UseDefaultCredentials = false;
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.Credentials = new System.Net.NetworkCredential("huishi0709@gmail.com", "593010sh");
                    client.Send(message);
                    message = null;

                }
            }
            catch (SmtpFailedRecipientsException sfrEx)
            {
                throw sfrEx;
            }
            catch (SmtpException sEx)
            {
                throw sEx;
            }
        }
        public void SendPassword(string email, string password)
        {           
            try
            {
                using (SmtpClient client = new SmtpClient("smtp.gmail.com"))
                {
                    MailMessage message = new MailMessage();
                    message.From = new MailAddress("huishi0709@gmail.com");
                    message.To.Add(email);
                    message.Body = "Here is your old password: " + password + " .";
                    message.Subject = "Your Old Password at YourDesign";
                    client.UseDefaultCredentials = false;
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.Credentials = new System.Net.NetworkCredential("huishi0709@gmail.com", "593010sh");
                    client.Send(message);
                    message = null;

                }
            }
            catch (SmtpFailedRecipientsException sfrEx)
            {
                throw sfrEx;
            }
            catch (SmtpException sEx)
            {
                throw sEx;
            }
            
        }
    }
}
