using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.Core
{
    public class UserService : IUserService
    {
        private readonly List<User> _users;

        public UserService()
        {
            //idk how to initialize this one
            _users = new List<User>
            {
                new User { Username = "ryl", PasswordHash = "gandasomuch" },
                new User { Username = "Shane", PasswordHash = "123ILY" }
            };
        }

        public Task<User> GetUserAsync(string username)
        {
            return Task.FromResult(_users.FirstOrDefault(u => u.Username == username));
        }

        public Task<bool> ValidateCredentialsAsync(string username, string password)
        {
            var user = _users.FirstOrDefault(u => u.Username == username);
            if (user == null)
                return Task.FromResult(false);

            // just comparing this for the application
            return Task.FromResult(user.PasswordHash == password);
        }
    }
}