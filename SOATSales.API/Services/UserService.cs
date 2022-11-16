using SOATSales.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOATSales.API.Services
{
    public class UserService : IUserService
    {
        List<User> users = new List<User>()
        {
            new User() {Email = "user1@gmail.com", Password = "123456"},
            new User() {Email = "user2@gmail.com", Password = "654321"}
        };

        public bool IsUser(string email, string password) =>
            users.Where(u => u.Email == email && u.Password == password).Count() > 0;
    }
}
