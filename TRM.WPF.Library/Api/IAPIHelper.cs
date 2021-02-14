using System.Threading.Tasks;
using TRM.WPF.Library.Models;

namespace TRM.WPF.Library.Api
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> AuthenticateAsync(string username, string password);
        Task GetLoggedInUserAsync(string token);
    }
}