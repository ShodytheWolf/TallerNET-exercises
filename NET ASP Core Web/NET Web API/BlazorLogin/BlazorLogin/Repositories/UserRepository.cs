using Microsoft.AspNetCore.Mvc.Formatters;
using BlazorLogin.Models;

namespace BlazorLogin.Repositories

{
    public class UserRepository : IUserRepository
    {
        private IDictionary<string, User> _users;
        public UserRepository() {

            _users = new Dictionary<string, User>();

            User user1 = new User("pepe@gmail.com","pepito");
            User user2 = new User("maicol@gmail.com", "elmaicol");
            User user3 = new User("harrydubois@gmail.com", "precinto41");

            Add(user1);
            Add(user2);
            Add(user3);
        }

        public User Get(string hashedPassword)
        {
            return this._users[hashedPassword];
        }

        public void Add(User userToAdd) {
            this._users.Add(userToAdd.Password,userToAdd);
        }
    }
}
