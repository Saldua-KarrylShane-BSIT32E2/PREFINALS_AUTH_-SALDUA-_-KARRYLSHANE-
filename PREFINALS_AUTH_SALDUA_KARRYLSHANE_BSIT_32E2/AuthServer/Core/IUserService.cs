using System.Threading.Tasks;

namespace AuthServer.Core
{
    public interface IUserService
    {
        Task<User> GetUserAsync(string username);
        Task<bool> ValidateCredentialsAsync(string username, string password);
      
    }
}