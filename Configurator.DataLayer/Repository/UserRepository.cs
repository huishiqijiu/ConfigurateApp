using Configurator.DataLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.DataLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        ConfiguratorEntities1 db = new ConfiguratorEntities1();
        public void ChangePassword(int id, string newPass)
        {
            User u = db.Users.FirstOrDefault(x=>x.Id == id);
            u.Password = newPass;
            db.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return db.Users.ToList();
        }

        public User GetUser(string mail)
        {
            return db.Users.FirstOrDefault(x => x.LoginEmail == mail);
        }

        public User GetUserById(int id)
        {
            return db.Users.FirstOrDefault(x => x.Id == id);
        }

        public User SaveUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user;
        }

        public bool UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
