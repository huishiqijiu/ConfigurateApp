using Configurator.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Services.ServiceModels
{
    public class UserModel
    {
        public UserModel(User user)
        {
            Id = user.Id;
            LoginEmail = user.LoginEmail;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Password = user.Password;
            Telephone = user.Telephone;
            Company = user.Company;
            Address = user.Address;
            IsAdmin = user.IsAdmin;
        }
        public UserModel()
        {

        }

        public int Id { get; set; }
        public string LoginEmail { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public bool IsAdmin { get; set; }




        public User GetRepoUser()
        {
            return new User
            {
                Id = Id,
                LoginEmail = LoginEmail,
                FirstName = FirstName,
                LastName = LastName,
                Password = Password,
                Telephone = Telephone,
                Company = Company,
                Address = Address,
                IsAdmin = IsAdmin
            };
        }
    }
}
